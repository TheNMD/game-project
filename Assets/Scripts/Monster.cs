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

        // MonsterStats
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
                default:
                    Debug.Log("MonsterStats Error");
                    break;
            }
            
            UpdateUI();
        }
        void UpdateUI()
        {
            healthText.text = health.ToString();
            shieldText.text = shield.ToString();
        }
    }
}