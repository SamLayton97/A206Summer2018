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

    // declares variables and sets them to safe "defaults"
    float forwardForce = 4f;
    float rotationRate = 90f;

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
    }

}
