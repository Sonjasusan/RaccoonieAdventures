using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameEvent;

public class CurrencySystem : MonoBehaviour
{
  private static Dictionary<CurrencyType,int> currencyAmounts = new Dictionary<CurrencyType,int>();

   [SerializeField] private List<GameObject> texts;
   private static Dictionary<CurrencyType, TextMeshProUGUI> currencyTexts = new Dictionary<CurrencyType, TextMeshProUGUI>();

    private void Awake()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            currencyAmounts.Add((CurrencyType)i, 0);
            currencyTexts.Add((CurrencyType)i, texts[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());

        }
    }

    private void Start()
    {
        EventManager.Instance.AddListener<CurrencyChangedGameEvent>(OnCurrencyChanged);
        EventManager.Instance.AddListener<NotEnoughCurrencyGameEvent>(OnNotEnoughCurrency);

    }

    private void OnCurrencyChanged(CurrencyChangedGameEvent info) //Kun currency muuttuu
    {
        //tallennetaan currency
        currencyAmounts[info.currencyType] += info.amount;
        currencyTexts[info.currencyType].text = currencyAmounts[info.currencyType].ToString();
    }

    private void OnNotEnoughCurrency(NotEnoughCurrencyGameEvent info) //Kun ei ole tarpeeksi
    {
        Debug.Log($"You don't have enough of {info.amount} {info.currencyType}"); //Debugataan message
    }
}

public enum CurrencyType //Tyypit
{
    Coins,
    Crystals
}
