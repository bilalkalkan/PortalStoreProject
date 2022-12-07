using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MernisKimlik;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.Customer;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.Business.Concrete
{
    public class MernisManager : IMernisService
    {
        public async Task<bool> TcIdVerification(AddCustomerDto requestModel)
        {
            bool verificationResult = false;

            try
            {
                KPSPublicSoapClient soapClient = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

                var result = soapClient.TCKimlikNoDogrulaAsync(Convert.ToInt64(requestModel.TCID), requestModel.FirstName, requestModel.LastName, requestModel.BirthDate.Year).Result;
                verificationResult = result.Body.TCKimlikNoDogrulaResult;
            }
            catch
            {
                verificationResult = false;
            }

            return verificationResult;
        }
    }
}