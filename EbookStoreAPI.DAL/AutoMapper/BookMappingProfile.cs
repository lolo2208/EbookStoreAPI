using AutoMapper;
using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.AutoMapper
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<BookBE, BookDTO>().ReverseMap();
            CreateMap<UserBE, UserDTO>().ReverseMap();
            CreateMap<RoleBE, RoleDTO>().ReverseMap();
            CreateMap<ShoppingCartBE, ShoppingCartDTO>().ReverseMap();
            CreateMap<ShopCartDetailBE, ShopCartDetailDTO>().ReverseMap();
            CreateMap<SaleBE, SaleDTO>().ReverseMap();
            CreateMap<SaleDetailBE, SaleDetailDTO>().ReverseMap();
        }
    }
}
