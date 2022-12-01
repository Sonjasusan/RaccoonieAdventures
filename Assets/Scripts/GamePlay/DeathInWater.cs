using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathInWater : MonoBehaviour

{
    public float gameRestartDelay = 1f; //restartin kesto

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))  //tarkistetaan onko gameobjectissa "Water" tagi
        {
            Debug.Log("You'll die if you touch the water!");
            Invoke("Die", gameRestartDelay);
        }
    }

    private void Die() //"Kuollaan"
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restartaan scene
        SceneManager.LoadScene("GameOver");
    }
}
