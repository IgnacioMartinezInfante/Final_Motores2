using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticles : MonoBehaviour
{
    public List<ParticleSystem> particleSystems; // Lista de sistemas de partículas a activar
    public GameObject objectToDestroy; // Objeto a destruir

    void Start()
    {
        // Asegúrate de que todos los sistemas de partículas estén desactivados al inic
        foreach (ParticleSystem ps in particleSystems)
        {
            if (ps != null)
            {
                ps.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ballfriend")) // Compara el nombre del objeto con "ballfriend"
        {
            Debug.Log("colision");
            // Activa y reproduce todos los sistemas de partículas si están asignados
            foreach (ParticleSystem ps in particleSystems)
            {
                if (ps != null)
                {
                    ps.gameObject.SetActive(true);
                    ps.Play(); // Inicia la animación de partículas
                }
            }

            Destroy(objectToDestroy); // Destruye el objeto especificado
        }
    }
}
