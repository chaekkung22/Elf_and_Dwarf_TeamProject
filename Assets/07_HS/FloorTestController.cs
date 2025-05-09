
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTestController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.right);
        }
    }
}
