using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public SceneController sceneController;
    public string sceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneController.ChangeScene("BossRoom");
        }
    }
}