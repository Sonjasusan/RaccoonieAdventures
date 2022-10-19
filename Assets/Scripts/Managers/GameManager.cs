using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : Singleton<GameManager>
{
    public static GameManager gameManager { get; private set; } //staattinen gamemanageri
    public GameObject Player; //player

    public static int diamonds = 0; //timantit


    void Awake()
    {
            if (gameManager != null && gameManager != this) //Jos tehd��n uusi gamemanager
            {
                Destroy(this); //tuhotaan t�m�
            }
            else
            {
                gameManager = this; //Muussa tapauksessa t�� on SE gamemanager
            }

            
            if (diamonds > 1) //jos timantteja on enemm�n kuin 1
            {
                DontDestroyOnLoad(this.gameObject); //ei tuhota ladatessa
            }
        }
    }

