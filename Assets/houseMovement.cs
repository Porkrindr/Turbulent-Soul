using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseMovement : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private Vector3 startPos;
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
    // Start is called before the first frame update
    void Start()
    {
        slamAudio = GetComponent<AudioSource>();
        startPos = transform.position;
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        isRising = true;
        currentPos = transform.position;
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
            if (gameManager.activeStage == 8)
            {
                if (isJustStarting)
                {
                    currentPos = Vector3.MoveTowards(currentPos, new Vector3(-4, 0, 10),20* Time.deltaTime);
                }
                if (!started && currentPos == new Vector3(-4, 0, 10))
                {
                    isJustStarting = false;
                    started = true;
                }
                if (started)
                {
                    initiateTimer = Time.time + initiateTime;
                    if (initiateTimer < Time.time)
                    {
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
                    }
                }
                else
                {
                    transform.localPosition = startPos;
                }
            }
        }
    }
}
