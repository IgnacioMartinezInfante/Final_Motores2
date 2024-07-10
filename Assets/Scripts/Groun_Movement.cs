using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groun_Movement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento

    private void Update()
    {
        // Mover el objeto hacia adelante en el eje Z
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Reposicionar el objeto cuando llega a la posición -10 en el eje Z
        if (transform.position.z <= -20f)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, 80f);
            Destroy(this.gameObject);
        }
    }
}
