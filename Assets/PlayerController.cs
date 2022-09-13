using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Jos pelaaja klikkaa hiirellä
        if (Input.GetMouseButton(0)) //0 = klikki
        {
            Ray ray= cam.ScreenPointToRay(Input.mousePosition); //castataan raycast klikattuun
            RaycastHit hit; //annetaan raycastin nimeksi hit

            //Jos klikki osuu johonkin (esim puuhun)
            if (Physics.Raycast(ray,out hit,100, movementMask))
            {
                //Tarkistetaan raycastin toiminta
                Debug.Log("Osuttiin:" + hit.collider.name + " "+ hit.point);

                //Liikutetaan pelaaja mihin klikattiin

                //Pelaaja pois objectista -> esim klikkasi sientä, muttei keskity siihen

            }
        }
        
    }
}
