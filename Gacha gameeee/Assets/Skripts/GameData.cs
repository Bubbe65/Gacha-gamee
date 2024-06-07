using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    private static GameData instance;

    // Skit script
    private Vector3 playerPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Set the player's position
    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }

    // Get the player's position
    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameData instance is null.");
            }
            return instance;
        }
    }
}