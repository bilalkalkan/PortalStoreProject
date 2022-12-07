using AutoMapper;
using PortalStore.Business.Abstract;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;

        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }


        public async Task<AddressDetailDto> Get(int id)
        {
            var data = await _addressDal.GetAsync(x => x.Id == id);
            AddressDetailDto mapped = _mapper.Map<AddressDetailDto>(data);
            return mapped;
        }

        public async Task<IList<AddressDetailDto>> GetAll()
        {
            var data = await _addressDal.GetAddresses();
            IList<AddressDetailDto> addressDetailDtos = _mapper.Map<IList<AddressDetailDto>>(data);
            return addressDetailDtos;
        }

        public async Task<bool> Add(AddAddressDto address)
        {
            var maped = _mapper.Map<Address>(address);
            await _addressDal.AddAsync(maped);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var data = _addressDal.GetAsync(x => x.Id == id).Result;
            await _addressDal.DeleteAsync(data);
            return true;
        }

        public async Task<bool> Update(UpdateAddressDto address)
        {
            var mapped = _mapper.Map<Address>(address);
            await _addressDal.UpdateAsync(mapped);
            return true;
        }
    }
}
