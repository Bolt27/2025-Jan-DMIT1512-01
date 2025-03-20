using UnityEngine.UIElements;
using UnityEngine;

public class Pinball_UI : MonoBehaviour
{
    //Step #1, declare a gameState data member
    private GameStateFinal _gameState;
    private Label _currentScoreLabel;
    void Awake()
    {
        //Step #2, in "Awake", do this
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateFinal>();
        _currentScoreLabel = GetComponent<UIDocument>().rootVisualElement.Q<Label>("CurrentScoreLabel");
    }
    void Update()
    {
        _currentScoreLabel.text = _gameState.CurrentScore + "";
    }
}
