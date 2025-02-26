using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace lesson09_Intro_To_UI
{
    public class Scene01_Button_Handler : MonoBehaviour
    {
        private void OnEnable()
        {
            //get the root UI element
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            Button changeToScene02Button = root.Q<Button>("ChangeToScene02Button");
            if(changeToScene02Button != null)
            {
                changeToScene02Button.clicked += ChangeToScene02;
            }
        }
        private void ChangeToScene02()
        {
            SceneManager.LoadScene("Scene02");
        }
    }
}
