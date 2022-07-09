using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectAnimation : MonoBehaviour
{
    public bool isGrounded;
    public bool isFloating;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 groundPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 baseFloatPos = new Vector3(transform.position.x, (Mathf.Sin(Time.time)*.5f)+ 1, transform.position.z);
        if (isGrounded)
        {
            transform.position = groundPos;
        }else if (isFloating)
        {
            transform.position = baseFloatPos;
        }

    }
}
