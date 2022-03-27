using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;



public class coroutine : MonoBehaviour
{

    public float smoothing = 1f;


    void Start()
    {
        StartCoroutine(MyCoroutine(1000f));
    }


    IEnumerator MyCoroutine(float time)
    {

        bool rightOrLeft = false;
        Vector3 left_wall_position = GameObject.FindGameObjectWithTag("left_wall").transform.position;
        Vector3 right_wall_position = GameObject.FindGameObjectWithTag("right_wall").transform.position;

        while (true)
        {
            if(rightOrLeft == false)
            {
                Vector3 temp = transform.position;
                temp.z = Mathf.Lerp((float)temp.z, (float)left_wall_position.z, Time.deltaTime);
                transform.position = temp;

                if (Math.Abs(transform.position.z- left_wall_position.z) < 0.5f)
                {
                    float rnd = Random.Range(1, 3);
                    yield return new WaitForSeconds(rnd);
                    rightOrLeft = true;
                }

                yield return null;
            }

            if (rightOrLeft == true)
            {
                Vector3 temp = transform.position;
                temp.z = Mathf.Lerp((float)temp.z, (float)right_wall_position.z, Time.deltaTime);
                transform.position = temp;
                if (Math.Abs(transform.position.z - right_wall_position.z) < 4.5f)
                {
                    float rnd = Random.Range(1, 3);
                    yield return new WaitForSeconds(rnd);
                    rightOrLeft = false;

                }
                yield return null;
            }

        }

}
}
