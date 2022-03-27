using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{

    bool isCollected = false;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(-0.02f, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.02f, 0, 0));
        }
        if(transform.position.x > -12)
        {
            if (isCollected)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "You won. Press to play again!";
                button.gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionEnter(Collision col)  //Unity function called when a collision is detected, and the object collided is put into the variable 'col' to be used later
    {
        if (col.gameObject.tag == "coin")
        {
            isCollected = true;
        }

        if (col.gameObject.tag == "barrier1")
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "You lost. Press to play again!";
            button.gameObject.SetActive(true);
        }
    }
}
