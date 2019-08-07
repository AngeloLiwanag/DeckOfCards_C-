using System;
using System.Collections.Generic;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            // myDeck.deal();
            // myDeck.deal();
            // myDeck.deal();
            // myDeck.reset();
            // myDeck.deal();
            myDeck.shuffle();
            myDeck.deal();
            Player Angelo = new Player("Angelo");
            Angelo.draw(myDeck);
            Angelo.draw(myDeck);
            Angelo.draw(myDeck);
            Angelo.draw(myDeck);

            Angelo.showHand();
            Angelo.discard(0);
            System.Console.WriteLine();
            Angelo.showHand();

        }
    }
    class Card 
    {
        // Properties
        public string stringVal;
        public string suit;
        public int val;

        // Constructor
        public Card (string stringVal, string suit, int val)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }
    }

    class Deck
    {
        // Properties
        public List<Card> Cards;

        public Deck()
        {
            this.Cards = new List<Card>();
            string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suit = {"Clubs", "Spades", "Hearts", "Diamonds"}; 
            foreach (string x in suit)
            {
                for(int i = 0; i < stringVal.Length; i++)
                {
                    // System.Console.WriteLine($"{stringVal[i]} {x}");
                    Card setOfCards = new Card(stringVal[i], x, i+1); 
                    Cards.Add(setOfCards);
                }
            }
        }
        public Card deal()
        {
            Card single = Cards[Cards.Count-1];
            System.Console.WriteLine($"The Card sent out is {single.stringVal} {single.suit}.");
            Cards.Remove(single);
            System.Console.WriteLine($"There is now {Cards.Count} Cards in this deck.");
            return single;
        }
        
        public void reset()
        {
            this.Cards = new List<Card>();
            string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suit = {"Clubs", "Spades", "Hearts", "Diamonds"}; 
            foreach (string x in suit)
            {
                for(int i = 0; i < stringVal.Length; i++)
                {
                    Card setOfCards = new Card(stringVal[i], x, i+1); 
                    Cards.Add(setOfCards);
                }
            }
            System.Console.WriteLine($"The deck is reset to {Cards.Count}");
        }

        public void shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < this.Cards.Count-1; i++)
            {
                int random = rand.Next(0, Cards.Count);
                Card temp = Cards[random];
                Cards[random]=Cards[i];
                Cards[i]=temp;
            }

            foreach (var card in Cards)
            {
                System.Console.WriteLine($"{card.stringVal} {card.suit}");
            }
        }
    }

    class Player
    {
        public string name {get;}
        public List<Card> hand = new List<Card>();

        public Player (string name)
        {
            this.name = name;
            hand = new List<Card>();
        }

        public void draw(Deck deck)
        {
            Card mycard = deck.deal();
            System.Console.WriteLine($"You got {mycard.stringVal} {mycard.suit}");
            hand.Add(mycard);
        }

        public void showHand()
        {
            foreach (var card in this.hand)
            {
                System.Console.WriteLine($"My hand has {card.stringVal} {card.suit}");
            }
        }

        public void discard(int num)
        {
            this.hand.RemoveAt(num);
        }

    }
}
