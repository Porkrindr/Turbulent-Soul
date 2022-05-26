using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float moveDist;
    public float boostDist;
    public float boostCooldown;
    public bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerMovement.MoveForward(moveDist);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerMovement.MoveBack(moveDist);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerMovement.MoveRight(moveDist);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerMovement.MoveLeft(moveDist);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerMovement.Boost(boostDist, boostCooldown);
            }
        }
    }
}
