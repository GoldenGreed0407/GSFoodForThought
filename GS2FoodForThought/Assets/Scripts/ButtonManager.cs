using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GameScene()
    {

        SceneManager.LoadScene("GameScene");
    }
    public void StartScene()
    {

        SceneManager.LoadScene("StartScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
