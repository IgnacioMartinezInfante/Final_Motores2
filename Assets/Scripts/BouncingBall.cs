using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float bounciness = 0.8f; // Coeficiente de restitución

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Asegúrate de que la esfera tenga un material físico
        PhysicMaterial physicMaterial = new PhysicMaterial();
        physicMaterial.bounciness = bounciness;
        physicMaterial.bounceCombine = PhysicMaterialCombine.Maximum;

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.material = physicMaterial;
        }
    }
}