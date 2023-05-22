using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [HideInInspector]public float currentHealth;
    private bool isDead;

    private Animator anim;

    [Header("Death SOund")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!isDead)
            {
                anim.SetTrigger("die");

                //player
                if(GetComponent<PlayerMovement>() != null)
                {
                    GetComponent<PlayerMovement>().enabled = false;
                }
/*
                //Enemy
                if(GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                    GetComponent<MeleeEnemy>().enabled = false;
                }*/               

                isDead = true;

                SoundManager.instance.PlaySound(deathSound);
            }

        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value , 0, startingHealth);
    }

    public void Respawn()
    {
        SoundManager.instance.PlaySound(deathSound);
        isDead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        GetComponent<PlayerMovement>().enabled = true;
    }
}
