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
        public TextMeshProUGUI turnText;
        public Button doneButton;

        [Header("Stats")]
        public int maxEnergy = 3;
        public Turn turn;
        public enum Turn {Player,Monster};

        [Header("UI")]
        public TMP_Text energyText;
        
        [Header("Player")]
        public Player player;
        
        [Header("Card")]
        public CardSelector cardSelector;
        public CardUI selectedCard;
        // public List<CardUI> hand = new List<CardUI>();

        [Header("Monster")]
        public Monster monster;
        public Animator banner;

        private void Awake()
        {   
            cardSelector = FindObjectOfType<CardSelector>();
            round = 1;
            // Set player turn
            turn = Turn.Player;
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

            doneButton.onClick.AddListener(ChangeTurn);
        }
        public void MonsterTurn()
        {
            // sleep for 1 second
            Debug.Log("Monster is attacking...");
            System.Threading.Thread.Sleep(600);
            Debug.Log("Monster Turn Over");
            ChangeTurn();
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
            // Player turn to monster turn
            if(turn==Turn.Player)
            {
                Debug.Log("Player Turn Over");
                turn = Turn.Monster;
                doneButton.interactable = false;
                UpdateUI();
                // TODO MonsterAction
                MonsterTurn();
            }
            else
            // Monster turn to player turn
            {
                // Monster display intent
                monster.DisplayIntent();
                turn = Turn.Player;

                // Reset player block
                player.shield=0;
                // player.fighterHealthBar.DisplayBlock(0);
                player.energy=maxEnergy;
                energyText.text=player.energy.ToString();

                // Update to player UI
                doneButton.interactable = true;
                round += 1;
                UpdateUI();
                PlayerTurn();
            }
        }
        void UpdateUI() 
        { 
            if(turn == Turn.Player)
            {
                roundText.text = "Round:   " + round.ToString();
            }

            turnText.text = turn.ToString() + "'s Turn";

            // if(turn == Turn.Player)
            // {
            //     banner.Play("bannerIn");
            // } 
            // else if(turn == Turn.Monster)
            // {
            //     banner.Play("bannerOut");
            // }
        }
    }
}