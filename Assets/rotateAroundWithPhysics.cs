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
    public bool isRotating;
    public Vector3 rotInput;
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        //rb = GetComponent<Rigidbody>();
        //rotationPoint = GameObject.FindGameObjectWithTag("Eye");
    }

    // Update is called once per frame

    private void Update()
    {
        if (pauseMenu.GameIsPaused)
        {
            return;
        }
        else
        {
            activeStage = gameManager.activeStage;
            speed = gameManager.stage[activeStage].rotationSpeed;
            if (isRotating)
            {
                rot += (new Vector3(0, rotInput.y * speed, 0));
                transform.rotation = Quaternion.Euler(rot);
            }
        }
    }
}
