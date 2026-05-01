namespace ConsoleApp_CSharpProject
{
    internal class Program
    {

        // An internal class used to more easily manage each application
        private class Application 
        {
            public required string Name { get; set; }
            public required Action Start { get; set; }
        }

        static void Main()
        {
            //Runs the main loop so it goes to the SYSTEM MANAGER after every program usage
            while (true)
            {

                // Create a list of applications so new ones can easily be added
                Application[] applications = [
                    new Application { Name = "Inventory List", Start = InventoryList.Start },
                    new Application { Name = "Login System", Start = LoginSystem.Start },
                    new Application { Name = "Purchasing System", Start = PurchasingSystem.Start },
                    new Application { Name = "School Grading System", Start = SchoolGradingSystem.Start },
                    new Application { Name = "Server Monitoring", Start = ServerMonitoring.Start },
                    new Application { Name = "Ticket System", Start = TicketSystem.Start }
                ];

                // Makes  alist of system lines that we then insert the names of each application into
                List<string> systemLines = ["SYSTEM MANAGER", "To run a program type its number out:", ""];

                for (int i = 0; i < applications.Length; i++) {
                    systemLines.Add($"> [{i}] {applications[i].Name}");
                }


                // Create a console box using the system lines and allow input from the user to select the application to run
                ConsoleText.CreateBox(systemLines.ToArray());
                Console.Write("> ");
                int systemChoice = Convert.ToInt32(Console.ReadLine());

                // Clears the console and runs the chosen application or tells the user if the program wasn't valid
                if (systemChoice >= 0 && systemChoice < applications.Length) {
                    Console.Clear();
                    applications[systemChoice].Start();
                }
                else
                {
                    Console.WriteLine("NO VALID PROGRAM SELECTED!");
                }



                // Pauses until user interaction and then clears console for next loop
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
