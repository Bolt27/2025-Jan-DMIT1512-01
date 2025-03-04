using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;


public class StartMenu_UI_Main : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        if(root == null)
        {
            Debug.Log("UI Document not found!");
        }
        else
        {
            root.Q<Button>("StartGameButton").clicked += StartGame;
            root.Q<Button>("OptionsButton").clicked += OpenOptions;
            root.Q<Button>("QuitButton").clicked += QuitGame;
        }
    }
    private void StartGame()
    {
        Debug.Log("Starting Game...");
    }
    private void OpenOptions()
    {
        Debug.Log("Opening Options...");
    }
    private void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }
}
