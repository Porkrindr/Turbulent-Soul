using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundWithPhysics : MonoBehaviour
{
    private GameObject rotationPoint;
    private Rigidbody rb;
    private float speed;
    private GameManager gameManager;
    private int activeStage;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rotationPoint = GameObject.FindGameObjectWithTag("Eye");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(rotationPoint.transform.up * -speed);
        rb.maxAngularVelocity = .2f;
    }
    private void Update()
    {
        activeStage = gameManager.activeStage;
        speed = gameManager.stage[activeStage].rotationSpeed;
    }
}
