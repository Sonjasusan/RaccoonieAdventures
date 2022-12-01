using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    public UnityEvent GamePaused; //pausetettu peli
    public UnityEvent GameResumed; //palataan pauselta
    private bool isPaused; //boolean onko pausella




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = ! isPaused;

            if (isPaused) //on paussilla
            {
                Time.timeScale = 0; //"j‰‰dytet‰‰n" aika nollaan

                GamePaused.Invoke();
            }
            else
            {
                Time.timeScale = 1;

                GameResumed.Invoke();   
            }
        }
    }
}
