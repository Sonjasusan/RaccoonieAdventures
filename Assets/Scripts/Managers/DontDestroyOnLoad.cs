using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// T‰m‰n skriptin lis‰‰minen objektiin lis‰‰ sen automaattisesti DontDestroyOnLoad scenelle
/// Eli scenelle, jonka sis‰ll‰ olevat objektit ei tuhoudu scenej‰ vaihtaessa
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
