using System;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    public int _currentScore = 0;
    public int _highScore = 0;
}

/*
    THINGS TO DO FOR THE ASSIGNMENT:
    #1) in "Awake", load data (we don't need those buttons)
    #2) in the Pinball scene, save data when the scene is unloaded:
        in the DeathZone class, add this method:
        void OnDestroy()
        {
            Debug.Log("Scene is unloading (OnDestroy)");
            //save data here
        }
    #3) alter the UI so that the opening scene only displays high score, not current score
    #4) add logic so that it only saves the high score if the current score is greater than the high score

*/

public class GameStateFinal : MonoBehaviour
{
    private GameData _gameData; //= new GameData();
    public int CurrentScore
    {
        get => _gameData._currentScore;
        set => _gameData._currentScore = value;
    }

    public int HighScore
    {
        get => _gameData._highScore;
        set => _gameData._highScore = value;
    }
    void Awake()
    {
        GameObject [] objs = GameObject.FindGameObjectsWithTag("GameState");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        _gameData = new GameData();
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveToDisk()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "Conrad.txt");

        string jsonString = JsonUtility.ToJson(_gameData);
        Debug.Log("Saving score to " + Application.persistentDataPath);
        using(StreamWriter streamWriter = File.CreateText(dataPath))
        {
            streamWriter.Write(jsonString);
            Debug.Log(dataPath);
        }
    }
    public void LoadFromDisk()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "Conrad.txt");
        using (StreamReader streamReader = File.OpenText(dataPath))
        {
            //get the string that we wrote to the file
            string jsonString = streamReader.ReadToEnd();

            //convert the string to an object
            JsonUtility.FromJsonOverwrite(jsonString, _gameData);
        }
    }
}
