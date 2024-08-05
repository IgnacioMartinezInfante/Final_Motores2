using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticles : MonoBehaviour
{
    public List<ParticleSystem> particleSystems; // Lista de sistemas de partículas a activar

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
        if (collision.gameObject.name == "ballfriend") // Compara el nombre del objeto con "ballfriend"
        {
            // Activa y reproduce todos los sistemas de partículas si están asignados
            foreach (ParticleSystem ps in particleSystems)
            {
                if (ps != null)
                {
                    ps.gameObject.SetActive(true);
                    ps.Play(); // Inicia la animación de partículas
                }
            }

            Destroy(gameObject); // Destruye el objeto
        }
    }
}
