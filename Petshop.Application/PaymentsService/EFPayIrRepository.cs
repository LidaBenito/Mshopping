using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Petshop.Contract.Payments;
using Petshop.Core.Payments;

namespace Petshop.Application.PaymentsService
{
    public class EFPayIrRepository : PaymentRepository
    {
        private readonly IConfiguration configuration;

        public EFPayIrRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public RequestPaymentResult Request(string amount, string mobile, string factorNumber, string Description)
        {
            HttpClient Client = new();
            Dictionary<string, string> post_values = new();
            post_values.Add("api", configuration["payIr:ApiKey"]);
            post_values.Add("amount", amount);
            post_values.Add("redirect", configuration["payIr:RedirectUrl"]);
            post_values.Add("mobile", mobile);
            post_values.Add("factornumber", factorNumber);
            post_values.Add("description", Description);
            var content = new FormUrlEncodedContent(post_values);
            var response = Client.PostAsync(configuration["payIr:SendRequestUrl"], content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
                var result=JsonConvert.DeserializeObject<RequestPaymentResult>(responseString);
            return result; 
        }


        public VarifyPaymentResult Varify(string transId)
        {
            throw new NotImplementedException();
        }
    }
}
