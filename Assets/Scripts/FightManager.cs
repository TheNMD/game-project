using System;
using System.Collections;
using System.Collections.Generic;
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
        List<Card> playerHand;
        List<CardUI> playerHandUI;
        [Header("Card")]
        public CardSelector cardSelector;
        public CardUI selectedCard;

        [Header("Monster")]
        public Monster monster;

        private void Awake()
        {   
            cardSelector = FindObjectOfType<CardSelector>();
            player = FindObjectOfType<Player>();

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
            player.ReEnergize(3);
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
                player.SpendEnergy(cardUI.cardContent.cardCost);
                cardSelector.RemoveCard();
                cardUI.gameObject.SetActive(false);
                selectedCard = null;
            }
            // cardActions.PerformAction(cardUI.card, cardTarget);
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