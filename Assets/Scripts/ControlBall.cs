using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{
    public float moveForce = 10f; // Fuerza de movimiento del personaje
    private Rigidbody rb; // Referencia al componente Rigidbody

    void Start()
    {
        // Obtiene el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("El componente Rigidbody no está asignado al GameObject.");
        }
    }

    void FixedUpdate()
    {
        // Obtener la entrada horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Aplicar una fuerza al Rigidbody en los ejes X e Y
        Vector3 force = new Vector3(horizontalInput * moveForce, verticalInput * moveForce, 0f);
        rb.AddForce(force);
    }
}