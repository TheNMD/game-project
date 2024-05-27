using UnityEngine;

namespace SlayTheHaunted
{
    [CreateAssetMenu]
    public class Card : ScriptableObject
    {
        public string cardTitle;
        public string cardDescription;
        public int cardAmount;
        public int cardCost;
        public int cardEffect;
        public Sprite cardIcon;
        public CardType cardType;
        public enum CardType{Attack, Defend, Heal}
        public CardTargetType cardTargetType;
        public enum CardTargetType{Self, Enemy};

        public int GetCardCostAmount() { return cardCost; }
        public int GetCardEffectAmount() { return cardEffect; }
        public string GetCardDescriptionAmount() { return cardDescription; }
    }
}