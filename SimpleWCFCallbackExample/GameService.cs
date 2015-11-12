using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SimpleWCFCallbackExample
{
    [ServiceBehavior]
    public class GameService : IGameService, IGameCallbacks
    {
        static Dictionary<string, IBroadcastorCallback> callbacks = new Dictionary<string, IBroadcastorCallback>();
        static Dictionary<string, int> guesses = new Dictionary<string, int>();

        /// <summary>
        /// Anyone can guess a number, even if they don't have the ability to register for a callback.
        /// </summary>
        /// <param name="clientName">The name of the player, used to track their guess(es).</param>
        /// <param name="value">The player's guess should be a number from 0 - 9</param>
        /// <returns>A string letting the player know if their guess has been registered.</returns>
        public string GuessNumber(string clientName, int value)
        {
            if (clientName == null)
                return "We don't take kindly to null's 'round here.";

            if (guesses.ContainsKey(clientName))
                return string.Format("You can't guess again this round. You already guessed {0}.", guesses[clientName]);

            if (guesses.ContainsValue(value))
                return string.Format("{0} has already been guessed. Pick a different number.", value);

            guesses[clientName] = value;

            return string.Format("You guessed: {0}\nWaiting for other players to guess...", value);
        }

        /// <summary>
        /// Finish the game by guessing a number
        /// </summary>
        public void GuessTheNumber()
        {
            int theNumber = new Random().Next(0, 9);

            foreach (var guess in guesses) {
                if (guess.Value == theNumber)
                {
                    try
                    {
                        callbacks[guess.Key].BroadcastToClient("You won! ༼ ◔ ͜ʖ ◔ ༽");
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {
                        callbacks[guess.Key].BroadcastToClient("You didn't win, don't feel bad. It happens.");
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            guesses = new Dictionary<string, int>();
        }

        public void RegisterClient(string clientName)
        {
            try
            {
                callbacks[clientName] = OperationContext.Current.GetCallbackChannel<IBroadcastorCallback>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
