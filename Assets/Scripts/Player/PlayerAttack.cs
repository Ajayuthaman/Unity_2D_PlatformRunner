using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;
    public PlayerMovement playerMovement;
    [SerializeField] private AudioClip bowSound;

    [Header("Attack")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;
    private float coolDownTimer = Mathf.Infinity;



    private void Update()
    {
/*        if (Input.GetMouseButton(0) && coolDownTimer > attackCoolDown && playerMovement.CanAttack())
        {

            Attack();
        }*/
        coolDownTimer += Time.deltaTime;
    }
    public void AttackButton()
    {
        if (coolDownTimer > attackCoolDown && playerMovement.CanAttack())
        {

            Attack();
        }
    }

    public void Attack()
    {
        
        anim.SetTrigger("attack");
        coolDownTimer = 0;

        fireBalls[FindFireBall()].transform.position = firePoint.position;
        fireBalls[FindFireBall()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
        SoundManager.instance.PlaySound(bowSound);
    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireBalls.Length;i++)
        {
            if (!fireBalls[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

}
