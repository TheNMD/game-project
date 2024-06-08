using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

namespace SlayTheHaunted
{
    public class FightManager : MonoBehaviour
    {
        [Header("Global")]
        public int round;
        public TextMeshProUGUI roundText;
        public TextMeshProUGUI turnText;
        public Button doneButton;
        public ActionPerformer performer;
        public MenuSwitcher menuSwitcher;

        [Header("Stats")]
        public int maxEnergy = 3;
        public Turn turn;
        public enum Turn {Player,Monster};
        
        [Header("Player")]
        public Player player;
        List<Card> playerHand;
        List<CardUI> playerHandUI;

        [Header("Card")]
        public CardSelector cardSelector;
        public CardUI selectedCard;

        [Header("Monster")]
        public Monster monster;
        public Animator banner;
        public List<string> monsterAction;

        private void Awake()
        {   
            menuSwitcher = FindObjectOfType<MenuSwitcher>();
            performer = FindObjectOfType<ActionPerformer>();
            player = FindObjectOfType<Player>();
            cardSelector = FindObjectOfType<CardSelector>();
            monster = FindObjectOfType<Monster>();
            
            round = 1;
            // Set player turn
            turn = Turn.Player;
            UpdateUI();
            MonsterIntention();
            PlayerTurn();
        }
        public void PlayerTurn()
        {
            // Reset player stats
            player.ReEnergize();
            // player.DepleteBlock();

            // Draw cards
            cardSelector.DrawCard();
            playerHand = cardSelector.GetHand();
            playerHandUI = cardSelector.GetHandUI(playerHand);

            for (int i = 0; i < playerHand.Count; i++) 
            { 
                Debug.Log($"Card {i + 1}: {playerHand[i].cardTitle}"); 
            }

            // doneButton.onClick.AddListener(ChangeTurn);
        }
        public void MonsterTurn()
        {
            // Reset monster stats
            monster.DepleteBlock();

            Debug.Log("Monster is attacking...");
            performer.PerformAction(monsterAction[0], "Player", int.Parse(monsterAction[1]));

            ChangeTurn();
        }
        public void PlayCard(CardUI cardUI)
        {
            if(player.energy < cardUI.cardContent.cardCost) 
            { 
                Debug.Log("Not enough energy to play!");
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
            // Player turn to monster turn
            if(turn==Turn.Player)
            {
                Debug.Log("Player Turn Over");

                // Update game UI
                turn = Turn.Monster;
                UpdateUI();
                doneButton.interactable = false;

                // Discard cards in current hand
                foreach (CardUI cardUI in playerHandUI)
                {
                    cardSelector.RemoveCard();
                    cardUI.gameObject.SetActive(false);
                }

                // MonsterAction
                MonsterTurn();

                // Check if player is dead
                if (player.dead) 
                { 
                    ResetGame();
                    menuSwitcher.FightToDefeat(); 
                }
            }
            else if(turn==Turn.Monster)
            // Monster turn to player turn
            {
                Debug.Log("Monster Turn Over");

                // Monster display intent
                MonsterIntention();

                // Reset player stats
                player.shield=0;
                // player.fighterHealthBar.DisplayBlock(0);
                player.energy=maxEnergy;
                Debug.Log("Player energy: " + player.energy.ToString());

                // Update game UI
                round += 1;
                turn = Turn.Player;
                UpdateUI();
                doneButton.interactable = true;

                // PlayerAction
                PlayerTurn();

                // Check if monster is dead
                if (monster.dead) 
                { 
                    ResetGame();
                    menuSwitcher.FightToVictory(); 
                }
            }
        }
        public void MonsterIntention()
        {
            monsterAction = monster.DecideAction();
        }
        public void ResetGame()
        {
            player.health = 50;
            player.shield = 0;
            player.dead = false;
            player.UpdateUI();

            playerHand = new List<Card> {};
            playerHandUI = new List<CardUI> {};

            monster.health = 150;
            monster.shield = 0;
            monster.dead = false;
            monster.UpdateUI();
            
            cardSelector.ResetCard();

            round = 0;
            turn = Turn.Player;
            UpdateUI();
            MonsterIntention();
            PlayerTurn();
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