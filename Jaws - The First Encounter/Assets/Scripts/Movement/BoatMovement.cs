﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{

    // var storage
    Rigidbody2D rb2d;                           // boat's rigid body 2d component
    Vector2 boatDirection = new Vector2(1, 0);  // initial direction of boat
    float maxBoatForce;                         // max force which boat moves at
    float rotateDegreesPerSecond;               // rate by which ship rotates
    float forceFactor;                          // force percentage of boat according to its speed setting

    // Declares dictionary to pair boat speeds with appropriate force factors
    Dictionary<BoatSpeeds, float> forceFactorRange = new Dictionary<BoatSpeeds, float>();

    // Placeholder text to display boat's current speed
    // Note: Will be replaced with more formal UI at later date
    Text speedText;                             // text to display boat's speed setting
    BoatSpeeds boatSpeed = BoatSpeeds.stop;     // boat's speed setting

    // Use this for initialization
    void Start()
    {
        // Sets movement fields to configured data
        maxBoatForce = PlayerConfigUtils.ForwardForce;
        rotateDegreesPerSecond = PlayerConfigUtils.RotationRate;
        forceFactor = PlayerConfigUtils.Stop;

        // Pairs boat speeds with appropriate player config data
        forceFactorRange.Add(BoatSpeeds.fullAhead, PlayerConfigUtils.FullAhead);
        forceFactorRange.Add(BoatSpeeds.slowAhead, PlayerConfigUtils.SlowAhead);
        forceFactorRange.Add(BoatSpeeds.stop, PlayerConfigUtils.Stop);
        forceFactorRange.Add(BoatSpeeds.slowAstern, PlayerConfigUtils.SlowAstern);
        forceFactorRange.Add(BoatSpeeds.fullAstern, PlayerConfigUtils.FullAstern);

        //Get and store a reference to the Rigidbody2D component to access it
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        // Gets speed text component and initializes it to 0
        speedText = GameObject.FindGameObjectWithTag("boatSpeedText").GetComponent<Text>();
        speedText.text = "Speed: " + boatSpeed;
    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    void Update()
    {
        // if player triggers acceleration input
        if (Input.GetButtonDown("Accelerate"))
        {
            // increase boat speed
            if (boatSpeed != BoatSpeeds.fullAhead)
                --boatSpeed;
            forceFactor = forceFactorRange[boatSpeed];

            // update text indicator
            speedText.text = "Speed: " + boatSpeed;
        }

        // if player triggers reverse input
        if (Input.GetButtonDown("Reverse"))
        {
            // decrease boat speed
            if (boatSpeed != BoatSpeeds.fullAstern)
                ++boatSpeed;
            forceFactor = forceFactorRange[boatSpeed];

            // update text indicator
            speedText.text = "Speed: " + boatSpeed;
        }
    }

    // FixedUpdate is called at a constant rate reguardless of local framerate
    void FixedUpdate()
    {
        // move boat according to direction and speed
        rb2d.AddForce(boatDirection * (maxBoatForce * forceFactor), ForceMode2D.Force);

        // allow boat to turn if not currently adrift
        if (rb2d.velocity.x != 0 || rb2d.velocity.y != 0)
        {
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