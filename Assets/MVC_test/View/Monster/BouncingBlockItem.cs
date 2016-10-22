using UnityEngine;
using System.Collections;
using System;

public class BouncingBlockItem : MonoBehaviour
{

    Vector3 tf;
    double x;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        x += Time.deltaTime;
        tf = GetComponent<Transform>().position;
        tf.y = 1.2f + (float)Math.Sin(x) * 0.5f;
        GetComponent<Transform>().position = tf;
    }
}
