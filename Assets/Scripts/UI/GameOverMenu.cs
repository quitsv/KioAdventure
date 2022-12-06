using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
  [SerializeField] private Health playerHealth;
  [SerializeField] private GameObject gameOverMenuUI;
	public static bool GameOver = false;

  void Start()
  {
    gameOverMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameOver = false;
  }

  void Update()
  {
    if (playerHealth.isDead())
    {
      gameOverMenuUI.SetActive(true);
			Time.timeScale = 0f;
			GameOver = true;
    }
  }

  public void LoadMenu()
  {
    SceneManager.LoadScene("Main Menu");
  }

  public void restartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
