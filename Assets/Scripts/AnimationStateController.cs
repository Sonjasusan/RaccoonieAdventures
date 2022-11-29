using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        //Debug.Log(animator);
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        //bool isJumping = animator.GetBool(isJumpingHash);
        //bool jumpPressed = Input.GetKey("space");
        bool forwardPressed = Input.GetKey("w");
        //bool arrowPressed = Input.GetKeyDown(KeyCode.UpArrow);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //Jos pelaaja painaa w:t‰
        if (isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true); //laitetaan animaattorissa boolean "isWalking" trueksi (koska k‰vell‰‰n)
        }

        ////Jos liikutaan nuolin‰pp‰imell‰
        //if (isWalking && arrowPressed)
        //{
        //    animator.SetBool(isWalkingHash, true); //laitetaan animaattorissa boolean "isWalking" trueksi (koska k‰vell‰‰n)

        //}

        //Jos pelaaja ei paina w:t‰
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false); //laitetaan animaattorissa boolean "isWalking" falseksi (koska ei k‰vell‰)
        }

        // //Jos pelaaja ei paina nuolin‰pp‰int‰
        //if (isWalking && !arrowPressed)
        //{
        //    animator.SetBool(isWalkingHash, false); //laitetaan animaattorissa boolean "isWalking" falseksi (koska ei k‰vell‰)
        //}

        //JUOKSU OSIO

        //jos pelaaja k‰velee ja paina leftshifti‰             
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true); //laitetaan animaattorissa boolean "isRunning" trueksi (koska juostaan)
        }

        //Jos pelaaja lopettaa k‰velyn tai juoksun
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false); //laitetaan animaattorissa boolean "isRunning" falseksi (koska ei juosta tai k‰vell‰)
            Debug.Log(animator);
        }

        //if (isJumping && jumpPressed)
        //{
        //    animator.SetBool(isJumpingHash, true);
        //    Debug.Log("jumping");
        //}
    }
}
