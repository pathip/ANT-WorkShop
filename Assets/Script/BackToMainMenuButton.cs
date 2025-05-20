using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuButton : MonoBehaviour
{
    public void OnPressButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
