using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    //TRANSFORM MANAGEMENT MANAGEMENT
    private bool stageUpActive;
    private bool stageDownActive;
    private Vector3 targetStage;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TRANSFOROM MANAGEMENT
        if (stageUpActive && transform.position !=targetStage)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetStage, Time.deltaTime);
        } else if (stageDownActive && transform.position != targetStage)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetStage, Time.deltaTime);
        }
    }

    public void MoveUp()
    {
        Debug.Log("move up");
        stageUpActive = true;
        targetStage = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);

    }
    public void MoveDown()
    {
        stageDownActive = true;
        targetStage = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }
}
