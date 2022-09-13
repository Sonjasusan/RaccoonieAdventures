using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //Varmistetaan ett‰ NavMeshAgent on aina

public class PlayerController : MonoBehaviour
{
    //Liikkumista varten (+ NavMeshAgent)
    NavMeshAgent agent;


    //Raycastia varten
    public LayerMask movementMask;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Haetaan NavMeshAgent -komponentti
        cam = Camera.main; //Kameran m‰‰ritys
        
    }

    // Update is called once per frame
    void Update()
    {
        //Jos pelaaja klikkaa hiirell‰
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
                MoveToPoint(hit.point);
                //Pelaaja pois objectista -> esim klikkasi sient‰, muttei keskity siihen

            }
        }

        //Hiiren kakkos klikki
        if (Input.GetMouseButton(1)) //1 = left-klikki
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Jos klikki osuu johonkin (esim puuhun)
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Katsotaan osuttiinko interactableen - jos osuttiin keskityt‰‰n (set focus) siihen

            }
        }

    }

    //Liikkuminen NavMeshAgentilla
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
