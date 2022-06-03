using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    //TRANSFORM MANAGEMENT MANAGEMENT
    private bool stageUpActive;
    private bool stageDownActive;
    private Vector3 targetStage;
    public int stageInterval;
    private Transform player;
    public Vector3 playerRot;
    private Vector3 rot;
    public bool isMoving;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameIsPaused)
        {
            return;
        }
        else
        {
            //TRANSFOROM MANAGEMENT
            if (stageUpActive && transform.position != targetStage)
            {
                isMoving = true;
                transform.position = Vector3.MoveTowards(transform.position, targetStage, 3 * Time.deltaTime);
                rot += playerRot;
                player.rotation = Quaternion.Euler(rot);
                player.position = Vector3.zero;
            }
            else if (stageDownActive && transform.position != targetStage)
            {
                isMoving = true;
                rot -= playerRot;
                player.rotation = Quaternion.Euler(rot);
                player.position = Vector3.zero;
                transform.position = Vector3.MoveTowards(transform.position, targetStage, 3 * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
    }

    public void MoveUp()
    {
        stageUpActive = true;
        targetStage = new Vector3(transform.position.x, transform.position.y - stageInterval, transform.position.z);

    }
    public void MoveDown()
    {
        stageDownActive = true;
        targetStage = new Vector3(transform.position.x, transform.position.y + stageInterval, transform.position.z);
    }
}
