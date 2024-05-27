using UnityEngine;

namespace SlayTheHaunted
{
public class CardAction : MonoBehaviour
    {
        Card card;
        public Fighter target;
        public Fighter player;

        private void Awake() {}
        public void PerformAction(Card _card, Fighter _fighter)
        {
            card = _card;
            target = _fighter;
            
            if (card.cardTitle == "LAttack" || card.cardTitle == "HAttack") { Attack(); }
            else if (card.cardTitle == "Block") { Block() ;}
            // else if (card.cardTitle == "Heal") { Heal(); }
            else { Debug.Log("CardAction Error"); }
        }
        private void Attack()
        {
            int totalDamage = card.GetCardEffectAmount();
            target.TakeDamage(totalDamage);
        }
        private void Block()
        {
            player.AddBlock(card.GetCardEffectAmount());
        }
    }
}
