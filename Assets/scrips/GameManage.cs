using UnityEngine;
    using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
