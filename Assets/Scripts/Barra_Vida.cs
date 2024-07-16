using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Vida : MonoBehaviour
{
    public Image relleno;
    public Player_Health player;
    private float VidaMaxima; // Vida máxima del jugador
    private float VidaActual; // Vida actual del jugador

    void Update()
    {
        if (player != null)
        {
            VidaMaxima = player.maxHealth;
            VidaActual = player.currentHealth;
            relleno.fillAmount = VidaActual / VidaMaxima;
        }
    }
}
