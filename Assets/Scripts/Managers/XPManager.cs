using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    public TextMeshProUGUI currentXPText, targetXPText, levelText; //xp tekstit (xp.t‰ nyt ja tarvittava m‰‰r‰)
    public int currentXP, targetXp, level; //xp:t numeroina

    //Singleton
    public static XPManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentXPText.text = currentXP.ToString();
        targetXPText.text = targetXp.ToString();
        levelText.text = level.ToString();

    }

    public void AddXP(int xp)
    {
        currentXP += xp;

        //Level up
        if (currentXP >= targetXp)
        {
            currentXP = currentXP - targetXp; //xp nollataan
            level++; // nostetaan leveli‰ yhdell‰
            targetXp += targetXp / 20;


            levelText.text = level.ToString(); //p‰ivitet‰‰n uusi leveli tekstikentt‰‰n
            targetXPText.text = targetXp.ToString();
        }


        currentXPText.text = currentXP.ToString();
    }
}
