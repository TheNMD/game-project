using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace SlayTheHaunted
{
    public class CardUI : MonoBehaviour
    {
        public Card card;
        public Image cardImage;
        FightManager fightManager;
        Animator animator;
        private void Awake()
        {
            fightManager = FindObjectOfType<FightManager>();
            animator = GetComponent<Animator>();
        }
        // private void OnEnable() { animator.Play("HoverOffCard"); }
        public void LoadCard(Sprite image)
        {
            // gameObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            cardImage.sprite = image;
        }
        public void SelectCard()
        {
            Debug.Log("Card is selected");
            fightManager.selectedCard = this;
        }
        public void DeselectCard()
        {
            Debug.Log("Card is deselected");
            fightManager.selectedCard = null;
            animator.Play("HoverOffCard");
        }
        public void HoverCard()
        {
            if(fightManager.selectedCard == null) { animator.Play("Hover"); }
        }
        public void DropCard()
        {
            if(fightManager.selectedCard == null) { animator.Play("Idle"); }
        }
        // public void HandleEndDrag()
        // {
        //     fightManager.PlayCard(this);
        //     animator.Play("HoverOffCard");
        // }
    }
}