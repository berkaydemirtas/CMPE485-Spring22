using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Awake method is always called before application starts.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update method is called in every frame.");
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, 1, ForceMode.Impulse);
    }

}
