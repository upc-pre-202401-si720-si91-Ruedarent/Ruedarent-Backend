namespace RuedarentApi.Payment.Domain.Model.Aggregates
{
    public class Payment
    {
        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string PaymentMethod { get; private set; }
        public string Status { get; private set; }
        
        public Payment(Guid orderId, decimal amount, string paymentMethod)
        {
            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            PaymentDate = DateTime.UtcNow;
            PaymentMethod = paymentMethod;
            Status = "Pending"; 
        }
        
        public void UpdateStatus(string status)
        {
            Status = status;
        }
        
        public bool Validate()
        {
            if (Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
            if (string.IsNullOrWhiteSpace(PaymentMethod))
                throw new ArgumentException("Payment method cannot be empty.");
            
            return true;
        }
    }
}