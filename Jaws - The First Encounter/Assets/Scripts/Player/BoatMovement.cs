using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BoatMovement : MonoBehaviour
{
    // declares momement variables
    Rigidbody2D rb2d;                           // boat's rigid body 2d component
    Vector2 boatDirection = new Vector2(1, 0);  // initial direction of boat
    float maxBoatForce;                         // max force which boat moves at
    float rotateDegreesPerSecond;               // rate by which ship rotates
    float forceFactor;                          // force percentage of boat according to its speed setting

    // declares hull integrity support variables

    // declares gas tank support variables

    // declares speed indicator support variables
    Dictionary<BoatSpeeds, float> forceFactorRange = new Dictionary<BoatSpeeds, float>();
    ChangeSpeedEvent changeSpeedEvent;          // event fired when player changes speed
    BoatSpeeds boatSpeed = BoatSpeeds.stop;     // boat's current speed setting

    #region Public Methods

    /// <summary>
    /// Adds given listener to Change Speeds Event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddChangeSpeedListener(UnityAction<BoatSpeeds> listener)
    {
        changeSpeedEvent.AddListener(listener);
    }

    #endregion

    #region Private Methods

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

        // add self as invoker of Change Speed Event
        changeSpeedEvent = new ChangeSpeedEvent();
        EventManager.AddChangeSpeedInvoker(this);
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

            // update speed indicator
            changeSpeedEvent.Invoke(boatSpeed);
        }

        // if player triggers reverse input
        if (Input.GetButtonDown("Reverse"))
        {
            // decrease boat speed
            if (boatSpeed != BoatSpeeds.fullAstern)
                ++boatSpeed;
            forceFactor = forceFactorRange[boatSpeed];

            // update speed indicator
            changeSpeedEvent.Invoke(boatSpeed);
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

    #endregion

}