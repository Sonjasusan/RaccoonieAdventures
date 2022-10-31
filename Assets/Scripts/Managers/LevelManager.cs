using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manager joka hallinnoi kaikkea leveleihin liittyvi‰ asioita
/// esimerkiksi levelien lataus ja niihin kuuluvat muutokset (esim UI)
/// </summary>
public class LevelManager : Singleton<LevelManager>
{
    public SceneReference MainMenuScene; // MainMenu Scenen tieto
    public Level[] Levels; // Lista eri Pelikentist‰ 

    // Start is called before the first frame update
    void Start()
    {
        LoadMainMenu(); //Pelin alussa menn‰‰n suoraan Main Menuun
    }

    public void LoadMainMenu()
    {
        LoadLevel(MainMenuScene); // Ladataan main menu kutsumalla LoadLevel metodia
    }

    public void LoadLevel(SceneReference scene)
    {
        // Vaihdetaan scene‰
        SceneManager.LoadScene(scene);

        if (scene == MainMenuScene)
        {
            // Jos Scene mihin vaihdettiin on MainMenuScene niin pistet‰‰n MainMenu Paneeli p‰‰lle
            UiManager.Instance.ToggleMainMenuPanel(true);

        }
        else
        {
            // Jos scene mihin vaihdettiin EI ole MainMenuScene niin pistet‰‰n HUD paneeli p‰‰lle
            UiManager.Instance.ToggleMainMenuPanel(false);
        }
    }

    public void LoadLevel(string levelName)
    {
        // K‰yd‰‰n jokainen "Level" listasta "Levels" l‰pi
        foreach (Level level in Levels)
        {
            // Jos nykyisen iteraation levelin nimi on sama kuin haettu nimi
            if (level.levelName == levelName)
            {
                // Ladataan kyseisen leveliin referoitu scene
                LoadLevel(level.scene);
                return;
            }
        }

        Debug.LogError("Leveli‰ " + levelName + " ei lˆytynyt listalta! Tarkista LevelManager!!");
    }
}


/// <summary>
/// Serialisoitu luokka, jonka avulla voidaan luoda "Dictionary" tyylinen lista joka n‰kyy inspektorissa
/// </summary>
[System.Serializable]
public class Level
{
    public string levelName;
    public SceneReference scene;
}