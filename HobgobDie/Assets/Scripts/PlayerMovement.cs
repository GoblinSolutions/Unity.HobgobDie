using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementScalar;
    public float maxSpeed;
    public float jumpScalar;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            var jumpForce = new Vector2(0, jumpScalar);
            rb.AddForce(jumpForce);
        }
    }

    void FixedUpdate() {
       float xMovement = Input.GetAxis("Horizontal");

        if (rb.velocity.magnitude < maxSpeed) 
        {
            var movement = new Vector2(xMovement, 0);
            rb.AddForce(movementScalar * movement);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") 
        {
            isGrounded = false;
        }
    }

    private void OnBecameInvisible() {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
    }
    
}
