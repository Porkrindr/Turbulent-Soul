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
            {
                transform.rotation = Quaternion.Euler(forwardRot);
            }
            else
            {
                transform.position += Vector3.forward * moveDist;
            }
    }
    public void MoveBack(float moveDist) { 
            if (transform.rotation != Quaternion.Euler(backRot))
            {
                transform.rotation = Quaternion.Euler(backRot);
            }
            else
            {
                transform.position += Vector3.back * moveDist;
            }
    }

    public void MoveRight(float moveDist)
    {
            if (transform.rotation != Quaternion.Euler(rightRot))
            {
                transform.rotation = Quaternion.Euler(rightRot);
            }
            else
            {
                transform.position += Vector3.right * moveDist;
            }
    }

    public void MoveLeft(float moveDist)
    {
            if (transform.rotation != Quaternion.Euler(leftRot))
            {
                transform.rotation = Quaternion.Euler(leftRot);
            }
            else
            {
                transform.position += Vector3.left * moveDist;
            }
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
