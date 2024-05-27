using UnityEngine;
using TMPro;

namespace SlayTheHaunted
{
public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI ShieldText;
    public TextMeshProUGUI EnergyText;

    private int HPValue;
    private int ShieldValue;
    private int EnergyValue;

    void Start()
    {
        HPValue = 100;
        ShieldValue = 0;
        EnergyValue = 3;

        UpdateUI();
    }

    public void SetHP(int value)
    {
        HPValue = value;
        UpdateUI();
    }

    public void SetShield(int value)
    {
        ShieldValue = value;
        UpdateUI();
    }

    public void SetEnergy(int value)
    {
        EnergyValue = value;
        UpdateUI();
    }

    void UpdateUI()
    {
        HPText.text = HPValue.ToString();
        ShieldText.text = ShieldValue.ToString();
        EnergyText.text = EnergyValue.ToString();
    }
}
}

