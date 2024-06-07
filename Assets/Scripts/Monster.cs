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
                                                           "LAttack", "LAttack", "LAttack", "HAttack", "HAttack",
                                                           "Defend", "Defend", "Defend", "Defend", "Defend"};
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
        public List<string> DecideAction()
        {
            ShuffleAction(actionList);
            string action = actionList[0];
            string value = "0";
            switch (action)
            {
                case "LAttack":
                    lattack.SetActive(true);
                    hattack.SetActive(false);
                    defend.SetActive(false);
                    value = "15";
                    break;
                case "HAttack":
                    lattack.SetActive(false);
                    hattack.SetActive(true);
                    defend.SetActive(false);
                    value = "30";
                    break;
                case "Defend":
                    lattack.SetActive(false);
                    hattack.SetActive(false);
                    defend.SetActive(true);
                    value = "20";
                    break;
            }
            List<string> monsterIntention = new List<string> {action, value};
            return monsterIntention;
        }
        public static void ShuffleAction<T>(IList<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
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
        public void UpdateUI()
        {
            healthText.text = health.ToString();
            shieldText.text = shield.ToString();
        }
        // Display Intent
        public void DisplayIntent()
        {
            Debug.Log("Monster will attack next turn!");
        }
    }
}