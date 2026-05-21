using UnityEngine;

public class Player : MonoBehaviour
{
    private float movement;
    public  float moveSpeed = 5f;
    private bool  facingRight;

    public  float       jumpHeight = 7f;
    private bool        isGround;

    public int currentCoin;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        facingRight = true;
        isGround = true;
        currentCoin = 0;
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
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

        if (Mathf.Abs(movement) > .1f)
        {
            animator.SetFloat("Walk", 1f);
        }
        else if (movement < .1f)
        {
            animator.SetFloat("Walk", 0f);
        }
    }
        void Jump() {
            animator.SetBool("Jump", true);

            Vector2 velocity = rb.linearVelocity;
            velocity.y = jumpHeight;
            rb.linearVelocity = velocity;
        }

        // private (en caso de que algo falle usar esto al inicio de a linea)
        private void OnCollisionEnter2D(Collision2D collision) {

            if (collision.gameObject.tag == "Ground")
            {
                isGround = true;
                animator.SetBool("Jump", false);
            }

            if (collision.gameObject.tag == "Enemy")
            {
                FindAnyObjectByType<GameManage>().ReloadLevel();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "coin")
            {
                currentCoin++;
                Destroy(collision.gameObject);;
            }
        }

}
