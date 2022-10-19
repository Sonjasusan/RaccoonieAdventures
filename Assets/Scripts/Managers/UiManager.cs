using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manager, joka hoitaa kaikki UI:seen liittyv‰t asiat
/// Esimerkiksi Options valikon ja pelin HUD:in
/// </summary>
public class UiManager : Singleton<UiManager>
{
    [Header("Main Menu")]
    public GameObject MainMenuPanel; // Main menu paneeli

    [Header("HUD")]
    public GameObject HUDPanel; // Pelin HUD Paneeli, eli UI:t jotka n‰kyy pelin aikana (healthbar yms.)
    public GameObject inventoryPanel;
    public GameObject UIItemPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        // Pistet‰‰n alussa molemmat pois p‰‰lt‰
        MainMenuPanel.SetActive(false);
        HUDPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    /// <summary>
    /// Vaihdetaan MainMenun ja HUD:in v‰lill‰
    /// Jos true, MainMenu pistet‰‰n p‰‰lle ja HUD Pois p‰‰lt‰. Jos false niin toisinp‰in
    /// </summary>
    /// <param name="t"></param>
    public void ToggleMainMenuPanel(bool t)
    {
        MainMenuPanel.SetActive(t); // jos t = true --> MainMenu p‰‰lle
        HUDPanel.SetActive(!t); // jos t = true --> HUD Pois p‰‰lt‰
    }

    public void ToggleInventoryPanel()
    {
        if (HUDPanel.activeInHierarchy == false)
            return;

        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }

    public void CreateNewUIItem(ItemData data)
    {
        GameObject newItemUI = Instantiate(UIItemPrefab, inventoryPanel.transform);
        //newItemUI.GetComponent<UIItemData>().InitializeItemUI(data);
    }
}