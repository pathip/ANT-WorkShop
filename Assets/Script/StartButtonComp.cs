using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonComp : MonoBehaviour
{
   public void OnPressButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
