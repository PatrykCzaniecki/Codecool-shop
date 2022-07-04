namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }

    }
}