using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    

    private Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        platformMovement();
    }

    void platformMovement()
    {
        if (transform.position == pointA.position)
        {
            targetPosition = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            targetPosition = pointA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
