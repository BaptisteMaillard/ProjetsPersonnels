using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {

        gameOverUI.SetActive(true);
    }


    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickUpInThisSceneCount);
        // Recharge la sc�ne
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Replace le joeueur au spawn
        PlayerHealth.instance.Respawn();
        // R�active les mouvements du joueur + qu'on lui rende sa vie
        gameOverUI.SetActive(false);

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
