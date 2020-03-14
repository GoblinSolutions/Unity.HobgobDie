using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementScalar;
    public float maxSpeed;
    public float jumpScalar;

    private Rigidbody2D rigidBody;
    private bool isGrounded = false;
    private bool isJumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            isJumpPressed = true;
        }
    }

    void FixedUpdate() {
       var xMovement = Input.GetAxis("Horizontal");

        if (rigidBody.velocity.magnitude < maxSpeed) 
        {
            var movement = new Vector2(xMovement, 0);
            rigidBody.AddForce(movementScalar * movement);
        }

        if (isJumpPressed) {
            rigidBody.AddForce(new Vector2(0, jumpScalar));
            isJumpPressed = false;
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
        this.gameObject.transform.position = new Vector3(-7.5f, -1.5f, 0);
        rigidBody.velocity = new Vector2(0, 0);
    }
    
}
