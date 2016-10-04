using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Low_Level_Objects_Library
{
    public class Hand : IEnumerable
    {
        // Out list of cards
        private List<Card> hand;

        // Empty Constructur
        public Hand()
        {

        }

        // Constructor with args
        public Hand(List<Card> cards)
        {
            this.hand = cards;
        }

        // Return number of cards @ hand
        public int GetCount()
        {
            return this.hand.Count;
        }

        // Returns card at specific position, but does not remove that card from hand
        public Card GetCard(int index)
        {
            return this.hand.ElementAt(index);
        }

        // Adds card to the hand
        public void Add(Card card)
        {
            this.hand.Add(card);
        }

        // Returns true if hand contains specific card
        public bool Contains(Card card)
        {
            return this.hand.Contains(card);
        }

        // Removes a specific card from the hand
        public bool Remove(Card card)
        {
            return this.hand.Remove(card);
        }

        // Removes card at specified position
        public void RemoveAt(int index)
        {
            this.hand.RemoveAt(index);
        }

        // Sorts card at hand
        public void Sort()
        {
            this.hand.Sort();
        }
        
        // Interface method
        public IEnumerator GetEnumerator()
        {
            return hand.GetEnumerator();
        }
    }
}
