using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkPointSound;
    private Transform currentCheckPoint; //store the last CheckPoint
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {

        //check if any checkpoints available
        if(currentCheckPoint == null)
        {            
            uiManager.GameOver();
            return;
        }

        transform.position = currentCheckPoint.position;

        playerHealth.Respawn();

    }

    //Activate CheckPoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckPoint = collision.transform;//storing the checkpoint position
            SoundManager.instance.PlaySound(checkPointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }


}
