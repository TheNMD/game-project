using UnityEngine;
using TMPro;

public class CardSelector : MonoBehaviour
{
    public TextMeshProUGUI DeckText;
    public TextMeshProUGUI DiscardText;

    private int DeckValue;
    private int DiscardValue;

    void Start()
    {
        DeckValue = 30;
        DiscardValue = 0;

        UpdateUI();
    }

    public void SetDeck(int value)
    {
        DeckValue = value;
        UpdateUI();
    }

    public void SetDiscard(int value)
    {
        DiscardValue = value;
        UpdateUI();
    }

    void UpdateUI()
    {
        DeckText.text = DeckValue.ToString();
        DiscardText.text = DiscardValue.ToString();
    }
}
