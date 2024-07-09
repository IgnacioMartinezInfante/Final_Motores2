using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    public float jumpDuration = 0.5f; // Duración del salto
    private int currentWall = 0; // 0 = piso, 1 = pared izquierda, 2 = techo, 3 = pared derecha
    private Rigidbody rb; // Referencia al componente Rigidbody del jugador
    private bool isJumping = false; // Para evitar que el jugador salte mientras está en el aire

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene y guarda el componente Rigidbody del jugador
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isJumping) // Si se presiona la tecla A y el jugador no está en el aire
        {
            StartCoroutine(MoveToNextWall(-1)); // Mueve al jugador a la pared de la izquierda
        }
        if (Input.GetKeyDown(KeyCode.D) && !isJumping) // Si se presiona la tecla D y el jugador no está en el aire
        {
            StartCoroutine(MoveToNextWall(1)); // Mueve al jugador a la pared de la derecha
        }
    }

    IEnumerator MoveToNextWall(int direction)
    {
        isJumping = true; // Indica que el jugador está en el aire

        int newWall = (currentWall + direction + 4) % 4; // Calcula la nueva pared en la que se ubicará el jugador

        // Variables para almacenar la nueva rotación y dirección de la gravedad
        Vector3 startRotation = transform.eulerAngles;
        Vector3 endRotation = Vector3.zero;
        Vector3 jumpDirection = Vector3.up;
        Vector3 newGravityDirection = Vector3.down;

        // Ajusta las variables según la nueva pared
        switch (newWall)
        {
            case 0: // piso
                endRotation = new Vector3(0, 0, 0); // Sin rotación
                newGravityDirection = Vector3.down; // Gravedad hacia abajo
                break;
            case 1: // pared izquierda
                endRotation = new Vector3(0, 0, 90); // Rotación de 90 grados
                newGravityDirection = Vector3.right; // Gravedad hacia la derecha
                break;
            case 2: // techo
                endRotation = new Vector3(0, 0, 180); // Rotación de 180 grados
                newGravityDirection = Vector3.up; // Gravedad hacia arriba
                break;
            case 3: // pared derecha
                endRotation = new Vector3(0, 0, -90); // Rotación de -90 grados
                newGravityDirection = Vector3.left; // Gravedad hacia la izquierda
                break;
        }

        // Fase 1: Salto hacia arriba
        rb.velocity = Vector3.zero; // Detiene cualquier movimiento actual del jugador
        rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);

        // Espera la duración del salto antes de cambiar la gravedad
        yield return new WaitForSeconds(jumpDuration / 2);

        // Fase 2: Rota al jugador en el aire
        float elapsedTime = 0f;
        while (elapsedTime < jumpDuration / 2)
        {
            transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, elapsedTime / (jumpDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fase 3: Ajusta la gravedad y aplica la caída
        transform.eulerAngles = endRotation; // Asegura que la rotación final sea exacta
        Physics.gravity = newGravityDirection * 9.81f; // Cambia la dirección de la gravedad

        currentWall = newWall; // Actualiza la pared actual
        isJumping = false; // Indica que el jugador ha aterrizado
    }
}