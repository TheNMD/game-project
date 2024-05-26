using UnityEngine;
using TMPro;

public class TurnCounter : MonoBehaviour
{
    public TextMeshProUGUI TurnText;

    private int TurnValue;

    void Start()
    {
        TurnValue = 0;

        UpdateUI();
    }

    public void SetTurn(int value)
    {
        TurnValue = value;
        UpdateUI();
    }

    void UpdateUI()
    {
        TurnText.text = TurnValue.ToString();
    }
}
