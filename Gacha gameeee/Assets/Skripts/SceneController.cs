using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // Save player position and stats before changing scenes
        GameManager.instance.playerPosition = GameObject.FindWithTag("Player").transform.position;
        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Restore player position and stats after the new scene is loaded
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = GameManager.instance.playerPosition;
            // Restore other stats as needed
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Restore health and score if needed
                // playerController.health = GameManager.instance.playerHealth;
                // playerController.score = GameManager.instance.playerScore;
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}