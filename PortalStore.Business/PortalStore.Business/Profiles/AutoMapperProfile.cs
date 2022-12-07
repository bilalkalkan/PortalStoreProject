using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Category;
using PortalStore.Entity.Concrete.DTOs.Customer;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.DTOs.OrderItem;
using PortalStore.Entity.Concrete.DTOs.SKU;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.Business.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SkuDetailDto, SKU>().ReverseMap();
            CreateMap<SKU, SkuDetailDto>().ReverseMap();
            CreateMap<SkuAddDto, SKU>().ReverseMap();
            CreateMap<SKU, SkuAddDto>().ReverseMap();

            CreateMap<SkuUpdateDto, SKU>().ReverseMap();
            CreateMap<SKU, SkuUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap< CategoryDto,Category>().ReverseMap();

            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<AddCategoryDto, Category>().ReverseMap();

            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            CreateMap<Address, AddAddressDto>().ReverseMap();
            CreateMap<AddAddressDto, Address>().ReverseMap();

            CreateMap<Address, AddressDetailDto>().ReverseMap();
            CreateMap<AddressDetailDto, Address>().ReverseMap();


            //Customer
            CreateMap<Customer, CustomerDetailDto>().ReverseMap();
            CreateMap<CustomerDetailDto, Customer>().ReverseMap();

            CreateMap<Customer, AddCustomerDto>().ReverseMap();
            CreateMap<AddCustomerDto, Customer>().ReverseMap();

            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();

            CreateMap<Customer, AddressDetailDto>().ReverseMap();
            CreateMap<AddressDetailDto, Customer>().ReverseMap();

            //CreateMap<AddressDetailDto, UpdateAddressDto>().ReverseMap();
            //CreateMap<UpdateAddressDto, AddressDetailDto>().ReverseMap();

            CreateMap<Address, UpdateAddressDto>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();

            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<AddOrderDto, Order>().ReverseMap();

            CreateMap<OrderItem, AddOrderItemDto>().ReverseMap();
            CreateMap<AddOrderItemDto, Order>().ReverseMap();

            CreateMap<Order, OrderdetailDto>().ReverseMap();
            CreateMap<OrderdetailDto, Order>().ReverseMap();

            CreateMap<UpdateOrderDto, OrderdetailDto>().ReverseMap();
            CreateMap<OrderdetailDto, UpdateOrderDto>().ReverseMap();

            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
        }
    }
}