
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Gate keyCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            keyCollected.isKeyCollected = true;
            gameObject.SetActive(false);
        }

    }
}
