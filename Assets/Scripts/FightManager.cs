using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace SlayTheHaunted
{
    public class FightManager : MonoBehaviour
    {
        [Header("Global")]
        public int turnCount = 0;
        public TextMeshProUGUI turnCountText;
        public bool playerTurn = true;
        public Button doneButton;
        
        [Header("Player")]
        public Player player;
        
        [Header("Card")]
        public CardSelector cardSelector;

        [Header("Monster")]
        public Monster monster;

        private void Awake()
        {   

        }
        public void ChangeTurn()
        {
            turnCount += 1;
            doneButton.interactable = false;
            // TODO MonsterAction
            doneButton.interactable = true;
            
            UpdateUI();
        }
        void UpdateUI() { turnCountText.text = turnCount.ToString(); }
    }
}