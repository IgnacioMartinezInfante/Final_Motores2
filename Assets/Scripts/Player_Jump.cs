using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    private Rigidbody rb; // Referencia al componente Rigidbody del jugador
    private bool isGrounded; // Variable para verificar si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody del jugador
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Si se presiona la tecla de espacio y el jugador está en el suelo
        {
            Jump(); // Llamar a la función de salt
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplicar fuerza hacia arriba para simular el salto
        isGrounded = false; // El jugador ya no está en el suelo
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Si colisiona con un objeto etiquetado como "Ground"
        {
            Debug.Log("Está tocando el piso");
            isGrounded = true; // El jugador está en el suelo
        }
    }
}
