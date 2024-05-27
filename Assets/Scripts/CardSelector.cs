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
        public List<string> draw = new List<string> {};
        public List<string> discard = new List<string> {};
        public int drawLimit = 5;
       public TextMeshProUGUI deckText;
       public TextMeshProUGUI discardText;  

        private void Awake() 
        {   
            ShuffleCard(deck);
            draw = deck.GetRange(0, drawLimit);
            deck.RemoveRange(0, drawLimit);

            // foreach (string ele in deck) { Debug.Log(ele); }
            
            foreach (string ele in draw) { Debug.Log(ele); }

            UpdateUI();
        }
        public void DrawCard()
        {   
            List<string> leftOver = draw.GetRange(0, draw.Count);
            discard.InsertRange(0, leftOver);

            if (deck.Count == 0)
            {
                deck = discard.GetRange(0, discard.Count);
                ShuffleCard(deck);
                discard.RemoveRange(0, discard.Count);
            }

            draw = deck.GetRange(0, drawLimit);
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
        // CardStats
        void UpdateUI()
        {
            deckText.text = deck.Count.ToString();
            discardText.text = discard.Count.ToString();
        }
    }
}