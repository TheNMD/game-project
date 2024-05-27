using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlayTheHaunted
{
    public class Fighter : MonoBehaviour
    {
        public int currentHealth;
        public int maxHealth;
        public int currentBlock = 0;

        public bool isPlayer;
        // Enemy enemy;
        FightManager fightManager;
        public GameObject damageIndicator;

        private void Awake()
        {
            // enemy = GetComponent<Enemy>();
            fightManager = FindObjectOfType<FightManager>();

            currentHealth = maxHealth;

        }
        public void TakeDamage(int amount)
        {
            if(currentBlock>0)
                amount = BlockDamage(amount);

            Debug.Log($"dealt {amount} damage");

            currentHealth-=amount;
            UpdateHealthUI(currentHealth);

            // if(currentHealth<=0)
            // {
            //     if(enemy != null)
            //         fightManager.EndFight(true);
            //     else
            //         fightManager.EndFight(false);
                
            //     Destroy(gameObject);
            // }
        }
        public void UpdateHealthUI(int newAmount)
        {
            currentHealth = newAmount;
        }
        public void AddBlock(int amount)
        {
            currentBlock += amount;
        }
        private void Die()
        {
            this.gameObject.SetActive(false);
        }
        private int BlockDamage(int amount)
        {
            if(currentBlock >= amount)
            {
                //block all
                currentBlock -= amount;
                amount = 0;
            }
            else
            {
                //cant block all
                amount -= currentBlock;
                currentBlock = 0;
            }

            return amount;
        }
    }
}