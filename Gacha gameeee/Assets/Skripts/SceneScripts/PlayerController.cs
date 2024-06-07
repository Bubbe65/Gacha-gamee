using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        // Example of updating player position
        GameManager.instance.playerPosition = transform.position;
        // Update other stats as needed
        GameManager.instance.playerHealth = 100; // example health update
        GameManager.instance.playerScore = 10;   // example score update
    }
}