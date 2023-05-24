namespace basket.API.Entities
{
    public class Cart
    {
        public string Username {  get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items) { 
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }

        public Cart()
        {

        }

        public Cart(string username)
        {
            Username = username;
        }
    }
}
