using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        // Loads the main scene — replace with your actual game scene name
        SceneManager.LoadScene("main scene");
    }
}
