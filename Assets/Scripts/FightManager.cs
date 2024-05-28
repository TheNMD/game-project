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
        public int round;
        public TextMeshProUGUI roundText;
        public string turn;
        public TextMeshProUGUI turnText;
        public Button doneButton;
        
        [Header("Player")]
        public Player player;
        
        [Header("Card")]
        public CardSelector cardSelector;

        [Header("Monster")]
        public Monster monster;

        private void Awake()
        {   
            round = 1;
            turn = "Player";
            UpdateUI();
            PlayerTurn();
        }
        public void PlayerTurn()
        {

        }
        public void MonsterTurn()
        {
            
        }
        public void ChangeTurn()
        {
            turn = "Monster";
            UpdateUI();
            doneButton.interactable = false;
            // TODO MonsterAction
            MonsterTurn();
            doneButton.interactable = true;
            round += 1;
            turn = "Player";
            UpdateUI();
            PlayerTurn();
        }
        void UpdateUI() 
        { 
            roundText.text = "Round:   " + round.ToString();
            turnText.text = turn.ToString() + "'s Turn"; 
        }
    }
}