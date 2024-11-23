using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoat : MonoBehaviour
{
    public float forwardSpeed = 10f; // Kecepatan maju
    public float turnSpeed = 50f;    // Kecepatan belok

    private Rigidbody rb;

    private void Start()
    {
        // Ambil komponen Rigidbody dari kapal
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Ambil input dari pemain
        float moveInput = Input.GetAxis("Vertical"); // W (1), S (-1)
        float turnInput = Input.GetAxis("Horizontal"); // A (-1), D (1)

        // Gerakkan kapal maju/mundur
        Vector3 moveDirection = transform.forward * moveInput * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Belokkan kapal
        if (turnInput != 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}
