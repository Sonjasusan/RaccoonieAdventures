using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameEvent;

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
        // Alla olevat ei toimi (aiheuttaa kaatumisen)
        //slider = levelPanel.GetComponent<Slider>();
        //xpText = levelPanel.transform.Find("XP text").GetComponent<TextMeshProUGUI>();
        //starImage = levelPanel.transform.Find("Star").GetComponent<Image>();
        //lvlText = starImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

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
                string[] columns = lines[i].Split(',');

                int lvl = -1;
                int xp = -1;
                int curr1 = -1;
                int curr2 = -1;

                int.TryParse(columns[0], out lvl);
                int.TryParse(columns[1], out xp);
                int.TryParse(columns[2], out curr1);
                int.TryParse(columns[3], out curr2);
                


                if (lvl < 0 && xp > 0)
                {
                    if (!xpToNextLvl.ContainsKey(lvl))
                    {
                        xpToNextLvl.Add(lvl, xp);
                        levelReward.Add(lvl, new[] {curr1, curr2});
                    }
                }
            }
        }

        catch (Exception ex)
        {

            Debug.Log(ex.Message);
        }

        initialized = true;
    }


    private void Start()
    {
        EventManager.Instance.AddListener<XPAddedGameEvent>(OnXPAdded);
        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);
    }

    private void UpdateUI() // päivitetään UI
    {
        float fill = (float)XPNow / XPToNext; //Xp:n fill
        slider.value = fill; //täytetään fillejä (XPNow & XPToNext)
        xpText.text = XPNow + "/" + XPToNext;
    }

    private void OnXPAdded(XPAddedGameEvent info) //Xp:n lisääminen
    {
        XPNow += info.amount;

        UpdateUI();

        if (XPNow >= XPToNext)
        {
            Level++;
            LevelChangedGameEvent levelChange = new LevelChangedGameEvent(Level);
            EventManager.Instance.QueueEvent(levelChange);
        }
    }

    private void OnLevelChanged(LevelChangedGameEvent info)
    {
        XPNow -= XPToNext;
        XPToNext = xpToNextLvl[info.newLvl];
        lvlText.text = (info.newLvl + 1).ToString();

        UpdateUI();

        GameObject window = Instantiate(levelWindowPrefab, GameManager.gameManager.canvas.transform);

        window.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate
        {
            Destroy(window);
        });
    }

}
