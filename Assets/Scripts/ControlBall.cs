using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    void Update()
    {
        // Obtiene la entrada horizontal (teclas de flecha izquierda/derecha oA/D)
        float moveInput = Input.GetAxis("Horizontal");

        // Calcula el movimiento en el eje X
        Vector3 move = new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;

        // Aplica el movimiento al personaje
        transform.Translate(move);
    }
}
