using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void load_level_1()
    {
        SceneManager.LoadScene(1);
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
