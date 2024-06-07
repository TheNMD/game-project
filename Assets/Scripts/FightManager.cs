using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TJ;


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
        public ActionPerformer performer;

        [Header("Player")]
        public Player player;
        List<Card> playerHand;
        List<CardUI> playerHandUI;
        [Header("Card")]
        public CardSelector cardSelector;
        public CardUI selectedCard;
        [Header("Monster")]
        public Monster monster;

        private void Awake()
        {   
            performer = FindObjectOfType<ActionPerformer>();
            player = FindObjectOfType<Player>();
            cardSelector = FindObjectOfType<CardSelector>();
            
            round = 1;
            turn = "Player";
            UpdateUI();
            PlayerTurn();
        }
        public void PlayerTurn()
        {
            cardSelector.DrawCard();
            playerHand = cardSelector.GetHand();
            playerHandUI = cardSelector.GetHandUI(playerHand);
            player.ReEnergize();
            player.DepleteBlock();
        }
        public void MonsterTurn()
        {
            
        }
        public void PlayCard(CardUI cardUI)
        {
            if(player.energy < cardUI.cardContent.cardCost) 
            { 
                Debug.Log($"Not enough energy to play!");
            }
            else
            {
                performer.PerformAction(cardUI.cardContent.cardTitle, "Monster", cardUI.cardContent.cardValue);
                player.SpendEnergy(cardUI.cardContent.cardCost);
                cardSelector.RemoveCard();
                cardUI.gameObject.SetActive(false);
                selectedCard = null;
            }
        }
        public void ChangeTurn()
        {
            turn = "Monster";
            UpdateUI();
            doneButton.interactable = false;
            foreach (CardUI cardUI in playerHandUI)
            {
                cardSelector.RemoveCard();
                cardUI.gameObject.SetActive(false);
            }
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