namespace Petshop.Core.Payments
{
    public class RequestPaymentResult
    {
        public int Status { get; set; }
        public string Token { get; set; }
        public bool IsCorrect => Status == 1;
    }
}
