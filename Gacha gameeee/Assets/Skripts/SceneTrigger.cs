using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public SceneController sceneController;
    public string sceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneController.ChangeScene("sceneName");
        }
    }
}