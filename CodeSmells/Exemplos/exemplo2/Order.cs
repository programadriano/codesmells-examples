namespace CodeSmells.Exemplos.exemplo2
{
    public class Order
    {
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string ShippingOption { get; set; }

        public decimal CalculateTotal()
        {
            decimal discountedSubtotal = Subtotal - Discount;

            if (discountedSubtotal < 0)
            {
                discountedSubtotal = 0;
            }

            decimal taxAmount = discountedSubtotal * Tax;

            decimal shippingCost;

            if (ShippingOption == "Standard")
            {
                shippingCost = 10;
            }
            else if (ShippingOption == "Express")
            {
                shippingCost = 20;
            }
            else if (ShippingOption == "Overnight")
            {
                shippingCost = 30;
            }
            else
            {
                throw new InvalidOperationException("Invalid shipping option");
            }

            decimal total = discountedSubtotal + taxAmount + shippingCost;

            return total;
        }
    }
}
