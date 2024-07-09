using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento del jugador (no usada en este script)
    public float jumpForce = 10f; // Fuerza del salto cuando el jugador se mueve a otra pared
    private int currentWall = 0; // 0 = piso, 1 = pared izquierda, 2 = techo, 3 = pared derecha
    private Rigidbody rb; // Referencia al componente Rigidbody del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene y guarda el componente Rigidbody del jugador
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Si se presiona la tecla A
        {
            MoveToNextWall(-1); // Mueve al jugador a la pared de la izquierda
        }
        if (Input.GetKeyDown(KeyCode.D)) // Si se presiona la tecla D
        {
            MoveToNextWall(1); // Mueve al jugador a la pared de la derecha
        }
    }

    void MoveToNextWall(int direction)
    {
        currentWall = (currentWall + direction + 4) % 4; // Calcula la nueva pared en la que se ubicará el jugador

        // Variables para almacenar la nueva rotación, desplazamiento de posición y dirección de la gravedad
        Vector3 newRotation = Vector3.zero;
        Vector3 newPositionOffset = Vector3.zero;
        Vector3 newGravityDirection = Vector3.down;

        // Ajusta las variables según la pared actual
        switch (currentWall)
        {
            case 0: // piso
                newRotation = new Vector3(0, 0, 0); // Sin rotación
                newGravityDirection = Vector3.down; // Gravedad hacia abajo
                newPositionOffset = new Vector3(0, -transform.position.y, 0); // Ajuste de posición
                break;
            case 1: // pared izquierda
                newRotation = new Vector3(0, 0, 90); // Rotación de 90 grados
                newGravityDirection = Vector3.right; // Gravedad hacia la izquierda
                newPositionOffset = new Vector3(-transform.position.y, 0, 0); // Ajuste de posición
                break;
            case 2: // techo
                newRotation = new Vector3(0, 0, 180); // Rotación de 180 grados
                newGravityDirection = Vector3.up; // Gravedad hacia arriba
                newPositionOffset = new Vector3(0, -transform.position.y, 0); // Ajuste de posición
                break;
            case 3: // pared derecha
                newRotation = new Vector3(0, 0, -90); // Rotación de -90 grados
                newGravityDirection = Vector3.left; // Gravedad hacia la derecha
                newPositionOffset = new Vector3(transform.position.y, 0, 0); // Ajuste de posición
                break;
        }

        transform.rotation = Quaternion.Euler(newRotation); // Aplica la nueva rotación al jugador
        transform.position += newPositionOffset; // Aplica el ajuste de posición al jugador
        Physics.gravity = newGravityDirection * 9.81f; // Cambia la dirección de la gravedad
        rb.velocity = Vector3.zero; // Detiene cualquier movimiento actual del jugador
        rb.AddForce(-newGravityDirection * jumpForce, ForceMode.Impulse); // Aplica una fuerza en la dirección opuesta de la gravedad para simular el salto a la nueva pared
    }
}
