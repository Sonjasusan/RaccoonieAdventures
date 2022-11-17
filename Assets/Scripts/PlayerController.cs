using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;

    public float speed = 10; // Pelaajan nopeus
    public float jumpForce = 10; // Pelaajan hypyn voima
    public float rotationSpeed = 200;


    //public SoundEffect jumpSE; //Hyppy soundeffect

    [SerializeField] private AudioSource jumpSE; //Hyppy‰‰ni

    public Transform itemDropPoint; //itemin pudotuspointti

    private Vector3 playerInput; // pelaajan input
    private Rigidbody rb; // Rigidbody referenssi


    bool isGrounded = false; //pelaajan tarkistus, onko se maassa vai ei
                             //(Rigidbody liikkumisessa t‰h‰n ei ole automaattista toimintoa, kuten Character Controllerissa)


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Player = this.gameObject;

        // haetaan t‰st‰ objektista rigidbody komponentti talteen
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>(); //Haetaan animaattori komponentti
        //Debug.Log(animator);
        isWalkingHash = Animator.StringToHash("isWalking"); //K‰vely animaatio
        isRunningHash = Animator.StringToHash("isRunning"); //Juoksu animaatio
        isJumpingHash = Animator.StringToHash("isJumping"); //Hyppyanimaatio

    }

    // Update is called once per frame
    void Update()
    {
        bool runPressed = Input.GetKey(KeyCode.LeftShift); //juoksu left shiftill‰


        // K‰‰nnet‰‰n pelaajaa transformin Rotate toiminnolla, pelk‰st‰‰n Horizontal inputin mukaan
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0));

        // transform.forward toiminnolla haetaan pelaajan "Local" suunta, eli sinine akseli Scene ikkunassa
        // T‰m‰n avulla pelaaja k‰velee aina suoraan sinnep‰in minne katsoo
        playerInput = transform.forward * Input.GetAxis("Vertical") * speed;// <- speed
        playerInput.y = rb.velocity.y; // y-arvoksi asetetaan Rigidbodyn velocity y, joka vastaa painovoimaa

       
        // Tarkistus, jos pelaajan y-velocity on -0.01 ja 0.01 v‰lill‰
        if (rb.velocity.y <= 0.01f && rb.velocity.y >= -0.01f)
        {
            // jos tosi, isGrounded => true.
            isGrounded = true;
            animator.SetBool(isJumpingHash, false); //animaattorista isJumping falseksi
        }
        else
        {
            // Jos ep‰tosi, pelaaja ei ole maassa
            isGrounded = false;

        }

        // Kun pelaaja on maassa ja painaa Space -> hyp‰t‰‰n AddForce toiminnon avulla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool(isJumpingHash, true); //animaattorissa isJumping trueksi
            jumpSE.Play(); //Toistetaan hyppy‰‰ni

            rb.AddForce(Vector3.up * jumpForce);
        }

        //Juokseminen
        if (runPressed == true) //jos on painettu juoksunappia (left shift)
        {
            speed = 20; //nostetaan nopeus normi 10:st‰ (annettu ylh‰‰ll‰) 20:een
            animator.SetBool(isRunningHash, true); //laitetaan animaattorista isRunning trueksi
        }
        else
        {
            animator.SetBool(isRunningHash, false); //muussa tapauksessa isRunning on false
        }
      

    }

    private void FixedUpdate()
    {
        // FixedUpdatessa liikutetaan pelaajaa velocityn avulla.
        // Kaikki Fysiikkaan liittyv‰t asiat lis‰t‰‰n FixedUpdate -metodiin
        rb.velocity = playerInput;

        if (speed > 0)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //Kun pelaaja osuu triggeriin, katsotaan onko siin‰ IInteractable rajapintaa, jos on niin toistetaan OnEnterInteract metodi
        if (col.GetComponent<IInteractable>() != null)
        {
            col.GetComponent<IInteractable>().OnEnterInteract();
        }
    }

    void OnTriggerExit(Collider col)
    {
        //Kun pelaaja poistuu triggerist‰, katsotaan onko siin‰ IInteractable rajapintaa, jos on niin toistetaan OnExitInteract metodi
        if (col.GetComponent<IInteractable>() != null)
        {
            col.GetComponent<IInteractable>().OnExitInteract();
        }
    }
}
