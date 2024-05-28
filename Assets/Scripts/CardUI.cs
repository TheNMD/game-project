// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using System.Collections;
// using System.Collections.Generic;

// namespace SlayTheHaunted
// {
//     public class CardUI : MonoBehaviour
//     {
//         public Card card;
//         public TMP_Text cardTitleText;
//         public TMP_Text cardDescriptionText;
//         public TMP_Text cardCostText;
//         public Image cardImage;
//         public GameObject discardEffect;
//         FightManager fightManager;
//         Animator animator;
//         private void Awake()
//         {
//             fightManager = FindObjectOfType<FightManager>();
//             animator = GetComponent<Animator>();
//         }
//         private void OnEnable() { animator.Play("HoverOffCard"); }
//         public void LoadCard(Card _card)
//         {
//             card = _card;
//             gameObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
//             cardTitleText.text = card.cardTitle;
//             cardDescriptionText.text = card.GetCardDescriptionAmount();
//             cardCostText.text = card.GetCardCostAmount().ToString();
//             cardImage.sprite = card.cardIcon;
//         }
//         public void SelectCard()
//         {
//             Debug.Log("Card is selected");
//             fightManager.selectedCard = this;
//         }
//         public void DeselectCard()
//         {
//             Debug.Log("Card is deselected");
//             fightManager.selectedCard = null;
//             animator.Play("HoverOffCard");
//         }
//         public void HoverCard()
//         {
//             if(fightManager.selectedCard == null) { animator.Play("HoverOnCard"); }
//         }
//         public void DropCard()
//         {
//             if(fightManager.selectedCard == null) { animator.Play("HoverOffCard"); }
//         }
//         public void HandleEndDrag()
//         {
//             if(fightManager.player.energy < card.GetCardCostAmount())
//                 return;

//             if(card.cardType==Card.CardType.Attack)
//             {
//                 fightManager.PlayCard(this);
//                 animator.Play("HoverOffCard");
//             }
//             else if(card.cardType!=Card.CardType.Attack)
//             {
//                 animator.Play("HoverOffCard");
//                 fightManager.PlayCard(this);
//             }
//         }
//     }
// }