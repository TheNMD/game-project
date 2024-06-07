using UnityEngine;
namespace SlayTheHaunted
{
    public class Card : ScriptableObject
    {
        public string cardTitle;
        public string cardDescription;
        public int cardCost;
        public int cardValue;
        public string cardTarget;
        public void SetCard(string title, string description, int value, int cost)
        {
            cardTitle = title;
            cardDescription = description;
            cardValue = value;
            cardCost = cost;
        }
        public int GetCardCostAmount() { return cardCost; }
        public string GetCardDescriptionAmount() { return cardDescription; }
    }
}