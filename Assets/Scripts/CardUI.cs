using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace SlayTheHaunted
{
    public class CardUI : MonoBehaviour
    {
        public Card cardContent;
        public int cardIdx;
        public Image cardImage;
        FightManager fightManager;
        Animator animator;
        private void Awake()
        {
            fightManager = FindObjectOfType<FightManager>();
            animator = GetComponent<Animator>();
        }
        public void LoadCard(int idx, Card content, Sprite image)
        {
            gameObject.GetComponent<RectTransform>().localScale=new Vector3(1,1,1);
            gameObject.SetActive(true);
            cardIdx = idx;
            cardContent = content;
            cardImage.sprite = image;
        }
        public void SelectCard()
        {
            // Debug.Log($"Card {cardIdx} is selected");
            fightManager.selectedCard = this;
            animator.Play("Select");
        }
        public void DeselectCard()
        {
            // Debug.Log($"Card {cardIdx} is deselected");
            fightManager.selectedCard = null;
            animator.Play("Hover");
        }
        public void HoverOnCard()
        {
            if(fightManager.selectedCard == null) { animator.Play("Hover"); }
        }
        public void HoverOffCard()
        {
            if(fightManager.selectedCard == null) { animator.Play("Idle"); }
        }
        public void HandleDrag()
        {

        }
        public void HandleEndDrag()
        {

            fightManager.PlayCard(this);
            animator.Play("Idle");
        }
    }
}