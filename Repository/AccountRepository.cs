﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using TheBookStore.Data;
using TheBookStore.Migrations;
using TheBookStore.Models.Authentication;

namespace TheBookStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<ApplicationUser> roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, RoleManager<ApplicationUser> roleManager)
        { 
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;

        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                return string.Empty;
            }
            var authClaims = new List<Claim> 
            {
                new Claim(ClaimTypes.Email, model.Email),
                   new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid
                   ().ToString())           
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey,SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var newUser = new ApplicationUser
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
            };
            var role = roleManager.FindByNameAsync(model.Role).Result;
            if (role != null)
            {
                IdentityResult roleresult = await userManager.AddToRoleAsync(newUser, role.Name);
            }
            return await userManager.CreateAsync(newUser);
        }
    }
}
