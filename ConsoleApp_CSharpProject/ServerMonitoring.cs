namespace ConsoleApp_CSharpProject
{
    internal class ServerMonitoring
    {
        public static void Start() 
        {
            // setting the servers up and a side array for temperatures where we make its defined length the length of the server list
            string[] servers = ["Server-A", "Server-B", "Server-C", "Server-D", "Server-E"];
            double[] temperatures = new double[servers.Length];
            double sumOfTemperatures = 0;
            
            // We also keep track of the highest temperature between the servers
            double highestTemperature = 0;
            string highestTemperatureName = "";

            List<string> serverListDisplay = [];

            ConsoleText.CreateBox(["WELCOME TO SERVER MONITORING", "", "Enter the temperature for each server", ""]);

            // Here we loop through the server list to give each server a temperature
            for (int i = 0; i < servers.Length; i++) 
            {
                Console.WriteLine($"Enter the temperature for {servers[i]}");
                Console.Write("> ");
                double temperature = Convert.ToDouble(Console.ReadLine());
                temperatures[i] = temperature;
                sumOfTemperatures += temperature;

                // After the user inputs the temperature we check if its temperature is higher than that of the current highest
                // In the case that the server is the first on the list we automatically set them as the highest temperature
                if (temperature > highestTemperature || i == 0) 
                {
                    highestTemperatureName = servers[i]; 
                    highestTemperature = temperature; 
                };

                serverListDisplay.Add($"Server:      {servers[i]}");
                serverListDisplay.Add($"Temperature: {temperature}");


                // We add another message depending on the temperature
                switch (temperature)
                {
                    case < 60: //Less than 60 degrees
                        serverListDisplay.Add($"Status: Normal");
                        break;
                    case < 80: // Between 60-79
                        serverListDisplay.Add($"Status: Warning");
                        break;
                    case >= 80: // Above 80
                        serverListDisplay.Add($"Status: CRITICAL - ALARM!");
                        break;
                }

                serverListDisplay.Add("");
            }

            // At last we calculate the average temperature and show the user a list of the servers and their status
            double averageTemperature = sumOfTemperatures / temperatures.Length;

            Console.Clear();

            ConsoleText.CreateBox(
                [
                "SERVER LIST", 
                "", 
                ..serverListDisplay, 
                "",
                $"Average temperature: {averageTemperature}",
                "",
                "Server with the highest temperature:", 
                $"Name: {highestTemperatureName}", 
                $"Temperature: {highestTemperature}" ,
                ""
                ], new ConsoleTextOptions { centered = true });
        }
    }
}
