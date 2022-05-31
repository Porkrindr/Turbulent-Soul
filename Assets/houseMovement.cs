using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseMovement : MonoBehaviour
{
    public GameObject house;
    private HouseDamage houseDamage;
    private Transform player;
    private Vector3 currentPos;
    private GameManager gameManager;
    private StageMovement stageMovement;
    private bool rocksNeedCounting = true;
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
    private bool started;
    private AudioSource slamAudio;
    private GameObject stagePrefab;
    // Start is called before the first frame update
    void Start()
    {
        stageMovement = GameObject.Find("StageMaster").GetComponent<StageMovement>();
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        stagePrefab = transform.parent.gameObject;
        slamAudio = GetComponent<AudioSource>();
        houseDamage = house.GetComponent<HouseDamage>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        isRising = true;
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

            if (gameManager.activeStage == 5 && !stageMovement.isMoving)
            {
                if (gameManager.activeStage == 5 && rocksNeedCounting)
                {
                    GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
                    rocksNeedCounting = false;
                }
                else if (gameManager.activeStage != 5)
                {
                    rocksNeedCounting = true;
                }
                else
                {
                    GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
                    for (int i = 0; i < rocks.Length; i++)
                    {
                        if (Vector3.Distance(rocks[i].transform.position, currentPos) < 3 && currentPos.y<0.5f)
                        {
                            Debug.Log("HOUSE DAMAGE");
                            houseDamage.TakeDamage();
                        }
                    }
                }

                if (houseDamage.isDefeated && transform.position.y != 0)
                {
                    currentPos = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.y), Time.deltaTime * riseSpeed);
                }
                else
                {

                    if (!isSlamming && transform.position.y > 2)
                    {
                        currentPos = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), Time.deltaTime * moveSpeed);
                    }
                    if (!isSlamming && !isRising && Vector3.Distance(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(player.position.x, currentPos.y, player.position.z)) < targetRange)
                    {
                        isSlamming = true;
                        timer = Time.time + pauseTime;
                    }
                    if (isSlamming && timer < Time.time)
                    {
                        currentPos = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), Time.deltaTime * slamSpeed);
                    }
                    if (isSlamming && (transform.position.y == 0))
                    {
                        slamAudio.Play(0);
                        isSlamming = false;
                        isRising = true;
                    }
                    if (isRising)
                    {
                        currentPos = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, maxRise, transform.position.z), Time.deltaTime * riseSpeed);
                    }
                    if (isRising && (transform.position.y == maxRise))
                    {
                        isRising = false;
                    }
                }
                transform.position = currentPos;
            }


            
        }
    }
}
