using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryPush : MonoBehaviour
{
    private Vector3 center = new Vector3(0, 0, 0);
    private float dist;
    [SerializeField]
    private float foceModifier;

  
    [SerializeField]
    private float boundaryDist1;
    [SerializeField]
    private float boundaryDist2;
    [SerializeField]
    private float boundaryDist3;
    [SerializeField]
    private float boundaryDist4;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector3.Distance(transform.position, center);
        if (dist > boundaryDist4)
        {
            rb.AddForce(new Vector3(-transform.position.x * .01f, 0, -transform.position.z * .01f),ForceMode.Force);
        }
        else if(dist > boundaryDist3)
        {
            rb.AddForce(new Vector3(-transform.position.x *.01f, 0, -transform.position.z*.01f),ForceMode.Force);
        } else if (dist > boundaryDist2)
        {
            rb.AddForce(new Vector3 (-transform.position.x*.01f, 0, -transform.position.z*.01f),ForceMode.Force);
        } else if (dist> boundaryDist1)
        {
            rb.AddForce(new Vector3(-transform.position.x*.01f, 0, -transform.position.z*.01f),ForceMode.Force);
        }
    }
}
