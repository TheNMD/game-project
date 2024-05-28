using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace SlayTheHaunted
{
    public class Card : ScriptableObject
    {
        public string cardTitle;
        public string cardDescription;
        public int cardCost;
        public string cardTarget;
        public void setCard(string title, string description, int cost, string target)
        {
            cardTitle = title;
            cardDescription = description;
            cardCost = cost;
            cardTarget = target;
        }
        public int GetCardCostAmount() { return cardCost; }
        public string GetCardDescriptionAmount() { return cardDescription; }
    }
}