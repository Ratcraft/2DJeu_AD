using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{

    public string sceneName;
    public Animator fade;

    private void Awake()
    {
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fade.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

    }
}
