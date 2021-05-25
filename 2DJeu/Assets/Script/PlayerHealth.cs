using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public SpriteRenderer graphics;
    public bool isInvincible = false;

    private float invinciblitydelay = 0.15f;
    private float invinciblitydelayafter = 2f;

    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Trop de player health");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void HealPlayer(int amount)
    {
        if(currentHealth + amount >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void TakeDamage(int dmg)
    {
        if(!isInvincible)
        {
            currentHealth -= dmg;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        MovePlayer.instance.enabled = false;
        MovePlayer.instance.anim.SetTrigger("Death");
        MovePlayer.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        MovePlayer.instance.rb.velocity = Vector3.zero;
        MovePlayer.instance.cap.enabled = false;
        GameOverManager.instance.OnPlayerDeath();

    }

    public void Respawn()
    {
        MovePlayer.instance.enabled = true;
        MovePlayer.instance.anim.SetTrigger("Respawn");
        MovePlayer.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        MovePlayer.instance.cap.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invinciblitydelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invinciblitydelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invinciblitydelayafter);
        isInvincible = false;
    }
}
