using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public float xForce;
    public float yForce;
    public float zForce;
    public float forceModifier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && !collision.gameObject.CompareTag("Tornado"))
        {
            Debug.Log("Triggered");
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(xForce, yForce, zForce),ForceMode.Impulse);
        }
    }*/

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            Rigidbody rb = other.transform.parent.transform.parent.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(xForce*forceModifier, yForce * forceModifier, zForce * forceModifier), ForceMode.Force);
        }
    }
}
