using UnityEngine;

public class Player : MonoBehaviour
{
    private float movement;
    public  float moveSpeed = 5f;
    private bool  facingRight;

    public float jumpHeight = 7f;
    public Rigidbody2D rb;
    private bool isGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        facingRight = true;
        isGround = true;
    }

    // Update is called once per frame
    void Update() {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement * Time.deltaTime * moveSpeed,0f,0f);

        if (movement < 0f && facingRight == true)
        {
            transform.eulerAngles = new Vector3(0f, -180, 0f);
            facingRight = false;
        }

        else if (movement > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            isGround = true;
        }

        void Jump() {
            Vector2 velocity = rb.linearVelocity;
            velocity.y = jumpHeight;
            rb.linearVelocity = velocity;
        }

        // private (en caso de que algo falle usar esto al inicio de a linea)
        void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Ground")
            {
                isGround = true;
            }
        }
    }
}
