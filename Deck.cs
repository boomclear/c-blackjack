namespace BlackJack
{
    class Deck
    {
        List<Card> Cards = new();
        public Deck()
        {
            this.CreateDeck();
        }

        public void CreateDeck() 
        {
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

            foreach (string suit in suits)
            {
                foreach (string face in faces)
                {
                    Cards.Add(new Card(suit, face));
                }
            }


        }

        public void ShuffleDeck()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1) 
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = card;
            }
        }

        public Card DrawCard()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}