using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRB : MonoBehaviour
{
    public float speed = 10; // Pelaajan nopeus
    public float jumpForce = 10; // Pelaajan hypyn voima
    public float rotationSpeed = 200;

    private Vector3 playerInput; // pelaajan input
    private Rigidbody rb; // Rigidbody referenssi

    bool isGrounded = false; //pelaajan tarkistus, onko se maassa vai ei
                             //(Rigidbody liikkumisessa t�h�n ei ole automaattista toimintoa, kuten Character Controllerissa)

    // Start is called before the first frame update
    void Start()
    {
        // haetaan t�st� objektista rigidbody komponentti talteen
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // K��nnet��n pelaajaa transformin Rotate toiminnolla, pelk�st��n Horizontal inputin mukaan
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0));

        // transform.forward toiminnolla haetaan pelaajan "Local" suunta, eli sinine akseli Scene ikkunassa
        // T�m�n avulla pelaaja k�velee aina suoraan sinnep�in minne katsoo
        playerInput = transform.forward * Input.GetAxis("Vertical") * speed;// <- speed
        playerInput.y = rb.velocity.y; // y-arvoksi asetetaan Rigidbodyn velocity y, joka vastaa painovoimaa

        // Tarkistus, jos pelaajan y-velocity on -0.01 ja 0.01 v�lill�
        if (rb.velocity.y <= 0.01f && rb.velocity.y >= -0.01f)
        {
            // jos tosi, isGrounded => true.
            isGrounded = true;
        } 
        else
        {
            // Jos ep�tosi, pelaaja ei ole maassa
            isGrounded = false;
        }

        // Kun pelaaja on maassa ja painaa Space -> hyp�t��n AddForce toiminnon avulla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdatessa liikutetaan pelaajaa velocityn avulla.
        // Kaikki Fysiikkaan liittyv�t asiat lis�t��n FixedUpdate -metodiin
        rb.velocity = playerInput;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
        }
    }
}
