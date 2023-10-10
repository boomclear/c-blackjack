namespace BlackJack
{
    class Player
    {
        public List<Card> Hand = new();
        public int HandValue = 0;

        public void ReceiveCard(Card card)
        {
            this.Hand.Add(card);
        }

        public void TempHandValue()
        {
            int value = 0;
            foreach (Card card in Hand)
            {
                value += card.value;
            }

            HandValue = value;
        }

        public int RealHandValue()
        {
            LowAces();
            return HandValue;
        }

    public bool LowAces()
        {
            TempHandValue();
            bool LowAce = false;
            foreach (Card card in Hand)
            {
                if ((card.face.Equals('A')) && (card.value == 11) && (HandValue > 21))
                {
                    card.value = 1;
                    LowAce = true;
                    TempHandValue();
                }
            }
            if ( LowAce) 
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public void ShowHand()
        {
            foreach (Card card in Hand)
            {
                Console.WriteLine($"{card.face} of {card.suit}");
            }
        }
    }
}