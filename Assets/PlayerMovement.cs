using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float timer = 0;

    private Vector3 forwardRot = new Vector3(0, 0, 0);
    private Vector3 backRot = new Vector3(0, 180, 0);
    private Vector3 rightRot = new Vector3(0, 90, 0);
    private Vector3 leftRot = new Vector3(0, 270, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveForward(float moveDist)
    {

            if (transform.rotation != Quaternion.Euler(forwardRot))
            
                transform.rotation = Quaternion.Euler(forwardRot);
            
                transform.position += Vector3.forward * moveDist * Time.deltaTime;
            
    }
    public void MoveBack(float moveDist) { 

                transform.rotation = Quaternion.Euler(backRot);

                transform.position += Vector3.back * moveDist*Time.deltaTime;

    }

    public void MoveRight(float moveDist)
    {

                transform.rotation = Quaternion.Euler(rightRot);

                transform.position += Vector3.right * moveDist * Time.deltaTime;

    }

    public void MoveLeft(float moveDist)
    {

                transform.rotation = Quaternion.Euler(leftRot);
         
                transform.position += Vector3.left * moveDist* Time.deltaTime;
    
    }
    public void Boost(float boostDist, float boostCooldown)
    {
         if(timer <= Time.time)
        {
            //transform.position = transform.forward * boostDist;
            //timer = Time.time + boostCooldown;
        }
    }
}
