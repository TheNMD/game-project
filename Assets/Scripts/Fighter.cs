// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace SlayTheHaunted
// {
// public class Fighter : MonoBehaviour
// {
//     public int currentHealth;
//     public int maxHealth;
//     public int currentBlock = 0;
//     public FighterHealthBar fighterHealthBar;

//     [Header("Buffs")]
//     public Buff vulnerable;
//     public Buff weak;
//     public Buff strength;
//     public Buff ritual;
//     public Buff enrage;
//     public GameObject buffPrefab;
//     public Transform buffParent;
//     public bool isPlayer;
//     Enemy enemy;
//     BattleSceneManager battleSceneManager;
//     GameManager gameManager;
//     public GameObject damageIndicator;

//     private void Awake()
//     {
//         enemy = GetComponent<Enemy>();
//         battleSceneManager = FindObjectOfType<BattleSceneManager>();
//         gameManager = FindObjectOfType<GameManager>();

//         currentHealth = maxHealth;
//         fighterHealthBar.healthSlider.maxValue = maxHealth;
//         fighterHealthBar.DisplayHealth(currentHealth);
//         if(isPlayer)
//             gameManager.DisplayHealth(currentHealth, currentHealth);

//     }
// 	public void TakeDamage(int amount)
//     {
//         if(currentBlock>0)
//             amount = BlockDamage(amount);

//         if(enemy!=null&&enemy.wiggler&&currentHealth== maxHealth)
//             enemy.CurlUP();

//         Debug.Log($"dealt {amount} damage");

//         DamageIndicator di = Instantiate(damageIndicator, this.transform).GetComponent<DamageIndicator>();
//         di.DisplayDamage(amount);
//         Destroy(di, 2f);

//         currentHealth-=amount;
//         UpdateHealthUI(currentHealth);

//         if(currentHealth<=0)
//         {
//             if(enemy!=null)
//                 battleSceneManager.EndFight(true);
//             else
//                 battleSceneManager.EndFight(false);
            
//             Destroy(gameObject);
//         }
//     }
//     public void AddBlock(int amount)
//     {
//         currentBlock+=amount;
//         fighterHealthBar.DisplayBlock(currentBlock);
//     }
//     private void Die()
//     {
//         this.gameObject.SetActive(false);
//     }
//     private int BlockDamage(int amount)
//     {
//         if(currentBlock>=amount)
//         {
//             //block all
//             currentBlock-=amount;
//             amount = 0;
//         }
//         else
//         {
//             //cant block all
//             amount-=currentBlock;
//             currentBlock=0;
//         }

//         fighterHealthBar.DisplayBlock(currentBlock);
//         return amount;
//     }
   


// }
// }