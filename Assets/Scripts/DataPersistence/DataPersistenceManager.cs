using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one instance of the Data Persistence Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // TODO - Load any saved data from a file using the data handler
        //If there isn't anything to load, initialize to a new game
        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        //TODO - Push the loaded data to all other scripts that need it
    }

    public void SaveGame()
    {
        //TODO - Pass the data to other scripts so they can update it

        //TODO - Save that data to a file using the data handler
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

}
