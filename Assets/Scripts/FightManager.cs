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
        
        [Header("Card")]
        public CardSelector cardSelector;
        // public CardUI selectedCard;
        // public List<CardUI> hand = new List<CardUI>();

        [Header("Monster")]
        public Monster monster;

        private void Awake()
        {   
            cardSelector = FindObjectOfType<CardSelector>();
            round = 1;
            turn = "Player";
            UpdateUI();
            PlayerTurn();
        }
        public void PlayerTurn()
        {
            cardSelector.DrawCard();
            List<Card> playerHand = cardSelector.GetHand();
            List<CardUI> playerHandUI = cardSelector.GetHandUI(playerHand);
            for (int i = 0; i < playerHand.Count; i++) 
            { Debug.Log($"Card {i + 1}: {playerHand[i].cardTitle}"); }
        }
        public void MonsterTurn()
        {
            
        }
        // public void DisplayCardInHand(Card card)
        // {
        //     CardUI cardUI = hand[hand.Count - 1];
        //     cardUI.LoadCard(card);
        //     cardUI.gameObject.SetActive(true);
        // }
        // public void PlayCard(CardUI cardUI)
        // {
        //     //Debug.Log("played card");
        //     //GoblinNob is enraged
        //     if(cardUI.card.cardType!=Card.CardType.Attack&&enemies[0].GetComponent<Fighter>().enrage.buffValue>0)
        //         enemies[0].GetComponent<Fighter>().AddBuff(Buff.Type.strength, enemies[0].GetComponent<Fighter>().enrage.buffValue);

        //     cardActions.PerformAction(cardUI.card, cardTarget);

        //     energy-=cardUI.card.GetCardCostAmount();
        //     energyText.text=energy.ToString();

        //     Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
        //     selectedCard = null;
        //     cardUI.gameObject.SetActive(false);
        //     cardsInHand.Remove(cardUI.card);
        //     DiscardCard(cardUI.card);
        // }
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