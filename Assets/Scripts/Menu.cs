using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CargarJuego()
    {
        SceneManager.LoadScene("juego");
        Time.timeScale = 1f;
    }

    public void Cargarreglas()
    {
        SceneManager.LoadScene("reglas");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
