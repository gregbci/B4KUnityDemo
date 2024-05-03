using System;
using UnityEngine;

// GameData contains game state used by GameModel.  This is just a dumb container
// that's easy to serialize to/from disk.  Busines logic should go in the model.
[System.Serializable]
public class GameData
{
    public bool WasInitialized;
    public string UserName;
    public Color CubeColor;
    public bool IsRotating;
    public Vector3 RotationRates;
}
