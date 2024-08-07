using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject gameoverCanvas;
    public Color damageColor = Color.red; // Color al recibir daño
    private Renderer playerRenderer;
    private Color originalColor;

    private AudioSource damageAudioSource; // Referencia al AudioSource
    private AudioSource deathAudioSource;  // Referencia al AudioSource para la muerte

    public GameObject otherObject; // El otro objeto que tiene el AudioSource que quieres pausar
    private AudioSource otherAudioSource; // Referencia al AudioSource del otro objeto


    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        damageAudioSource = audioSources[0];
        deathAudioSource = audioSources[1];
        // Obtener el AudioSource del otro objeto
        if (otherObject != null)
        {
            otherAudioSource = otherObject.GetComponent<AudioSource>();
        }

            currentHealth = maxHealth;
        gameoverCanvas.SetActive(false);

        // Busca el Renderer en los hijos del objeto
        playerRenderer = GetComponentInChildren<Renderer>();

        if (playerRenderer != null)
        {
            // Guarda el color original del jugador
            originalColor = playerRenderer.material.color;
        }
        else
        {
            Debug.LogError("Renderer no encontrado en los hijos del objeto.");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            if (deathAudioSource != null)
            {
                deathAudioSource.Play(); // Activar el AudioSource para la muerte
            }
        }
        else
        {
            if (damageAudioSource != null)
            {
                damageAudioSource.Play(); // Activar el AudioSource
            }
            StartCoroutine(FlashDamageColor());
        }
    }

    void Die()
    {
        Debug.Log("Player Died");
        gameoverCanvas.SetActive(true);
        Time.timeScale = 0f;
        if (otherAudioSource != null)
        {
            otherAudioSource.Pause(); // Pausar el AudioSource del otro objeto
        }
    }

    IEnumerator FlashDamageColor()
    {
        if (playerRenderer != null)
        {
            // Cambia el color del jugador al color de daño
            playerRenderer.material.color = damageColor;

            // Espera un segundo
            yield return new WaitForSeconds(0.5f);

            // Cambia el color del jugador al color original
            playerRenderer.material.color = originalColor;
        }
    }
}
