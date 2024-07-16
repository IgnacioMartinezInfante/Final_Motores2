using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public int damage = 10; // Daño que inflige el enemigo al jugador
    private bool canDamage = true; // Controla si el enemigo puede hacer daño

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Health playerHealth = collision.gameObject.GetComponent<Player_Health>();
            if (playerHealth != null && canDamage)
            {
                playerHealth.TakeDamage(damage);
                StartCoroutine(DamageCooldown());
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        canDamage = false; // Desactiva el daño
        yield return new WaitForSeconds(1f); // Espera 1 segundo
        canDamage = true; // Activa el daño nuevamente
    }
}
