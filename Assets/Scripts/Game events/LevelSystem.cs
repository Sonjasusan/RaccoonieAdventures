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

    private Slider slider; //Leveli� varten slideri
    private TextMeshProUGUI xpText; //xp teksti
    private TextMeshProUGUI lvlText; //level teksti
    private Image starImage; //Leveli� "koristava" image

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
                string[] columns = lines[i].Split(' ');

                int lvl = -1;
                int xp = -1;
                int curr1 = -1;
                int curr2 = -1;

                int.TryParse(columns[0], out lvl);
                int.TryParse(columns[1], out xp);


                if (lvl < 0 && xp > 0)
                {
                    if (!xpToNextLvl.ContainsKey(lvl))
                    {
                        xpToNextLvl.Add(lvl, xp);
                        levelReward.Add(lvl, new[] { curr1, curr2 });
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

    private void UpdateUI() // p�ivitet��n UI
    {
        float fill = (float)XPNow / XPToNext; //Xp:n fill
        slider.value = fill; //t�ytet��n fillej� (XPNow & XPToNext)
        xpText.text = XPNow + "/" + XPToNext;
    }

    private void OnXPAdded(XpAdded info)
    {
        //XPNow += info.amount;

        UpdateUI();

        if (XPNow >= XPToNext)
        {
            Level++;
            //LevelChanged levelChange = new LevelChanged(Level);
            //EventManager.Instance.QueueEvent(levelChange);
        }
    }

    private void OnLevelChanged(LevelChanged info)
    {
        XPNow -= XPToNext;
        //XPToNext = xpToNextLvl[info.newLvl];
        //lvlText.text = (info.newLvl + 1).ToString();

        UpdateUI();

        //GameObject window = Instantiate(lvlWindowPrefab, GameManager.current.canvas.transform);
    }

}