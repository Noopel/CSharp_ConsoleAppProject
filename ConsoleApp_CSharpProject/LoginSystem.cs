namespace ConsoleApp_CSharpProject
{
    internal class LoginSystem
    {
        public static void Start()
        {
            // Defined it as a const as I dont expect the values to change
            const string USERNAME = "admin";
            const string PASSWORD = "Password1!";
            const int LOGIN_ATTEMPTS = 3;

            // We define a isLoggedIn state as a boolean and also keep track of the attempts the user has made to log in
            bool isLoggedIn = false;
            int attemptsUsed = 0;

            while (attemptsUsed < LOGIN_ATTEMPTS && isLoggedIn == false)
            {
                // We ask the user of the username and password
                Console.Write("Enter username: ");
                string? username = Console.ReadLine();

                Console.Write("Enter password: ");
                string? password = Console.ReadLine();

                // Here we validate if the username and password provided match the ones we've set.
                if (username == USERNAME && password == PASSWORD)
                {
                    // We toggle that they're logged in and break the loop 
                    isLoggedIn = true;
                }
                else
                {
                    // If the password or username doesn't match then we increase attemptsUsed and informs the user of the error before looping again.
                    attemptsUsed++;
                    Console.Clear();
                    Console.WriteLine("PASSWORD OR USERNAME IS INCORRECT");
                    Console.WriteLine($"You have {LOGIN_ATTEMPTS - attemptsUsed} attempt(s) left");
                    Console.WriteLine("");
                }
            }

            // Here we check if they successfully logged in or not and inform the user about it
            if (isLoggedIn) 
            {
                Console.WriteLine("Login successful!");
                Console.WriteLine("Welcome to the admin dashboard!");
            }
            else if (attemptsUsed == LOGIN_ATTEMPTS)
            {
                Console.WriteLine("The account has been locked. Please contact the IT-Department");
            }
            

        }
        
    }
}
