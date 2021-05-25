using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{

    private Transform playerSpawn;
    private Animator fade;

    void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fade = GameObject.FindGameObjectWithTag("Fade").transform.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fade.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
        PlayerHealth.instance.TakeDamage(25);
    }
}