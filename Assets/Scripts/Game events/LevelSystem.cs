using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int XPNow; //Nykyinen xp
    private int Level; //Nykyinen leveli
    private int XPToNext; // Xp seuraavaan leveliin

    [SerializeField] private GameObject levelPanel; //Levelpaneeli (jossa xp nykyinen level)
    [SerializeField] private GameObject levelWindowPrefab;

    private Slider slider; //Leveliä varten slideri
    private TextMeshProUGUI xpText; //xp teksti
    private TextMeshProUGUI lvlText; //level teksti
    private Image starImage; //Leveliä "koristava" image

    static bool initialized;
    private static Dictionary<int, int> xpToNextLvl = new Dictionary<int, int>();
    private static Dictionary<int, int[]> levelReward = new Dictionary<int, int[]>();


    private void Awake()
    {
        slider = levelPanel.GetComponent<Slider>();
        xpText = levelPanel.transform.Find("XP text").GetComponent<TextMeshProUGUI>();
        starImage = levelPanel.transform.Find("Star").GetComponent<Image>();
        lvlText = starImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (!initialized)
        {
            Initialize();
        }
        xpToNextLvl.TryGetValue(Level, out XPToNext);
    }

    private static void Initialize()
    {
        try
        {
            string path = "levelsXP";
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            string[] lines = textAsset.text.Split('\n');

            xpToNextLvl = new Dictionary<int, int>(lines.Length - 1);

            for (int i = 1; i < lines.Length - 1; i++)
            {

            }
        }

        catch (Exception ex)
        {

            Debug.Log(ex.Message);
        }

        initialized = true;
    }

}
