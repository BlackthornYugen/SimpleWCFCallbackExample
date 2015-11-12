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

            // Get the user name
            while (String.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("What is your name?");
                userName = Console.ReadLine();
            }

            // Register as a client and reference our callback client wrapped inside an instance context.
            new GameCallbacksClient(new System.ServiceModel.InstanceContext(new CallMe())).RegisterClient(userName);

            // Event Loop
            do
            {
                Console.WriteLine("Q - Quit\nF - Finish this round\n# - Guess a number");
                userInput = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                int.TryParse(userInput, out userGuess);
                if (userGuess > 0)
                {
                    Console.WriteLine(service.GuessNumber(userName, userGuess));
                } else if (userInput.ToLower() == "f") {
                    service.GuessTheNumber();
                } else {
                    Console.WriteLine("Invalid input!");
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
