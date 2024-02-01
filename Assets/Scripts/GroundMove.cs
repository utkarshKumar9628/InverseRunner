using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float moveSpeed = 5;
    private float leftEdge;
   
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint( Vector3.zero).x -4f ;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < leftEdge)
        { 
        
        Destroy(gameObject);
        }
    }
}
