using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SErialisoitu luokka, jota voidaan k‰ytt‰‰ muuttujana
/// Tarkoituksena korvata perinteinen AudioClip muuttuja
/// T‰m‰n avulla voidaan lis‰t‰ useita eri AudioClippej‰ tiettyyn ‰‰ni effektiin joka halutaan toistaa
/// Esim: Sen sijaan ett‰ asessa on yksi tietty ampumis ‰‰ni voidaan lis‰t‰ useita ja toistaa satunnaisesti jokin niist‰
/// </summary>
[System.Serializable]
public class SoundEffect
{
    public float volume = 0.5f;
    public float spatialBlend = 0f; // kuuluuko ‰‰ni 2D vai 3D maailmassa
    public AudioClip[] clips;

    /// <summary>
    /// Haetaan random clip listalta
    /// </summary>
    /// <returns></returns>
    public AudioClip GetRandomClip()
    {
        if (clips.Length == 0)
            return null;

        int rand = Random.Range(0, clips.Length);

        return clips[rand];
    }
}
