using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene01_UIComponentHandler : MonoBehaviour
{
    private Button _increaseScoreButton, _goToScene02Button;
    private Label _scoreLabel;
    
    //in any script that needs to read from or write to the game state, follow the following steps

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
        
        _scoreLabel = root.Q<Label>("ScoreLabel");
        _scoreLabel.text = gameState.Score + "";
        
        _increaseScoreButton = root.Q<Button>("IncreaseScoreButton");
        _increaseScoreButton.clicked += IncreaseScore;

        _goToScene02Button = root.Q<Button>("GoToScene02Button");
        _goToScene02Button.clicked += ChangeToScene02;
    }

    private void IncreaseScore()
    {
        gameState.Score++;
        _scoreLabel.text = gameState.Score + "";
    }

    private void ChangeToScene02()
    {
        SceneManager.LoadScene("Scene02");
    }
}
