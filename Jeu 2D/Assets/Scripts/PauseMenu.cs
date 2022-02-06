using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        // empêcher le joueur de se mouvoir/sauter
        PlayerMovement.instance.enabled = false;
        // activer notre menu pause / l'afficher
        pauseMenuUI.SetActive(true);
        // arrêter le temps
        Time.timeScale = 0;
        // changer le statut du jeu
        gameIsPaused = true;
    }


    public void Resume()
    {
        // réactiver le player movement
        PlayerMovement.instance.enabled = true;
        // désactiver notre menu pause / ne plus l'afficher
        pauseMenuUI.SetActive(false);
        // relancer le temps
        Time.timeScale = 1;
        // changer le statut du jeu
        gameIsPaused = false;
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
