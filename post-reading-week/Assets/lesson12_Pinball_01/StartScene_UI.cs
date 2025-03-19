using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
public class StartScene_UI : MonoBehaviour
{
    private GameStateFinal _gameState;
    private VisualElement _root;
    Label _highScoreLabel, _currentScoreLabel;
    void Awake()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateFinal>();
        
        _root = GetComponent<UIDocument>().rootVisualElement;
        _highScoreLabel = _root.Q<Label>("HighScoreLabel");
        _currentScoreLabel = _root.Q<Label>("CurrentScoreLabel");
    }
    void OnEnable()
    {
        PopulateScore();
        _root.Q<Button>("LoadButton").clicked += Load;
        _root.Q<Button>("SaveButton").clicked += Save;
        _root.Q<Button>("LoadLevel01Button").clicked += LoadLevel01;
    }
    private void PopulateScore()
    {
        _highScoreLabel.text = _gameState.HighScore + "";
        _currentScoreLabel.text = _gameState.CurrentScore + "";
    }
    internal void Load()
    {
        //_gameState.LoadFromDisk();
        PopulateScore();
    }
    internal void Save()
    {
        //_gameState.SaveToDisk();
    }
    internal void LoadLevel01()
    {
        SceneManager.LoadScene("Level01");
    }

}
