using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Animation anim;
    private Rigidbody2D rb; 
    private BoxCollider2D boxCollider;

    public GameObject groundCheck;
    private bool jump;

    private void Start()
    {
        anim = GetComponent<Animation>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput*speed,rb.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, -Vector2.up);
        Debug.DrawRay(groundCheck.transform.position, -Vector2.up * hit.distance, Color.red);

        if(hit.collider != null)
        {
            if(hit.distance < 1)
            {
                Debug.Log("Gorunded");
                jump = true;
            }
            else
            {
                jump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump == true)
            {
                rb.velocity = Vector2.up * speed;
            }
        }
        

    }
}
