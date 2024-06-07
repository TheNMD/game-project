using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

namespace SlayTheHaunted
{
    public class Monster : MonoBehaviour
    {
        public string monsterName;
        public int health;
        public int shield;
        public bool dead;
        public List<string> actionList = new List<string> {"LAttack", "LAttack", "LAttack", "LAttack", "LAttack",
                                                           "HAttack", "HAttack", "Defend", "Defend", "Defend"};
        public GameObject lattack;
        public GameObject hattack;
        public GameObject defend;
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI shieldText;

        private void Awake() 
        {
            monsterName = "Ghost";
            health = 150;
            shield = 0;
            dead = false;
            UpdateUI();
        }
        public void DecideAction()
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(actionList.Count);
            string action = actionList[randomIndex];
            switch (action)
            {
                case "LAttack":
                    lattack.SetActive(true);
                    hattack.SetActive(false);
                    defend.SetActive(false);
                    break;
                case "HAttack":
                    lattack.SetActive(false);
                    hattack.SetActive(true);
                    defend.SetActive(false);
                    break;
                case "Defend":
                    lattack.SetActive(false);
                    hattack.SetActive(false);
                    defend.SetActive(true);
                    break;
            }
        }
        public void TakeDamage(int amount)
        {
            if(shield > 0) { amount = BlockDamage(amount); }
            health -= amount;
            Debug.Log($"Monster received {amount} damage!");
            if (health <= 0) 
            {
                health = 0; 
                dead = true;
                Debug.Log($"Monster is dead!");
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
        public void AddBlock(int amount)
        {
            shield += amount;
            UpdateUI();
        }
        public void DepleteBlock()
        {
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