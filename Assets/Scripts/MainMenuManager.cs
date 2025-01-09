using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel; // Assign the Settings Panel in Inspector
    public GameObject leaderboardPanel; // Assign the Leaderboard Panel in Inspector

    // Called when the Play Game button is pressed
    public void PlayGame()
    {
        Debug.Log("Play Game button pressed.");
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with your game scene name
    }

    // Called when the Settings button is pressed
    public void OpenSettings()
    {
        Debug.Log("Settings button pressed.");
        settingsPanel.SetActive(true); // Display the settings panel
    }

    // Called when the View Leaderboard button is pressed
    public void OpenLeaderboard()
    {
        Debug.Log("View Leaderboard button pressed.");
        leaderboardPanel.SetActive(true); // Display the leaderboard panel
    }

    // Called when the Exit Game button is pressed
    public void ExitGame()
    {
        Debug.Log("Exit Game button pressed.");

#if UNITY_WEBGL
        Debug.Log("Cannot close the game in WebGL. Returning to main menu.");
        SceneManager.LoadScene("MainMenu"); // Reload main menu for WebGL
#else
        Application.Quit(); // Closes the application for standalone builds
#endif
    }

    // Called to close any active panels
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
