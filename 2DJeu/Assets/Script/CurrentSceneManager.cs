using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Trop de CurrentSceneManager");
            return;
        }
        instance = this;
    }
}
