using UnityEngine;
using TMPro;

public class ButtonCounter : MonoBehaviour
{
    public TMP_Text buttonCounterText;  // Texto en el canvas que mostrará el contador
    private int buttonPressCount = 0;

    void Start()
    {
        // Buscar el objeto TextMeshPro en la escena por su nombre
        GameObject textObject = GameObject.Find("contadorbotones");
        if (textObject != null)
        {
            buttonCounterText = textObject.GetComponent<TMP_Text>();
        }

        if (buttonCounterText == null)
        {
            Debug.LogError("No se encontró un objeto TextMeshPro con el nombre 'contadorbotones' en la escena.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ballfriend")
        {
            buttonPressCount++;
            UpdateButtonCounterText();
        }
    }

    private void UpdateButtonCounterText()
    {
        if (buttonCounterText != null)
        {
            buttonCounterText.text = "Botones Presionados: " + buttonPressCount.ToString();
        }
    }
}