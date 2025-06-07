using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A simple Game Manager script to store UI button methods such as Restart and Quit.
/// </summary>

public class GameManager : MonoBehaviour
{
    #region Public Methods

    /// <summary>
    /// Reloads the current scene and resumes game time.
    /// </summary>
    /// 

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Exits the game application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
