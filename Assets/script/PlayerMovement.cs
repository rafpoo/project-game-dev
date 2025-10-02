using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // kecepatan gerak

    void Update()
    {
        // Input dari keyboard (WASD atau Arrow Keys)
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveZ = Input.GetAxis("Vertical");   // W/S

        // Bikin vector arah
        Vector3 move = new Vector3(moveX, 0, moveZ);

        // Gerakin Box
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
