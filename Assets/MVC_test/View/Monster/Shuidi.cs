using UnityEngine;
using System.Collections;

public class Shuidi : MonoBehaviour
{
    float t;
    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 3.5)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            t = 0;
        }
    }
}