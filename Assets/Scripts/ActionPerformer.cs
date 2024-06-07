
using UnityEngine;

namespace SlayTheHaunted
{
    public class ActionPerformer : MonoBehaviour
    {
        public Player player;
        public Monster monster;
        private void Awake()
        {
            player = FindObjectOfType<Player>();
            monster = FindObjectOfType<Monster>();
        }
        public void PerformAction(string name, string target, int value)
        {
            switch (name)
            {
                case "LAttack":
                    Attack(target, value);
                    break;
                case "HAttack":
                    Attack(target, value);
                    break;
                case "Defend":
                    Block(target, value);
                    break;
            }
        }
        private void Attack(string target, int value)
        {   
            if (target == "Monster") { monster.TakeDamage(value); }
            else if (target == "Player") { player.TakeDamage(value); }
        }
        private void Block(string target, int value)
        {
            if (target == "Monster") { player.AddBlock(value); }
            else if (target == "Player") { monster.AddBlock(value); }
        }
    }
}
