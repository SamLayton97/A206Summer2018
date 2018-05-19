using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls Boat's speed indicator
/// </summary>
public class SpeedControlIndicator : MonoBehaviour
{
    // saves all possible speed setting sprites into serialized fields
    [SerializeField]
    Sprite fullAheadSprite;
    [SerializeField]
    Sprite slowAheadSprite;
    [SerializeField]
    Sprite stopSprite;
    [SerializeField]
    Sprite slowAsternSprite;
    [SerializeField]
    Sprite fullAsternSprite;

    // UI image used for swapping
    Image image;

	// Use this for initialization
	void Start ()
    {
        // retrieves sprite renderer from this object
        image = GetComponent<Image>();

        // sets image to safe default
        image.sprite = stopSprite;

        // adds own ChangeSpeed method as listener to Change Speed Event
        EventManager.AddChangeSpeedListener(ChangeSpeed);
	}

    /// <summary>
    /// Alters speed indicator according to new boat speed
    /// </summary>
    /// <param name="speed">new boat speed</param>
    public void ChangeSpeed(BoatSpeeds speed)
    {
        // swaps image's sprite according to speed parameter
        switch (speed)
        {
            case BoatSpeeds.fullAhead:
                image.sprite = fullAheadSprite;
                break;
            case BoatSpeeds.slowAhead:
                image.sprite = slowAheadSprite;
                break;
            case BoatSpeeds.stop:
                image.sprite = stopSprite;
                break;
            case BoatSpeeds.slowAstern:
                image.sprite = slowAsternSprite;
                break;
            case BoatSpeeds.fullAstern:
                image.sprite = fullAsternSprite;
                break;
            default:
                break;
        }
    }
}
