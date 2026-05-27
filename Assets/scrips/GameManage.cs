using UnityEngine;
    using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void RetryGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame() {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void NextButton() {
        Debug.Log("Load Next Level");
    }

    public void MenuButton() {
        Debug.Log("Load Menu");
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
