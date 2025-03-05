using UnityEngine;
using UnityEngine.UIElements;

public class StartMenu_UI_Main_Button_Hover : MonoBehaviour
{
    private StyleColor startButtonOriginalColour;
    private StyleColor optionsButtonOriginalColour;
    private StyleColor quitButtonOriginalColour;
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        if(root == null)
        {
            Debug.Log("UI Document not found!");
        }
        else
        {
            Button startButton = root.Q<Button>("StartGameButton");
            startButtonOriginalColour = startButton.style.backgroundColor;

            //tell the MouseEnterEvent to run the method that I'm giving you when it occurs
            startButton.RegisterCallback<MouseEnterEvent>(evt => OnButtonHover(startButton));
            startButton.RegisterCallback<MouseLeaveEvent>(evt => OnButtonExit(startButton, startButtonOriginalColour));

            Button optionsButton = root.Q<Button>("OptionsButton");
            optionsButtonOriginalColour = optionsButton.style.backgroundColor;

            optionsButton.RegisterCallback<MouseEnterEvent>(evt => OnButtonHover(optionsButton));
            optionsButton.RegisterCallback<MouseLeaveEvent>(evt => OnButtonExit(optionsButton, optionsButtonOriginalColour));

            Button quitButton = root.Q<Button>("QuitButton");
            quitButtonOriginalColour = quitButton.style.backgroundColor;

            quitButton.RegisterCallback<MouseEnterEvent>(evt => OnButtonHover(quitButton));
            quitButton.RegisterCallback<MouseLeaveEvent>(evt => OnButtonExit(quitButton, quitButtonOriginalColour));
        }
    }
    private void OnButtonHover(Button button)
    {
        button.style.backgroundColor = new StyleColor(new Color(0.5f, 0.8f, 0.5f));
        button.style.scale = new StyleScale(new Vector3(1.05f, 1.05f, 1f));
    }
    private void OnButtonExit(Button button, StyleColor originalColor)
    {
        button.style.backgroundColor = originalColor;
        button.style.scale = new StyleScale(Vector3.one);
    }

}
