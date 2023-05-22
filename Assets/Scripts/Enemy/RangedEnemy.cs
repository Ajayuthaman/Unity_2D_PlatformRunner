using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bombs;

    [Header("Colliders")]
    [SerializeField] private float colliderDistance;
    public BoxCollider2D boxCollider;

    [Header("Player Layer")]
    public LayerMask playerLayer;

    private float coolDownTimer = Mathf.Infinity;
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        coolDownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
           
            if (coolDownTimer >= attackCoolDown)
            {
                coolDownTimer = 0;
                anim.SetTrigger("RangedAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();


    }

    private void RangedAttack()
    {
        coolDownTimer = 0;

        bombs[FindBombs()].transform.position = firePoint.position;
        bombs[FindBombs()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindBombs()
    {
        for(int i = 0; i < bombs.Length; i++)
        {
            if (!bombs[i].activeInHierarchy)
                return i;
        }

        return 0;
    }
    public void Desable()
    {
        gameObject.SetActive(false);
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
