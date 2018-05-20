using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// A container for configuration data pertaining to
/// the player
/// </summary>
public class PlayerConfigData
{

    #region Fields

    // declares name of file to read from
    const string PlayerConfigDataFileName = "PlayerConfigData.csv";

    // declares movement variables and sets them to safe defaults
    float forwardForce = 4f;
    float rotationRate = 90f;

    // declares force factor fields and sets them to safe defaults
    float fullAhead = 1f;
    float slowAhead = .5f;
    float stop = 0;
    float slowAstern = .2f;
    float fullAstern = .4f;

    // declares boat hull fields and sets them to safe defaults
    int hullIntegrity = 100;
    int hullCapacity = 20;

    // declares gas tank fields and sets them to safe defaults
    float gasTankSize = 50f;
    float gasConsumptionRate = 1f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets forward force of boat
    /// </summary>
    public float ForwardForce
    {
        get { return forwardForce; }
    }

    /// <summary>
    /// Gets boat's max rotation rate
    /// </summary>
    public float RotationRate
    {
        get { return rotationRate; }
    }

    /// <summary>
    /// Gets boat's full ahead force factor
    /// </summary>
    public float FullAhead
    {
        get { return fullAhead; }
    }

    /// <summary>
    /// Gets boat's slow ahead force factor
    /// </summary>
    public float SlowAhead
    {
        get { return slowAhead; }
    }

    /// <summary>
    /// Gets boat's stop force factor
    /// </summary>
    public float Stop
    {
        get { return stop; }
    }

    /// <summary>
    /// Gets boat's slow astern force factor
    /// </summary>
    public float SlowAstern
    {
        get { return slowAstern; }
    }

    /// <summary>
    /// Gets boat's full astern force factor
    /// </summary>
    public float FullAstern
    {
        get { return fullAstern; }
    }

    /// <summary>
    /// Gets boat's max hull integrity
    /// </summary>
    public int HullIntegrity
    {
        get { return hullIntegrity; }
    }

    /// <summary>
    /// Gets max boat can store in its hull
    /// </summary>
    public int HullCapacity
    {
        get { return hullCapacity; }
    }

    /// <summary>
    /// Gets how much gas boat can store in its tank
    /// </summary>
    public float GasTankSize
    {
        get { return gasTankSize; }
    }

    /// <summary>
    /// Gets rate at which boat's engine consumes gas
    /// </summary>
    public float GasConsumptionRate
    {
        get { return gasConsumptionRate; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public PlayerConfigData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, PlayerConfigDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(names, values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvNames, string csvValues)
    {
        // splits names and values into arrays of strings
        string[] names = csvNames.Split(',');
        string[] values = csvValues.Split(',');

        // pairs names with values in a dictionary
        Dictionary<string, string> csvData = new Dictionary<string, string>();
        for (int i = 0; i < names.Length; i++)
        {
            csvData.Add(names[i], values[i]);
        }

        // sets movement fields to appropriate values
        forwardForce = float.Parse(csvData["forwardForce"]);
        rotationRate = float.Parse(csvData["rotationRate"]);

        // sets force factor fields to appropriate values
        fullAhead = float.Parse(csvData["fullAhead"]);
        slowAhead = float.Parse(csvData["slowAhead"]);
        stop = float.Parse(csvData["stop"]);
        slowAstern = float.Parse(csvData["slowAstern"]);
        fullAstern = float.Parse(csvData["fullAstern"]);

        // sets boat hull fields to appropriate values
        hullIntegrity = int.Parse(csvData["hullIntegrity"]);
        hullCapacity = int.Parse(csvData["hullCapacity"]);

        // sets gas tank fields to appropriate values
        gasTankSize = float.Parse(csvData["gasTankSize"]);
        gasConsumptionRate = float.Parse(csvData["gasConsumptionRate"]);
    }

}
