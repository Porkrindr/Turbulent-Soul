using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float moveDist;
    public float speed;
    public float defaultSpeed;
    public float runSpeed;
    public bool isPlaying;
    private StageMovement stageMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        isPlaying = true;
        stageMovement = GameObject.Find("StageMaster").GetComponent<StageMovement>() ;
    }

    // Update is called once per frame
    void Update()
    {

            if (isPlaying && !stageMovement.isMoving && !pauseMenu.GameIsPaused)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
            }
            else
            {
                speed = defaultSpeed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                playerMovement.MoveForward(moveDist * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerMovement.MoveBack(moveDist * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerMovement.MoveRight(moveDist * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerMovement.MoveLeft(moveDist * speed);
            }
        }
    }
}
