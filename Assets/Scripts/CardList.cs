using UnityEngine;
using System.Collections.Generic;

namespace SlayTheHaunted
{
    public class CardList : MonoBehaviour
    {
        public List<string> deck = new List<string> { "LAttack", "LAttack", "LAttack", "LAttack", "LAttack", 
                                                      "LAttack", "LAttack", "LAttack", "LAttack", "LAttack",
                                                      "Defend", "Defend", "Defend", "Defend", "Defend", 
                                                      "Defend", "Defend", "Defend", "Defend", "Defend",
                                                      "HAttack", "HAttack", "HAttack", "HAttack", "HAttack" };
        public List<string> draw;
        public List<string> discard;

        private void Awake() 
        {   
            // Shuffle(deck);
            // draw = deck.GetRange(0, 5);

            // foreach (string ele in deck) { Debug.Log(ele); }
            
            // foreach (string ele in draw) { Debug.Log(ele); }
        }
        public static void Shuffle<T>(IList<T> list)
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
    }
}