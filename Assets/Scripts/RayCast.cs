using UnityEngine;

public class RayCast : MonoBehaviour
{
    float movementInput;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody2D rb;

    public GameObject groundCheck;

    bool jumpOn;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, -Vector2.up);
        Debug.DrawRay(groundCheck.transform.position, -Vector2.up * hit.distance, Color.red);

        if(hit.collider != null)
        {
            if(hit.distance <= .1)
            {
                jumpOn = true;
            }
            else
            {
                jumpOn = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpOn == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}



