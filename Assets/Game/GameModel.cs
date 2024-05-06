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
    // Create a default GameData, this may be replaced by Bind()
    private GameData gameData = new GameData();

    // GameData is accessed using read only properties and mutated with functions
    public string UserName => gameData.UserName;
    public Color CubeColor => gameData.CubeColor;
    public bool IsRotating => gameData.IsRotating;
    public Vector3 RotationRates => gameData.RotationRates;

    // Change event for the model
    // Note - there's a new runtime binding feature in Unity 2023.2 that looks nice, but doesn't
    // seem to work reliably yet.  It works by setting providing the UI elements with a path to 
    // the thing they should use for their data, ex: model.UserName.
    public static event System.Action WasChanged;

    public void Start()
    {
        // If the model is uninitialized, set it up
        if (!gameData.WasInitialized)
        {
            SetName("Unknown");
            ResetRotations();
            gameData.WasInitialized = true;
        }
        WasChanged?.Invoke();
    }

    public void SetName(string name)
    {
        gameData.UserName = name;
        WasChanged?.Invoke();
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


    // Bind replaces the current gameData with another one.  This is used
    // to provide the model with a GameData loaded from disk, etc.
    public void Bind(GameData gameData)
    {
        this.gameData = gameData;
    }
}
