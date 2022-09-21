using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rajapinta, jonka avulla voidaa luoda useita eri Interaction skriptej�
/// K�ytt�m�ll� rajapintaa esimerkiksi GetComponent toiminnolla voidaan tarkistaa onko
/// Objektissa kiinni skripti� joka hy�dynt�� rajapintaa
/// </summary>
public interface IInteractable
{
    void OnInteract();

    void OnEnterInteract();

    void OnExitInteract();
}
