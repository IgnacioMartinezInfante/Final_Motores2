using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float bounciness = 0.8f; // Coeficiente de restitución
    public TMP_Text buttonCounterText; // Asignar desde el Inspector

    private Rigidbody rb;
    private int buttonPressCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Asegúrate de que la esfera tenga un material físico
        PhysicMaterial physicMaterial = new PhysicMaterial
        {
            bounciness = bounciness,
            bounceCombine = PhysicMaterialCombine.Maximum
        };

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.material = physicMaterial;
        }

        if (buttonCounterText == null)
        {
            Debug.LogError("No se ha asignado un objeto TMP_Text desde el Inspector.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            Debug.Log("colision");
            ButtonMovement buttonMovement = collision.gameObject.GetComponent<ButtonMovement>();
            if (buttonMovement != null)
            {
                buttonMovement.StartAnimation();
            }
            else
            {
                Debug.LogError("El objeto con el que se colisionó no tiene un componente ButtonMovement.");
            }

            buttonPressCount++;
            UpdateButtonCounterText();
        }
    }

    private void UpdateButtonCounterText()
    {
        if (buttonCounterText != null)
        {
            buttonCounterText.text = "Botones: " + buttonPressCount.ToString();
        }
    }
}