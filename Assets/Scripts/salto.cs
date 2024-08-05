using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator del jugador
    private bool isJumping = false; // Para evitar que el jugador salte mientras está en el aire

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && !isJumping) // Si se presiona la tecla A o D y el jugador no está en el aire
        {
            StartCoroutine(PlayJumpAnimation()); // Ejecuta la animación de salto
        }
    }

    IEnumerator PlayJumpAnimation()
    {
        isJumping = true; // Indica que el jugador está en el air

        // Activa la animación de salto (puedes ajustar este trigger según tu Animator Controller)
        animator.SetTrigger("JumpTrigger");

        // Espera la duración de la animación de salto
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        isJumping = false; // Indica que el jugador ha aterrizado
    }
}
