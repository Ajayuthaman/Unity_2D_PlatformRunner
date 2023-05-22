using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDead : MonoBehaviour
{
    private PlayerRespawn playerRespawn;

    private void Start()
    {
        playerRespawn = FindObjectOfType<PlayerRespawn>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            playerRespawn.CheckRespawn();
        }
        
    }
}
