using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator del jugador
    public float gravityStrength = 9.81f; // La fuerza de la gravedad
    private int currentWall = 0; // 0 = piso, 1 = pared derecha, 2 = techo, 3 = pared izquierda
    private Rigidbody rb; // Referencia al componente Rigidbody del jugador
    private bool isJumping = false; // Para evitar que el jugador salte mientras está en el aire

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene y guarda el componente Rigidbody del jugador
        animator.SetInteger("Wall", currentWall); // Establece la animación inicial
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isJumping) // Si se presiona la tecla A y el jugador no está en el aire
        {
            animator.SetBool("JumpRight", false); // Establece JumpRight en false para saltar a la izquierda
            StartCoroutine(PerformJump(-1)); // Ejecuta la animación de salto a la izquierda
        }
        if (Input.GetKeyDown(KeyCode.D) && !isJumping) // Si se presiona la tecla D y el jugador no está en el aire
        {
            animator.SetBool("JumpRight", true); // Establece JumpRight en true para saltar a la derecha
            StartCoroutine(PerformJump(1)); // Ejecuta la animación de salto a la derecha
        }
    }

    IEnumerator PerformJump(int direction)
    {
        isJumping = true; // Indica que el jugador está en el aire

        int newWall = (currentWall + direction + 4) % 4; // Calcula la nueva pared en la que se ubicará el jugador

        // Determina cuál animación de salto activar
        if (direction == -1)
        {
            switch (currentWall)
            {
                case 0:
                    animator.SetTrigger("JumpLeftToRightWallTrigger");
                    break;
                case 1:
                    animator.SetTrigger("JumpLeftToCeilingTrigger");
                    break;
                case 2:
                    animator.SetTrigger("JumpLeftToFloorTrigger");
                    break;
                case 3:
                    animator.SetTrigger("JumpLeftToLeftWallTrigger");
                    break;
            }
        }
        else if (direction == 1)
        {
            switch (currentWall)
            {
                case 0:
                    animator.SetTrigger("JumpRightToRightWallTrigger");
                    break;
                case 1:
                    animator.SetTrigger("JumpRightToCeilingTrigger");
                    break;
                case 2:
                    animator.SetTrigger("JumpRightToFloorTrigger");
                    break;
                case 3:
                    animator.SetTrigger("JumpRightToLeftWallTrigger");
                    break;
            }
        }

        // Espera la duración de la animación de salto
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Ajusta la gravedad según la nueva pared
        switch (newWall)
        {
            case 0: // piso
                Physics.gravity = Vector3.down * gravityStrength;
                break;
            case 1: // pared derecha
                Physics.gravity = Vector3.right * gravityStrength;
                break;
            case 2: // techo
                Physics.gravity = Vector3.up * gravityStrength;
                break;
            case 3: // pared izquierda
                Physics.gravity = Vector3.left * gravityStrength;
                break;
        }

        currentWall = newWall; // Actualiza la pared actual
        animator.SetInteger("Wall", currentWall); // Actualiza el parámetro del Animator
        isJumping = false; // Indica que el jugador ha aterrizado
    }
}