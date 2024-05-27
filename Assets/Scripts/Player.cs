using UnityEngine;
using TMPro;

namespace SlayTheHaunted
{
    public class Player : MonoBehaviour
    {
        public int health;
        public int shield;
        public int energy;

        public TextMeshProUGUI healthText;
        public TextMeshProUGUI shieldText;
        public TextMeshProUGUI energyText;

        // Enemy enemy;
        // FightManager fightManager;

        private void Awake()
        {
            health = 100;
            shield = 0;
            energy = 3;

            UpdateUI();
        }

        public void SetValue(string stat, int value)
        {
            switch (stat)
            {
                case "health": 
                    health = value;
                    break;
                case "shield": 
                    shield = value;
                    break;
                case "energy": 
                    energy = value;
                    break;
                default:
                    Debug.Log("PlayerStats Error");
                    break;
            }
            UpdateUI();
        }
        void UpdateUI()
        {
            healthText.text = health.ToString();
            shieldText.text = shield.ToString();
            energyText.text = energy.ToString();
        }
    }
}