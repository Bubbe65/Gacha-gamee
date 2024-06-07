using UnityEngine;
using UnityEngine.UI;

public class SceneChangeController : MonoBehaviour
{
    public SceneController sceneController;
    public string sceneName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => sceneController.ChangeScene(sceneName));
    }
}