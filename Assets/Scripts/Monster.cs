using UnityEngine;
using TMPro;

namespace SlayTheHaunted
{
    public class Monster : MonoBehaviour
    {
        public string monsterName;
        public int health;
        public int shield;

        public TextMeshProUGUI healthText;
        public TextMeshProUGUI shieldText;

        private void Awake() 
        {
            monsterName = "Ghost";
            health = 30;
            shield = 0;
            UpdateUI();
        }

        // Update MonsterStats UI 
        void UpdateUI()
        {
            healthText.text = health.ToString();
            shieldText.text = shield.ToString();
        }
    }
}