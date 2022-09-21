using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using NaughtyAttributes;

/// <summary>
/// Yleinen interaction skripti, jonka avulla voidaan toteuttaa eri eventtej‰ eri tarkoituksiin
/// Eritt‰in uudelleenk‰ytett‰v‰ hyvin simppeleille asioille, kuten objektien p‰‰llelaitto ja animaatioiden toisto
/// </summary>
public class BaseInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent interactEvt;
    public UnityEvent onEnterEvt;
    public UnityEvent onExitEvt;


    // Tƒm‰n voi toteuttaa esimerkiksi OnTriggerEnter / OnCollisionEnter metodeissa
    public void OnEnterInteract()
    {
        onEnterEvt.Invoke();
    }

    // Tƒm‰n voi toteuttaa esimerkiksi OnTriggerExi / OnCollisionExit metodeissa
    public void OnExitInteract()
    {
        onExitEvt.Invoke();
    }

    // Tƒm‰n voi toteuttaa esimerkiksi Raycast logiikalla,
    // esim kun pelaaja painaa E -> tarkistaa osuuko nappiin -> jos osuu niin kutsuu t‰t‰
    public void OnInteract()
    {
        interactEvt.Invoke();
    }
}
