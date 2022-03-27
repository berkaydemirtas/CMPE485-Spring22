using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnCollisionEnter(Collision col)  //Unity function called when a collision is detected, and the object collided is put into the variable 'col' to be used later
    {
        if (col.gameObject.tag == "player")
        {
            gameObject.SetActive(false); //increase the size of the ball
        }
    }

}
