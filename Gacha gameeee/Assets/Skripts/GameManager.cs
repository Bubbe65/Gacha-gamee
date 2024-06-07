using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector2 playerPosition;
    public int playerHealth;
    public int playerScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}