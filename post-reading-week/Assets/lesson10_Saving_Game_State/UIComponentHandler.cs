using UnityEngine;
using UnityEngine.UIElements;

public class UIComponentHandler : MonoBehaviour
{
    private Button _increaseScoreButton;
    private Label _scoreLabel;
    
    //in any script that needs to read from or write to the game state, follow the steps
    //in this script

    //Step #1, declare a gameState data member
    private GameState gameState;

    void Awake()
    {
        //Step #2, in "Awake", do this
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _increaseScoreButton = root.Q<Button>("IncreaseScoreButton");
        _scoreLabel = root.Q<Label>("ScoreLabel");
        _scoreLabel.text = gameState.Score + "";
        _increaseScoreButton.clicked += IncreaseScore;
    }

    private void IncreaseScore()
    {
        gameState.Score++;
        _scoreLabel.text = gameState.Score + "";
    }
}
