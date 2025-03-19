using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
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
}
