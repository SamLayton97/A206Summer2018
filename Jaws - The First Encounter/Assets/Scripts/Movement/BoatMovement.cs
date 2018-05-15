using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    // var storage
    Rigidbody2D rb2d;
    Vector2 boatDirection = new Vector2(1, 0);
    float boatForce;
    float rotateDegreesPerSecond;

    // Use this for initialization
    void Start()
    {
        // sets movement fields to configured data
        boatForce = PlayerConfigUtils.ForwardForce;
        rotateDegreesPerSecond = PlayerConfigUtils.RotationRate;

        //Get and store a reference to the Rigidbody2D component to access it
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a constant rate reguardless of local framerate
    void FixedUpdate()
    {
        // Accelerate as appropriate
        if (Input.GetAxisRaw("Accelerate") > 0)
        {
            rb2d.AddForce(boatDirection * boatForce, ForceMode2D.Force);

            // Only Allow Boat to turn while accelerating
            TurnBoat();
        }

        if (Input.GetAxisRaw("Reverse") > 0)
        {
            rb2d.AddForce(boatDirection * (boatForce *(-1)), ForceMode2D.Force);

            // Only Allow Boat to turn while reversing
            TurnBoat();
        }
    }

    void TurnBoat()
    {
        // check for rotation input
        float rotationInput = Input.GetAxisRaw("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match boat rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            boatDirection.x = Mathf.Cos(zRotation);
            boatDirection.y = Mathf.Sin(zRotation);
        }
    }
}