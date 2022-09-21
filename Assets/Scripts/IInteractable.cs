using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rajapinta, jonka avulla voidaa luoda useita eri Interaction skriptejä
/// Käyttämällä rajapintaa esimerkiksi GetComponent toiminnolla voidaan tarkistaa onko
/// Objektissa kiinni skriptiä joka hyödyntää rajapintaa
/// </summary>
public interface IInteractable
{
    void OnInteract();

    void OnEnterInteract();

    void OnExitInteract();
}
