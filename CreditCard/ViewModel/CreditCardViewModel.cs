namespace CreditCard.ViewModel
{
    public class CreditCardViewModel
    {

        public string CardNumber { get; set; } = null!;

        public string ExpiryDate { get; set; } = null!;

        public string CardholderName { get; set; } = null!;

        public int Cvv { get; set; }
    }
}
