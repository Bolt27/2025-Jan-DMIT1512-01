using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public int _currentScore;
    public int _highScore;
}

public class GameStateFinal : MonoBehaviour
{
    private GameData _gameData;
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
}
