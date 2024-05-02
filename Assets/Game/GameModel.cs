using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// GameModel implements the "business logic" for the game.  It stores
// state in a GameData object for easy serialization.  The GameModel exposes
// state via read only properties.  Mutation of the state typically requires
// calling a GameModel function, ie: tell the model what you want to do rather
// that doing it yourself.
//
public class GameModel : Singleton<GameModel>
{
    private GameData gameData;

    // GameData is accessed using read only properties and mutated with functions
    public string UserName => gameData.UserName;
    public Color CubeColor => gameData.CubeColor;
    public bool IsRotating => gameData.IsRotating;
    public Vector3 RotationRates => gameData.RotationRates;

    public void Start()
    {
        gameData = new GameData();
        ResetRotations();
    }

    public void StartRotate()
    {
        gameData.IsRotating = true;
    }

    public void StopRotate()
    {
        gameData.IsRotating = false;
    }

    public void ResetRotations()
    {
        gameData.RotationRates = Random.rotation.eulerAngles;
    }
}
