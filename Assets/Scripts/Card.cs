using UnityEngine;

namespace SlayTheHaunted
{
    public class Card : ScriptableObject
    {
        public string cardTitle;
        public string cardDescription;
        public int cardAmount;
        public int cardCost;
        public int cardEffect;
        public Sprite cardIcon;
        public CardType cardType;
        public enum CardType{Attack, Defend}
        public CardTargetType cardTargetType;
        public enum CardTargetType{Self, Enemy};

        public int GetCardCostAmount() { return cardCost; }
        public int GetCardEffectAmount() { return cardEffect; }
        public string GetCardDescriptionAmount() { return cardDescription; }
    }
}