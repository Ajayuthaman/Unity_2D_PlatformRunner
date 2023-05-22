using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("player Components")]
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Player Movements")]
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower; 
    private float wallJumpCoolDown;
    private int numberOfJumps = 0;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Update()
    {
        horizontalInput = SimpleInput.GetAxis("Horizontal");

        //making player sprite left and right while moving left and right
        if(horizontalInput> 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //wall jump
        if(wallJumpCoolDown > 0.2f)
        {


            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if(OnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }


        anim.SetBool("run", horizontalInput!=0);
        anim.SetBool("grounded", IsGrounded());
        anim.SetBool("jump", !IsGrounded());

    }

    public void Jump()
    {
        if (IsGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            numberOfJumps = 0;
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            numberOfJumps++;
            anim.SetBool("jump",true);
        } 
        else if(OnWall() && !IsGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCoolDown = 0;

        }
        else
        {
            if (numberOfJumps == 1)
            {
                SoundManager.instance.PlaySound(jumpSound);
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                numberOfJumps++;
            }
        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return horizontalInput == 0 && IsGrounded();
    }

}
