namespace ConsoleApp_CSharpProject
{
    internal class TicketSystem
    {
        public static void Start() 
        {
            // We define how many tickets to create using a CONSTANT and create variables to store our descriptions and priorities
            const int TICKET_AMOUNT = 4;
            string[] ticketDescriptions = new string[TICKET_AMOUNT];
            string[] ticketPriorities = new string[TICKET_AMOUNT];

            // We welcome the user to the system and prompt them to enter ticket details while also informing of the valid priorities
            Console.WriteLine("Welcome to the Ticket System!");
            Console.WriteLine("Enter ticket description and priority for each ticket:");

            ConsoleText.CreateBox(["Welcome to the Ticket System!", "Enter ticket description and priority for each ticket", "", "Valid priorities: Low - Medium - High"]);

            // We loop through the amount of tickets we have
            for (int i = 0; i < ticketDescriptions.Length; i++) 
            {
                // Prompt the user to enter a description and a priority value for the ticket
                Console.WriteLine($"Ticket [{i+1}]");
                Console.Write("Description > ");
                string? description = Console.ReadLine();
                if (String.IsNullOrEmpty(description)) { description = "undefined"; };

                Console.Write("Priotity > ");
                string? priority = Console.ReadLine();
                if (String.IsNullOrEmpty(priority)) { priority = "Low"; };
                Console.WriteLine("");

                // Store the entered values in the arrays
                ticketDescriptions[i] = description;
                ticketPriorities[i] = priority;
            }

            // Clearing the console for less clutter
            Console.Clear();

            // Looping through each ticket and showing the user their ticket id, description and priority
            for (int i = 0; i < ticketDescriptions.Length; i++) 
            {
                Console.WriteLine($"Ticket ID: [{i+1}]");
                Console.WriteLine($"Description: {ticketDescriptions[i]}");
                Console.WriteLine($"Priority: {ticketPriorities[i]}");
                Console.WriteLine("");
            }

            // At last we show the user how many tickets of each priority type they have
            Console.WriteLine($"You have {ticketPriorities.Count("High")} high priority tickets");
            Console.WriteLine($"You have {ticketPriorities.Count("Medium")} medium priority tickets");
            Console.WriteLine($"You have {ticketPriorities.Count("Low")} low priority tickets");

        }
    }
}
