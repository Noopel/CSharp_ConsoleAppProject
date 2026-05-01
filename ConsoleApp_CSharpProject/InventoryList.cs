namespace ConsoleApp_CSharpProject
{
    internal class InventoryList
    {
        public static void Start() 
        {
            // Preparing variables and setting up an info box for the user
            string[] names = new string[5];
            double[] prices = new double[5];

            double sumOfPrices = 0;

            List<string> textToDisplay = ["INVENTORY LIST        ", "All products:", ""];

            ConsoleText.CreateBox(["INVENTORY LIST   ", "You'll need to provide the information below", "for each product", "", "> Name", "> Price", ""]);

            // We then loop through the amount of times as the arrays are in length and allow the user to input the name and price for each product
            for (int i = 0; i < 5; i++) {
                // Clearing console each time we enter product information 
                Console.Clear();
                ConsoleText.CreateBox(["   INVENTORY LIST   ", "You'll need to provide the information below", "for each product", "", "> Name", "> Price"]);

                Console.WriteLine($"Product {i+1}");

                // We ask the user to input name and price that we use later on
                Console.Write("> Name: ");
                string? name = Console.ReadLine();

                // A double check to make sure the string isn't empty to avoid crashing the application
                if (String.IsNullOrEmpty(name)) { name = "Not defined"; };

                Console.Write("> Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                // Inserting the values into their respective arrays and adds the price to the sumOfPrices value
                names[i] = name;
                prices[i] = price;
                sumOfPrices += price;

                // Prepares the text to display at the end of the process by insterting it into textToDisplay
                textToDisplay.Add($"> Name:  {name}");
                textToDisplay.Add($"  Price: {price}");
                textToDisplay.Add($"");
            }

            // Calculate the average price using the sumOfPrices and prices.Length
            double averagePrice = sumOfPrices / prices.Length;

            // Add sum and average to the result text box
            textToDisplay.Add($"Sum of prices: {sumOfPrices}");
            textToDisplay.Add($"Average price: {averagePrice}");
            textToDisplay.Add("");

            // Create text box 
            Console.Clear();
            ConsoleText.CreateBox(textToDisplay.ToArray());
        }
    }
}
