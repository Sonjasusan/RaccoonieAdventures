using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    public class ItemCollector : MonoBehaviour
    {
        //[SerializeField] private Text cherriesText, diamondsText;
        //public int cherries;
        public int diamonds;

        //[SerializeField] private AudioSource collectionSoundEffect;

     
        private void Start()
        {
            //diamondsText.enabled = false; <- Myˆhemp‰‰ teksti‰ varten
        }

    

        private void OnTriggerEnter(Collider collision)
        {

            if (collision.gameObject.CompareTag("Diamond")) //Jos tagi "Diamond"
            {
                /*collectionSoundEffect.Play();*/ //soitetaan soundefecti -> Ei viel‰ ‰‰ni‰
                Destroy(collision.gameObject); //tuhotaan se (eli ker‰t‰‰n)
                GameManager.diamonds++;
                Debug.Log("Diamond collected"); //katsotaan loggaamalla ett‰ toimii
            }

        }
    }
