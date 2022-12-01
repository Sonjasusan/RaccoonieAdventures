using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void QuitClick()
    {
        Debug.Log("QUIT"); //konsoliin viesti lopetuksesta
        Application.Quit();
    }

}
