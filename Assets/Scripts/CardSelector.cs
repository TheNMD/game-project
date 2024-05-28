using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SlayTheHaunted
{
    public class CardSelector : MonoBehaviour
    {
        public List<string> deck = new List<string> { "LAttack", "LAttack", "LAttack", "LAttack", 
                                                      "LAttack", "LAttack", "LAttack", "LAttack",
                                                      "Defend", "Defend", "Defend", "Defend", 
                                                      "Defend", "Defend", "Defend", "Defend",
                                                      "HAttack", "HAttack", "HAttack", "HAttack" };
        public List<string> hand = new List<string> {};
        public List<string> discard = new List<string> {};
        public int drawLimit = 5;
       public TextMeshProUGUI deckText;
       public TextMeshProUGUI discardText;  
        public void DrawCard()
        {   
            if (hand.Count != 0)
            {
                List<string> leftOver = hand.GetRange(0, hand.Count);
                discard.InsertRange(0, leftOver);
            }
            if (deck.Count == 0)
            {
                deck = discard.GetRange(0, discard.Count);
                ShuffleCard(deck);
                discard.RemoveRange(0, discard.Count);
            }
            hand = deck.GetRange(0, drawLimit);
            deck.RemoveRange(0, drawLimit);
            UpdateUI();
        }
        public static void ShuffleCard<T>(IList<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public List<Card> GetDeck()
        {
            List<Card> cards = new List<Card> {};
            foreach (string cardName in deck)
            {
                Card newCard = ScriptableObject.CreateInstance<Card>();
                if (cardName == "LAttack") { newCard.setCardEffect("LAttack", "Deal 10 damage.", 1, "Enemy"); }
                else if (cardName == "HAttack") { newCard.setCardEffect("HAttack", "Deal 25 damage.", 2, "Enemy"); }
                else if (cardName == "Defend") { newCard.setCardEffect("Defend", "Block 10 damage.", 1, "Enemy"); }
                cards.Add(newCard);
            }
            return cards;
        }
        public List<Card> GetHand()
        {
            List<Card> cards = new List<Card> {};
            foreach (string cardName in hand)
            {
                Card newCard = ScriptableObject.CreateInstance<Card>();
                if (cardName == "LAttack") { newCard.setCardEffect("LAttack", "Deal 10 damage.", 1, "Enemy"); }
                else if (cardName == "HAttack") { newCard.setCardEffect("HAttack", "Deal 25 damage.", 2, "Enemy"); }
                else if (cardName == "Defend") { newCard.setCardEffect("Defend", "Block 10 damage.", 1, "Enemy"); }
                cards.Add(newCard);
            }
            return cards;
        }
        public List<Card> GetDiscard()
        {
            List<Card> cards = new List<Card> {};
            foreach (string cardName in discard)
            {
                Card newCard = ScriptableObject.CreateInstance<Card>();
                if (cardName == "LAttack") { newCard.setCardEffect("LAttack", "Deal 10 damage.", 1, "Enemy"); }
                else if (cardName == "HAttack") { newCard.setCardEffect("HAttack", "Deal 25 damage.", 2, "Enemy"); }
                else if (cardName == "Defend") { newCard.setCardEffect("Defend", "Block 10 damage.", 1, "Enemy"); }
                cards.Add(newCard);
            }
            return cards;
        }
        // Update CardStack UI 
        void UpdateUI()
        {
            deckText.text = deck.Count.ToString();
            discardText.text = discard.Count.ToString();
        }
    }
}