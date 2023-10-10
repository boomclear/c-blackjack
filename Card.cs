namespace BlackJack
{
    class Card
    {
        public string suit;
        public int value;
        public string face;
        public Card(string suit, string face)
        {
            this.face = face;
            this.suit = suit;
            this.value = FindValue(face);
        }

        public static int FindValue(string face)
        {
            if (face == "A")
            { return 11; }
            else if ((face == "K") || (face == "Q") || (face == "J") || (face == "10"))
            { return 10; }
            else if (face == "9")
            { return 9; }
            else if (face == "8")
            { return 8; }
            else if (face == "7")
            { return 7; }
            else if (face == "6")
            { return 6; }
            else if (face == "5")
            { return 5; }
            else if (face == "4")
            { return 4; }
            else if (face == "3")
            { return 3; }
            else
            { return 2; }
        }
    }
}