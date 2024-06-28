namespace RuedarentApi.Payment.Domain.Model.Commands
{
    public class CreatePaymentCommand
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}