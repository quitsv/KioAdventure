using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public static bool GameIsPaused = false;
  public GameObject pauseMenuUI;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) && !GameOverMenu.GameOver)
    {
      if (GameIsPaused)
      {
        Resume();
      }
      else
      {
        Pause();
      }
    }
  }

  public void Resume()
  {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
  }

  void Pause()
  {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    GameIsPaused = false;
    SceneManager.LoadScene("Main Menu");
  }

  public static bool isPaused()
  {
    return GameIsPaused;
  }
}
