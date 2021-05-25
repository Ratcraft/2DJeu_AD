using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance != null)
        {
            Debug.LogWarning("Trop de DontDestroyOnLoad");
            return;
        }
        instance = this;

        foreach (var item in objects)
        {
            DontDestroyOnLoad(item);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var item in objects)
        {
            SceneManager.MoveGameObjectToScene(item, SceneManager.GetActiveScene());
        }
    }

}
