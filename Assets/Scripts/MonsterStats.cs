using UnityEngine;
using TMPro;

public class MonsterStats : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI ShieldText;

    private int HPValue;
    private int ShieldValue;

    void Start()
    {
        HPValue = 50;
        ShieldValue = 0;

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

    void UpdateUI()
    {
        HPText.text = HPValue.ToString();
        ShieldText.text = ShieldValue.ToString();
    }
}
