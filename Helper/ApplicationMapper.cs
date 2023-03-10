using AutoMapper;
using TheBookStore.Data;
using TheBookStore.Models;

namespace TheBookStore.Helper
{
    public class ApplicationMapper : Profile
    {
       public ApplicationMapper()
        {
            CreateMap<Product, ProductModel>().ReverseMap(); 
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
