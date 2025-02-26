using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene02_UIComponentHandler : MonoBehaviour
{
    private Button _decreaseScoreButton, _goToScene01Button;
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
        
        _scoreLabel = root.Q<Label>("ScoreLabel");
        _scoreLabel.text = gameState.Score + "";

        _decreaseScoreButton = root.Q<Button>("DecreaseScoreButton");
        _decreaseScoreButton.clicked += DecreaseScore;

        _goToScene01Button = root.Q<Button>("GoToScene01Button");
        _goToScene01Button.clicked += ChangeToScene01;
    }

    private void DecreaseScore()
    {
        gameState.Score--;
        _scoreLabel.text = gameState.Score + "";
    }

    private void ChangeToScene01()
    {
        SceneManager.LoadScene("Scene01");
    }
}
