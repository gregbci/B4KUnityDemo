using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    // connect to data container, make these read only
    public string Name { get; }
    public Color CubeColor { get; }

    public bool IsRotating { get; set; }
    public Vector3 RotationRates { get; set; }

    private void Start()
    {
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
