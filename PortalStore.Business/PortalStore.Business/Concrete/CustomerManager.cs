using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PortalStore.Business.Abstract;
using PortalStore.DataAccess.Abstract;
using PortalStore.DataAccess.Concrete.EntityFramework;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Customer;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;
        private readonly IMernisService _mernisService;

        public CustomerManager(ICustomerDal customerDal, IMernisService mernisService, IMapper mapper = null)
        {
            _customerDal = customerDal;
            _mernisService = mernisService;
            _mapper = mapper;
        }

        public async Task<IList<CustomerDetailDto>> GetAll()
        {
            var data = await _customerDal.GetAllAsync();
            IList<CustomerDetailDto> customerDetailDtos = _mapper.Map<IList<CustomerDetailDto>>(data);
            return customerDetailDtos;
        }

        public async Task<CustomerDetailDto?> Get(int id)
        {
            var result= await _customerDal.GetAsync(x => x.Id == id);
            CustomerDetailDto mapped = _mapper.Map<CustomerDetailDto>(result);
            return mapped;

        }

        public async Task<bool> Add(AddCustomerDto addCustomer)
        {
            var verification = await _mernisService.TcIdVerification(addCustomer);
            if (verification == false)
            {
                throw new Exception("Böyle bir kişi bulunmuyor");
            }
            var maped = _mapper.Map<Customer>(addCustomer);
            await _customerDal.AddAsync(maped);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var data = _customerDal.GetAsync(x => x.Id == id).Result;
            await _customerDal.DeleteAsync(data);
            return true;
        }

        public async Task<bool> Update(UpdateCustomerDto customer)
        {
            var mapped = _mapper.Map<Customer>(customer);
            await _customerDal.UpdateAsync(mapped);
            return true;
        }
    }
}