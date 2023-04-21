using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using TheBookStore.Data;
using TheBookStore.Migrations;
using TheBookStore.Models.Authentication;
using Method = RestSharp.Method;

namespace TheBookStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            string role = "User";
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            var userRole = await userManager.GetRolesAsync(user);
            if (userRole.Contains("Admin"))
            {
                role = "Admin";
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                   new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid
                   ().ToString()),
                   new Claim(ClaimTypes.Role, role),
                   new Claim(ClaimTypes.Name , user.Name)
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApplicationUser> GetUserAsync(string username)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(username);
            return user;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model, string role)
        {

            var userExist = userManager.FindByEmailAsync(model.Email).Result;
            if (userExist == null)
            {
                var newUser = new ApplicationUser
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                IdentityResult userResult = await userManager.CreateAsync(newUser, model.Password);
                IdentityResult roleresult = await userManager.AddToRoleAsync(newUser, role);
                return userResult;
            }
            else return null;
        }
    }
}
