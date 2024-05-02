using UnityEngine;

// GameData contains game state used by GameModel.  It's just a dumb container
// that's easy to serialize to/from disk.
[System.Serializable]
public class GameData
{
    public string UserName;
    public Color CubeColor;
    public bool IsRotating;
    public Vector3 RotationRates;
}
