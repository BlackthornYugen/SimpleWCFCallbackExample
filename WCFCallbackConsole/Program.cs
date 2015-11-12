namespace WCFCallbackConsole
{
    using System;
    using GameService;

    class Program
    {
        static void Main(string[] args)
        {
            var service = new GameServiceClient();
            int userGuess;
            string userName = null;
            string userInput = null;
            Console.Title = "WCF Callback Console";

            // Get the user name
            while (String.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("What is your name?");
                userName = Console.ReadLine();
            }

            Console.Title += String.Format(" - Player {0}", userName);

            // Register as a client and reference our callback client wrapped inside an instance context.
            try
            {
                Console.Write("Connecting to server... ");
                new GameCallbacksClient(new System.ServiceModel.InstanceContext(new CallMe())).RegisterClient(userName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed!");
                System.Threading.Thread.Sleep(1000);
                throw e;
            }
            Console.WriteLine("Success!");

            // Event Loop
            do
            {
                Console.WriteLine("Q - Quit\nF - Finish this round\nC - Clear the screen\n# - Guess a number");
                userInput = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                try
                {
                    userGuess = int.Parse(userInput);
                }
                catch (FormatException)
                {
                    userGuess = -1;
                }

                if (userGuess >= 0)
                {
                    Console.WriteLine(service.GuessNumber(userName, userGuess));
                } else {
                    switch(userInput.ToLower())
                    {
                        case "f":
                            service.GuessTheNumber();
                            break;
                        case "c":
                            Console.Clear();
                            break;
                        case "q":
                            Console.WriteLine("Goodbye!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        default:
                            Console.WriteLine("Invalid Input!");
                            break;
                    }
                }
            } while (userInput.ToLower() != "q");
        }
    }

    class CallMe : IGameCallbacksCallback
    {
        public void BroadcastToClient(string message)
        {
            Console.WriteLine(message);
        }
    }
}
