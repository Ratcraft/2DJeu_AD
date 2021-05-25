
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;

    public Rigidbody2D rb;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groudCheckRadius;
    public LayerMask collisionLayers;

    private Vector3 velocity = Vector3.zero;
    public SpriteRenderer SpriteRenderer;
    public CapsuleCollider2D cap;
    public Animator anim;

    private float horizontalMouvement;

    public static MovePlayer instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Trop de player mouvement");
            return;
        }
        instance = this;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){isJumping = true;}

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        anim.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groudCheckRadius, collisionLayers);

        horizontalMouvement = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        Move(horizontalMouvement);
    }

    void Move(float _horizontalmvt)
    {
        Vector3 targetVelocity = new Vector2(_horizontalmvt, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f){SpriteRenderer.flipX = false;}
        else if(_velocity < -0.1f){SpriteRenderer.flipX = true;}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,groudCheckRadius);
    }
}
