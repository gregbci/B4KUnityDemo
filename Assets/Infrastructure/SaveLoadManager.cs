using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.UI;
using UnityEngine;

// Example persistence manager that just loads the model data at start
// and saves it when the application quits.  The load/save methods could
// be attached to buttons, etc.
public class SaveLoadManager: MonoBehaviour
{
    private GameData gameData;
    private LocalRepository repository;


    public void Awake()
    {
        repository = new LocalRepository();
        LoadGame();
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }


    public void LoadGame()
    {
        if (repository.Load(out var json) && json.Length > 0)
        {
            gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("SaveLoadManager: Loaded game data");
        }
        else
        {
            gameData = new GameData();
            Debug.Log("SaveLoadManager: Initializing game data");
        }

        // share new GameData with model, keep reference for saving
        GameModel.Instance?.Bind(gameData);
    }

    public void SaveGame()
    {
        repository.Store(JsonUtility.ToJson(gameData));
        Debug.Log("SaveLoadManager: Saved game data");
    }

}
