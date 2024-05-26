using UnityEngine;
using UnityEngine.UI;

public class MenuSwitcher : MonoBehaviour
{
    public Image MenuStart;
    public Image MenuFight;
    public Image MenuVictory;
    public Image MenuDefeat;    
    public Image MenuCredits;        

    void Start()
    {
        MenuStart.gameObject.SetActive(true);
        MenuFight.gameObject.SetActive(false);
        MenuVictory.gameObject.SetActive(false);
        MenuDefeat.gameObject.SetActive(false);
        MenuCredits.gameObject.SetActive(false);
    }

    public void StartToFight()
    {
        MenuStart.gameObject.SetActive(false);
        MenuFight.gameObject.SetActive(true);
    }

    public void FightToStart()
    {
        MenuFight.gameObject.SetActive(false);
        MenuStart.gameObject.SetActive(true);
    }

    public void VictoryToStart()
    {
        MenuVictory.gameObject.SetActive(false);
        MenuStart.gameObject.SetActive(true);
    }

    public void DefeatToStart()
    {
        MenuDefeat.gameObject.SetActive(false);
        MenuStart.gameObject.SetActive(true);
    }

    public void StartToCredit()
    {
        MenuStart.gameObject.SetActive(false);
        MenuCredits.gameObject.SetActive(true);
    }

    public void CreditToStart()
    {
        MenuCredits.gameObject.SetActive(false);
        MenuStart.gameObject.SetActive(true);
    }
}
