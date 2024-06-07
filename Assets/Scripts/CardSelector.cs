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
        public List<CardUI> cardsUI = new List<CardUI> {};
        public List<Sprite> cardImages = new List<Sprite> {};
        public int drawLimit = 5;
        public TextMeshProUGUI deckText;
        public TextMeshProUGUI discardText;
        public int playedCardsThisRound;
        private void Awake() { ShuffleCard(deck); } 
        public void DrawCard()
        {   
            playedCardsThisRound = 0;
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
        public void RemoveCard()
        {   
            if (playedCardsThisRound < 6) { playedCardsThisRound += 1; }
            discardText.text = (discard.Count + playedCardsThisRound).ToString();
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
        public List<Card> GetHand()
        {   
            List<Card> cards = new List<Card> {};
            foreach (string cardName in hand)
            {   
                Card newCard = ScriptableObject.CreateInstance<Card>();
                if (cardName == "LAttack") { newCard.SetCard("LAttack", "Deal 10 damage.", 1, "Enemy"); }
                else if (cardName == "HAttack") { newCard.SetCard("HAttack", "Deal 25 damage.", 2, "Enemy"); }
                else if (cardName == "Defend") { newCard.SetCard("Defend", "Block 10 damage.", 1, "Enemy"); }
                cards.Add(newCard);
            }
            return cards;
        }
        public List<CardUI> GetHandUI(List<Card> playerHand)
        {   
            for (int i = 0; i < playerHand.Count; i++)
            {   
                if (playerHand[i].cardTitle == "LAttack") { cardsUI[i].LoadCard(i, playerHand[i], cardImages[0]); }
                else if (playerHand[i].cardTitle == "HAttack") { cardsUI[i].LoadCard(i, playerHand[i], cardImages[1]); }
                else if (playerHand[i].cardTitle == "Defend") { cardsUI[i].LoadCard(i, playerHand[i], cardImages[2]); }
            }
            return cardsUI;
        }
        // Update CardStack UI 
        void UpdateUI()
        {
            deckText.text = deck.Count.ToString();
            discardText.text = discard.Count.ToString();
        }
    }
}