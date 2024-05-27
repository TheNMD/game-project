using UnityEngine;
using UnityEngine.UI;

namespace SlayTheHaunted
{
    public class MenuSwitcher : MonoBehaviour
    {
        public Image menuStart;
        public Image menuFight;
        public Image menuVictory;
        public Image menuDefeat;    
        public Image menuCredits;        

        void Start()
        {
            menuStart.gameObject.SetActive(true);
            menuFight.gameObject.SetActive(false);
            menuVictory.gameObject.SetActive(false);
            menuDefeat.gameObject.SetActive(false);
            menuCredits.gameObject.SetActive(false);
        }

        public void StartToFight()
        {
            menuStart.gameObject.SetActive(false);
            menuFight.gameObject.SetActive(true);
        }

        public void FightToStart()
        {
            menuFight.gameObject.SetActive(false);
            menuStart.gameObject.SetActive(true);
        }

        public void VictoryToStart()
        {
            menuVictory.gameObject.SetActive(false);
            menuStart.gameObject.SetActive(true);
        }

        public void DefeatToStart()
        {
            menuDefeat.gameObject.SetActive(false);
            menuStart.gameObject.SetActive(true);
        }

        public void StartToCredit()
        {
            menuStart.gameObject.SetActive(false);
            menuCredits.gameObject.SetActive(true);
        }

        public void CreditToStart()
        {
            menuCredits.gameObject.SetActive(false);
            menuStart.gameObject.SetActive(true);
        }
    }
}

