using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyToTargets : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameIsPaused)
        {
            return;
        }
        else {
            transform.position = startPos + new Vector3(0, (Mathf.Sin(Time.time) * moveSpeed), 0);
        }




    }

}
