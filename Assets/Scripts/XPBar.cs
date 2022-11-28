using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public XPManager xpManager; //viitataan xpmanageriin, jotta saataisiin xp:hen kiinni slideri
    private Slider slider;

    public float FillSpeed = 0.5f; //täyttönopeus
    public float target = 0;

    private void Awake()
    {
        slider= GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < target)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public void IncrementXPProg()
    {
        var xpPercent = xpManager.targetXp / xpManager.currentXP; 
        slider.value = xpPercent;

    }
}
