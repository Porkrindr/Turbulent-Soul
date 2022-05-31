using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private GameManager gameManager;
    public float moveDist;
    public float speed;
    public float defaultSpeed;
    public float runSpeed;
    public bool isPlaying;
    private StageMovement stageMovement;
    public float hitTimer;
    public float noHitTime;
    private Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        playerMovement = GetComponent<PlayerMovement>();
        isPlaying = true;
        stageMovement = GameObject.Find("StageMaster").GetComponent<StageMovement>() ;
        center = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlaying && !stageMovement.isMoving && !pauseMenu.GameIsPaused)
        {
            if (Vector3.Distance(transform.position, center) >= (gameManager.stage[gameManager.activeStage].stageRadius))
            {
                transform.position =Vector3.MoveTowards(transform.position, center, .1f);
            }
            else
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
}
