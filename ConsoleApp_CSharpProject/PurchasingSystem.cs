namespace ConsoleApp_CSharpProject
{
    internal class PurchasingSystem
    {

        private class Product 
        { 
            public required string Name; 
            public required int Units; 
            public required double UnitPrice; 
        }
        private static (double, int) GetProductPrice(Product product)
        {
            // We calculate the total price based on unit price and total units while also noting down the discountState
            // Discount state is 0 if no discount has been applied, 1 if the 10% and 2 if the 15%.
            double totalPrice = product.UnitPrice * product.Units;
            int discountState = 0;

            // We check if the prices exceed a certain amount and apply the respective discounts.
            // If above 10000 then apply 15% or if over 5000 then apply 10%
            if (totalPrice > 10000)
            {
                discountState = 2;
                totalPrice *= 0.85;
            }
            else if (totalPrice > 5000)
            {
                discountState = 1;
                totalPrice *= 0.9;
            }

            // Then finally apply moms to the price
            double finalisedPrice = totalPrice * 1.25;

            return (finalisedPrice, discountState);
        }

        static string[] GetDisplayForProduct(Product product)
        {
            // We make a list to store the displayText in as it doesn't always have a specific length
            List<string> displayText =
                [
                $"Product: {product.Name}",
                $"Amount ordered: {product.Units} units",
                $"Price per unit: {product.UnitPrice} kr.",
                ""
                ];


            (double finalPrice, int discountState) = GetProductPrice(product);

            // We go through the 2 discount states to show the user if a discount was applied
            switch (discountState)
            {
                case 1:
                    displayText.Add("Total price is above 5000 kr.");
                    displayText.Add("A 10% discount has been applied!");
                    displayText.Add("");
                    break;
                case 2:
                    displayText.Add("Total price is above 10000 kr.");
                    displayText.Add("A 15% discount has been applied!");
                    displayText.Add("");
                    break;
            }

            // Vis at moms er beregnet til brugeren
            displayText.Add("A 25% moms has been applied");
            displayText.Add($"New total is: {finalPrice} kr.");

            return displayText.ToArray();
        }

        public static void Start() 
        {
            // We introduce the user to the system and prompt them to enter the company name
            ConsoleText.CreateBox(["PURCHASING SYSTEM      ", "", "Here you can order new products", "by using your company name"]);
            Console.WriteLine("Enter the company name:");
            Console.Write("> ");
            string? companyName = Console.ReadLine();

            // We keep track of the order status so we know when to end the loop
            bool orderCompleted = false;

            // A list so we can save the orders and show them all at the end
            List<Product> productsOrdered = [];

            while (orderCompleted == false)
            {
                // Clears console after each loop and shows the company name
                Console.Clear();
                ConsoleText.CreateBox(["PURCHASING SYSTEM      ", "", $"Company: {companyName}", ""]);
                
                // Prompts the user to enter product name, amount and unit price and store them as variables
                Console.WriteLine("Enter the product name:");
                Console.Write("> ");
                string? productName = Console.ReadLine();
                if (String.IsNullOrEmpty(productName)) { productName = "undefined"; };

                Console.WriteLine("Enter the product unit amount:");
                Console.Write("> ");
                int productUnits = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the product unit price:");
                Console.Write("> ");
                double productUnitPrice = Convert.ToDouble(Console.ReadLine());

                //We then store the product info into a Product class and add it to the products ordered list
                Product product = new() 
                { 
                    Name = productName, 
                    Units = productUnits, 
                    UnitPrice = productUnitPrice 
                };

                productsOrdered.Add(product);

                //Lastly we show the user the receipt for the current product and ask if they want to finalise or continue their orders
                Console.Clear();
                ConsoleText.CreateBox(["RECEIPT", $"This receipt is for {companyName}", "", ..GetDisplayForProduct(product), ""]);

                Console.WriteLine("To finalise the order type stop");
                Console.WriteLine("To add a new product to the order press enter");

                string? userInput = Console.ReadLine();

                if (userInput == "stop") orderCompleted = true;
            };

            // This is to finalise and check for the total price of all products while creating a final receipt for all the products ordered
            Console.Clear();

            List<string> productsDisplayText = [];
            double totalPriceForAllUnits = 0;

            // Here we loop through each product to add them to the displayText receipt while counting their prices for the total
            foreach (var product in productsOrdered)
            {
                (double finalPrice, int _) = GetProductPrice(product);

                totalPriceForAllUnits += finalPrice;

                productsDisplayText.Add("");
                productsDisplayText.AddRange(GetDisplayForProduct(product));
                productsDisplayText.Add("");
            }

            // We show the user what they've ordered and the total price
            ConsoleText.CreateBox(
                [ "FINALISED RECEIPT", $"This receipt is for {companyName}", "", ..productsDisplayText, "", $"Total price: {totalPriceForAllUnits}" ]
                );
        }
    }
}
