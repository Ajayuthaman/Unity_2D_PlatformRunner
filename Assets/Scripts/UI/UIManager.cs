using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject playButtons;
    [SerializeField] private AudioClip gameOverSound;

    [Header ("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject scoreAndHealth;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        playButtons.SetActive(false);
        pauseButton.SetActive(false);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    #region
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        if (status)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        if (!pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(true);
            playButtons.SetActive(false);
            pauseButton.SetActive(false);
            scoreAndHealth.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        playButtons.SetActive(true);
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        scoreAndHealth.SetActive(true);
    }

    #endregion
}
