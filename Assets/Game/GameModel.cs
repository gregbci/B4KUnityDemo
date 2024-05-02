using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameModel: Singleton<GameModel>
{
    // TODO - connect to data container, make these read only
    public string Name { get; }
    public Color CubeColor { get; }

    public bool IsRotating { get; set; }
    public Vector3 RotationRates { get; set; }

    public void Start()
    {
        // TODO - handle case where data is null or stored
        ResetRotations();
    }

    public void StartRotate()
    {
        IsRotating = true;
    }

    public void StopRotate()
    {
        IsRotating = false;
    }

    public void ResetRotations()
    {
        RotationRates = Random.rotation.eulerAngles;
    }
}
