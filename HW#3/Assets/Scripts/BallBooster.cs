using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBooster : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction = new Vector3(-5, 0, 0);
    private Vector3 startPos;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    void OnCollisionEnter(Collision col)  //Unity function called when a collision is detected, and the object collided is put into the variable 'col' to be used later
    {
        if (col.gameObject.tag == "brick_wall")  
        {
            transform.localScale += new Vector3(3, 3, 3); //increase the size of the ball
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction);
    }
}
