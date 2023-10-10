namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            BlackJack blackjack = new BlackJack();
            blackjack.GameStart();
        }
    }
    class BlackJack

    {

        bool mainMenu = true;
        Player Player;
        Player Dealer;
        Deck Deck;
        bool mainMenuQuit = false;

        public void GameStart()
        {
            while (mainMenu)
            {
                MainMenu();
                if (mainMenuQuit) { break; }
                if (mainMenu) { continue; }
                DealCards();
                if (mainMenu) { continue; }
                PlayerTurn();
                if (mainMenu) { continue; }
                DealerTurn();
                if (mainMenu) { continue; }
                GameResults();
            }
        }

        public void GameResults()
        {
            if (Player.HandValue > Dealer.HandValue)
            {
                Console.WriteLine("You Win!");
                mainMenu = true;
            }
            else if (Player.HandValue < Dealer.HandValue) 
            {
               /* Dealer.RealHandValue();
                Console.WriteLine($" Dealers hand Value: {Dealer.HandValue}");  */
                Console.WriteLine("You Lose!");
                mainMenu = true;
            }
            else
            {
                Console.WriteLine("Tie!");
                mainMenu = true;
            }
        }
        public bool GetDealerStatus(int value)
        {
            if (value < 17)
            {
                Dealer.ReceiveCard(Deck.DrawCard());
                Dealer.ShowHand();
                Dealer.RealHandValue();
                Console.WriteLine($"Dealer's Hand Value: {Dealer.HandValue}");
                return false;
            }
            else if (value > 21)
            {
                Console.WriteLine("Dealer Busted! You Win!");
                mainMenu = true;
                return true;
            }
            else
            {
                return true;
            }
        }

        public void GetPlayerStatus(int value)
        {
            if (value > 21)
            {
                Console.WriteLine($"Your Hand Value: {Player.HandValue}");
                Console.WriteLine("Lose! You Busted!");
                mainMenu = true;
            }
            else if ((value == 21) && (Player.Hand.Count == 2))
            {
                Console.WriteLine("BLACKJACK! YOU WIN!");
                mainMenu = true;
            }
            else
            {
                Console.WriteLine($"Your Hand Value: {Player.HandValue}");
            }
        }

        public void MainMenu()
        {
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("Would you like to (P)lay or (Q)uit?");
            string userChoice = Console.ReadLine();
            if ((userChoice.Equals("P")) || (userChoice.Equals("p")))
            {
                mainMenu = false;
            }
            else if ((userChoice.Equals("Q")) || (userChoice.Equals("q")))
            {
                Console.WriteLine("Goodbye!");
                mainMenuQuit = true;
            }
            else
            {
                Console.WriteLine("Invalid input, please either press P to play or Q to quit.");
                MainMenu();
            }

        }

        public void DealCards()
        {
            Player = new Player();
            Dealer = new Player();
            Deck = new Deck();
            Deck.CreateDeck();
            Deck.ShuffleDeck();
            Dealer.ReceiveCard(Deck.DrawCard());
            Player.ReceiveCard(Deck.DrawCard());
            Console.WriteLine("Dealer's Hand:");
            Console.WriteLine("______________");
            Dealer.ShowHand();
            Dealer.ReceiveCard(Deck.DrawCard());
            Player.ReceiveCard(Deck.DrawCard());
            Console.WriteLine("Your Hand:");
            Console.WriteLine("______________");
            Player.ShowHand();
            GetPlayerStatus(Player.RealHandValue());
        }

        public void DealerTurn()
        {
            Console.WriteLine("Dealer's Turn");
            Console.WriteLine("*************");
            Dealer.RealHandValue();
            Dealer.ShowHand();
            Console.WriteLine($"Dealer's Hand Value: {Dealer.HandValue}");


            for (; ; ) 
            {
                if (GetDealerStatus(Dealer.RealHandValue()))
                { break; }
            }
        }

        public void PlayerTurn()
        {
            for (; ; )
            {
                Console.WriteLine("Would you like to (H)it or (S)tay?");
                string userChoice = Console.ReadLine();
                if ((userChoice.Equals("H")) || (userChoice.Equals("h")))
                {
                    Player.ReceiveCard(Deck.DrawCard());
                    Player.ShowHand();
                    GetPlayerStatus(Player.RealHandValue());
                    if (mainMenu)
                    {
                        break;
                    }
                }
                else if ((userChoice.Equals("S")) || (userChoice.Equals("s")))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input, Please either input H for hit or S for stay.");
                }

            }
        }

    }
}