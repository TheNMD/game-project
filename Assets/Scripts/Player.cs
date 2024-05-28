using UnityEngine;
using TMPro;

namespace SlayTheHaunted
{
    public class Player : MonoBehaviour
    {
        public int health;
        public int shield;
        public int energy;
        public bool dead;

        public TextMeshProUGUI healthText;
        public TextMeshProUGUI shieldText;
        public TextMeshProUGUI energyText;

        private void Awake()
        {
            health = 100;
            shield = 0;
            energy = 3;
            dead = false;
            UpdateUI();
        }
        public void TakeDamage(int amount)
        {
            if(shield > 0) { amount = BlockDamage(amount); }
            health -= amount;
            Debug.Log($"Player received {amount} damage!");
            if (health <= 0) 
            {
                health = 0; 
                dead = true;
                Debug.Log("Player is dead!");
            }
            UpdateUI();
        }
        private int BlockDamage(int amount)
        {
            // Block all
            if(shield >= amount)
            {
                shield -= amount;
                amount = 0;
            }
            // Can't block all
            else
            {
                amount -= shield;
                shield = 0;
            }
            return amount;
        }
        // Update PlayerStats UI
        void UpdateUI()
        {
            healthText.text = health.ToString();
            shieldText.text = shield.ToString();
            energyText.text = energy.ToString();
        }
    }
}