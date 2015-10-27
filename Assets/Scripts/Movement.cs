using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {
    public GameObject foot;
    private BoxCollider2D footCollider;

    private Rigidbody2D playerRigidBody;

    public float force = 200;
    public float movementSpeed = 2;

    private float direction = 1;

    // Use this for initialization
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        footCollider = foot.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        bool isTouchingGround = footCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || footCollider.IsTouchingLayers(LayerMask.GetMask("Interactable"));

        if (horizontalInput > 0)
            direction = 1;
        if (horizontalInput < 0)
            direction = -1;

        float jumpSpeed = 0;

        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            jumpSpeed = force;
            
        }
        float horizontalSpeed = horizontalInput * movementSpeed;

        playerRigidBody.velocity = new Vector3(horizontalSpeed, playerRigidBody.velocity.y);
        playerRigidBody.AddForce(new Vector2(0, jumpSpeed));
        transform.localScale = new Vector3(direction, 1, 1);
    }
}
