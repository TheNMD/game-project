using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SlayTheHaunted
{
    public class FightManager : MonoBehaviour
    {
        [Header("Global")]
        public int turnCount = 0;
        public Turn turn;
        public enum Turn {Player, Enemy};
        
        [Header("Player")]
        public Player player;
        // public Fighter cardTarget;
        
        [Header("Card")]
        public CardSelector cardSelector;

        [Header("Monster")]
        public Monster monster;


        // [Header("UI")]
        // public TextMeshProUGUI drawPileCountText;
        // public TextMeshProUGUI discardPileCountText;
        // public TextMeshProUGUI energyText;
        // // public Transform topParent;
        // // public Transform enemyParent;
        
        // [Header("Enemies")]
        // public List<Enemy> enemies = new List<Enemy>();
        // List<Fighter> enemyFighters = new List<Fighter>();
        // public GameObject[] possibleEnemies;


        // CardAction cardActions;
        // // PlayerStatsUI playerStatsUI;
        // public Animator banner;
        // public TMP_Text turnText;
        // public GameObject gameover;

        private void Awake()
        {   
            // Debug.Log(monsterNames[0]);
        }
    }
}