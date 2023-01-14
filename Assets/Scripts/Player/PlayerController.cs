using UnityEngine;

namespace bebaSpace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float doubleJumpForce = 6f;
        [SerializeField] private LayerMask groundLayer;
        
        private bool grounded;
        private bool doubleJump;
        private Rigidbody2D rb;
        private Collider2D playerCollider;
    


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.centerOfMass = new Vector3(0, -0.6f, 0);

            playerCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            grounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

            if (rb.velocity.y <= 0  && grounded)
            {
                doubleJump = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (grounded || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpForce : jumpForce);
                    doubleJump = !doubleJump;
                }
            }

        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

       
    }
}
