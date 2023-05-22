using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed = 5f;

    private void Update()
    {
        
        Vector2 currentPosition = transform.position;
        float distance = Vector2.Distance(currentPosition, targetPosition);

        
        if (distance > 0.01f)
        {
           
            Vector2 direction = (targetPosition - currentPosition).normalized;

            
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
