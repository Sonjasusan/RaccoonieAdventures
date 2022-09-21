using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //seurattava kohde -> Playeri

    public Vector3 offset;

    //Kameran zoomi
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    public float pitch = 1f; //Playerin koko

    public float yawSpeed = 100f;

    private void Update()
    {
       currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime; //Jos k‰ytet‰‰n a,d,w -nappeja
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom; //Etsit‰‰n playeri
        transform.LookAt(target.position + Vector3.up * pitch); //Katsotaan playeria

        transform.RotateAround(target.position, Vector3.up, currentYaw); //pyˆritet‰‰n /k‰‰nnet‰‰n kameraa
    }
}
