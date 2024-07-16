using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject gameoverCanvas;

    void Start()
    {
        currentHealth = maxHealth;
        gameoverCanvas.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aquí puedes implementar la lógica de muerte del jugador, como reiniciar el nivel, mostrar una pantalla de Game Over, etc.
        Debug.Log("Player Died");
        gameoverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
