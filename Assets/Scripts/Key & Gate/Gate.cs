using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject keyText;
    private Animator anim;

    public bool isKeyCollected=false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player" && isKeyCollected == true)
        {
            anim.SetTrigger("gateOpen");
        }
        else if(collision.tag == "Player" && isKeyCollected == false)
        {
            keyText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        keyText.SetActive(false);
    }
}
