using UnityEngine.UIElements;
using UnityEngine;

public class Pinball_UI : MonoBehaviour
{
    //Step #1, declare a gameState data member
    private GameStateFinal _gameState;
    private Label _currentScoreLabel;
    void Start()
    {
        //Step #2, in "Start", do this
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateFinal>();

        _currentScoreLabel = GetComponent<UIDocument>().rootVisualElement.Q<Label>("CurrentScoreLabel");
        _currentScoreLabel.text = _gameState.CurrentScore + "";
    }
    void Update()
    {
        //only update UI if necessary (round-trips to the screen are costly)
        // if(int.Parse(_currentScoreLabel.text) != _gameState.CurrentScore)
        // {
        //     _currentScoreLabel.text = _gameState.CurrentScore + "";
        // }
    }
}
