using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundWithPhysics : MonoBehaviour
{
    private GameObject rotationPoint;
    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotationPoint = GameObject.FindGameObjectWithTag("Eye");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(rotationPoint.transform.up * -speed);
        rb.maxAngularVelocity = .2f;
    }
}
