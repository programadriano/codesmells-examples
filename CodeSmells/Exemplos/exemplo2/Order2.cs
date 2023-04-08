namespace CodeSmells.Exemplos.exemplo2
{
    public class Order2
    {
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string ShippingOption { get; set; }

        public decimal CalculateTotal()
        {
            decimal discountedSubtotal = CalculateDiscountedSubtotal();
            decimal taxAmount = CalculateTaxAmount(discountedSubtotal);
            decimal shippingCost = CalculateShippingCost();

            return discountedSubtotal + taxAmount + shippingCost;
        }

        private decimal CalculateDiscountedSubtotal()
        {
            decimal discountedSubtotal = Subtotal - Discount;

            return discountedSubtotal < 0 ? 0 : discountedSubtotal;
        }

        private decimal CalculateTaxAmount(decimal discountedSubtotal)
        {
            return discountedSubtotal * Tax;
        }

        private decimal CalculateShippingCost()
        {
            switch (ShippingOption)
            {
                case "Standard":
                    return 10;
                case "Express":
                    return 20;
                case "Overnight":
                    return 30;
                default:
                    throw new InvalidOperationException("Invalid shipping option");
            }
        }
    }
}
