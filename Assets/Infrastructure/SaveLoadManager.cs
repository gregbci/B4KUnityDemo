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
    GameData gameData = new GameData();
    LocalRepository repository;

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
        if (repository.Load(out var json))
        {
            gameData = JsonUtility.FromJson<GameData>(json);
            GameModel.Instance?.Bind(gameData);
        }
    }

    public void SaveGame()
    {
        repository.Store(JsonUtility.ToJson(gameData));
    }

}
