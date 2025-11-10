using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreInGame : MonoBehaviour
{
    [SerializeField] private Button buttonPlus;
    [SerializeField] private Button buttonLess;
    [SerializeField] private Button buttonBuy;
    [SerializeField] private TMP_Text textAmount;
    int amount = 0;

    void Start()
    {
        buttonPlus.onClick.AddListener(AmountPlus);
        buttonLess.onClick.AddListener(AmountLess);
        buttonBuy.onClick.AddListener(Buy);
        CheckAmount();
    }

    public void AmountPlus() 
    {
        amount++;
        DisplayAmount();
        CheckAmount();
    }

    public void AmountLess()
    {
        amount--;
        DisplayAmount();
        CheckAmount();
    }

    private void CheckAmount() 
    {
        buttonLess.interactable = !(amount <= 0);
        buttonPlus.interactable = !(amount > 20);
    }

    private void DisplayAmount() => textAmount.text = amount.ToString();

    private void Buy()
    {
        print($"Haz comprado {amount} pescaditos");
    }
}
