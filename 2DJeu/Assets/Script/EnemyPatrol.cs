using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public int damageOnCollision = 20;

    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;

    private Transform target;
    private int destPoint = 1;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        // When enemy reach waypoint
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerhealth = collision.transform.GetComponent<PlayerHealth>();
            playerhealth.TakeDamage(damageOnCollision);
        }
    }
}
