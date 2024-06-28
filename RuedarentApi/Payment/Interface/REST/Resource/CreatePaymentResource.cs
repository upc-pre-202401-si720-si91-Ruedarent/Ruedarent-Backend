namespace RuedarentApi.Payment.Interfaces.REST.Resources
{
    public class CreatePaymentResource
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}