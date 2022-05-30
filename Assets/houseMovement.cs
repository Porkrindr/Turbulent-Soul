using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseMovement : MonoBehaviour
{
    public GameObject house;
    private HouseDamage houseDamage;
    private Transform player;
    private Vector3 currentPos;
    public float targetRange;
    private bool isSlamming;
    private bool isRising;
    public float maxRise;
    public float riseSpeed;
    public float slamSpeed;
    public float moveSpeed;
    public float pauseTime;
    private float timer;
    public float initiateTime;
    private float initiateTimer;
    private bool isJustStarting = true;
    private bool started;
    private AudioSource slamAudio;
    private GameObject stagePrefab;
    private GameObject[] rocks;
    private int rockNum;
    // Start is called before the first frame update
    void Start()
    {
        stagePrefab = transform.parent.gameObject;
        slamAudio = GetComponent<AudioSource>();
        houseDamage = house.GetComponent<HouseDamage>();
        currentPos = transform.position;
        player = GameObject.Find("Player").GetComponent<Transform>();
        isRising = true;
        rockNum = 0;


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
            transform.position = currentPos;

                   // initiateTimer = Time.time + initiateTime;
                   // if (initiateTimer < Time.time)
                   // {
                        if (!isSlamming && transform.position.y > 2)
                        {
                            currentPos = Vector3.MoveTowards(currentPos, new Vector3(player.position.x, currentPos.y, player.position.z), Time.deltaTime * moveSpeed);
                        }
                        if (!isSlamming && !isRising && Vector3.Distance(new Vector3(currentPos.x, currentPos.y, currentPos.z), new Vector3(player.position.x, currentPos.y, player.position.z)) < targetRange)
                        {
                            isSlamming = true;
                            timer = Time.time + pauseTime;
                        }
                        if (isSlamming && timer < Time.time)
                        {
                            currentPos = Vector3.MoveTowards(currentPos, new Vector3(currentPos.x, 0, currentPos.z), Time.deltaTime * slamSpeed);
                        }
                        if (isSlamming && (currentPos.y == 0))
                        {
                            slamAudio.Play(0);
                            isSlamming = false;
                            isRising = true;
                        }
                        if (isRising)
                        {
                            currentPos = Vector3.MoveTowards(currentPos, new Vector3(currentPos.x, maxRise, currentPos.z), Time.deltaTime * riseSpeed);
                        }
                        if (isRising && (currentPos.y == maxRise))
                        {
                            isRising = false;
                        }
            for (int i = 0; i < rocks.Length; i++)
            {
                if (Vector3.Distance(rocks[i].transform.position, currentPos) < 2)
                {
                    houseDamage.TakeDamage();   
                }
            }
                  //  }
        }
    }
}
