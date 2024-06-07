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
        public string turn;
        public TextMeshProUGUI turnText;
        public Button doneButton;
        public ActionPerformer performer;
        public MenuSwitcher menuSwitcher;

        [Header("Player")]
        public Player player;
        List<Card> playerHand;
        List<CardUI> playerHandUI;

        [Header("Card")]
        public CardSelector cardSelector;
        public CardUI selectedCard;

        [Header("Monster")]
        public Monster monster;
        public List<string> monsterAction;

        private void Awake()
        {   
            menuSwitcher = FindObjectOfType<MenuSwitcher>();
            performer = FindObjectOfType<ActionPerformer>();
            player = FindObjectOfType<Player>();
            cardSelector = FindObjectOfType<CardSelector>();
            monster = FindObjectOfType<Monster>();
            
            round = 1;
            turn = "Player";
            UpdateUI();
            MonsterIntention();
            PlayerTurn();
        }
        public void PlayerTurn()
        {
            player.ReEnergize();
            // player.DepleteBlock();
            cardSelector.DrawCard();
            playerHand = cardSelector.GetHand();
            playerHandUI = cardSelector.GetHandUI(playerHand);
        }
        public void MonsterIntention()
        {
            monsterAction = monster.DecideAction();
        }
        public void MonsterTurn()
        {
            // monster.DepleteBlock();
            performer.PerformAction(monsterAction[0], "Player", int.Parse(monsterAction[1]));
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
            turn = "Monster";
            UpdateUI();
            doneButton.interactable = false;
            foreach (CardUI cardUI in playerHandUI)
            {
                cardSelector.RemoveCard();
                cardUI.gameObject.SetActive(false);
            }
            MonsterTurn();
            if (player.dead) 
            { 
                ResetGame();
                menuSwitcher.FightToDefeat(); 
            }
            doneButton.interactable = true;
            round += 1;
            turn = "Player";
            UpdateUI();
            MonsterIntention();
            PlayerTurn();
            if (monster.dead) 
            { 
                ResetGame();
                menuSwitcher.FightToVictory(); 
            }
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
            turn = "Player";
            UpdateUI();
            MonsterIntention();
            PlayerTurn();
        }
        void UpdateUI() 
        { 
            roundText.text = "Round:   " + round.ToString();
            turnText.text = turn.ToString() + "'s Turn"; 
        }
    }
}