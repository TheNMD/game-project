using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlayTheHaunted
{
public class FightManager : MonoBehaviour
{

    [Header("Cards")]
    public List<Card> cardsDeck = new List<Card>();
    public List<Card> cardsInHand = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public CardUI selectedCard;
    public List<CardUI> cardsInHandGameObjects = new List<CardUI>();

    [Header("Stats")]
    public Fighter cardTarget;
    public Fighter player;
    public int energy;
    public int drawAmount = 5;
    public Turn turn;
    public enum Turn {Player, Enemy};

    [Header("UI")]
    public TextMeshProUGUI drawPileCountText;
    public TextMeshProUGUI discardPileCountText;
    public TextMeshProUGUI energyText;
    public Transform topParent;
    public Transform enemyParent;
    
    // [Header("Enemies")]
    // public List<Enemy> enemies = new List<Enemy>();
    // List<Fighter> enemyFighters = new List<Fighter>();
    // public GameObject[] possibleEnemies;


    CardActions cardActions;
    PlayerStatsUI playerStatsUI;
    public Animator banner;
    public TMP_Text turnText;
    public GameObject gameover;

}
}