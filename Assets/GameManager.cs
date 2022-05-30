using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int levitation;
    public static int goodPoints;
    public static int goodPointsCollected;
    public StageMovement stageMovement;
    public AudioSource stageDownSound;
    public AudioSource stageUpSound;
    [SerializeField]
    private int startStage;
    private GameObject player;
    public int activeStage;


    [System.Serializable]
    public class ElevationStages
    {
        public int upGoal;
        public int downGoal;
        public bool stageActive;
        public GameObject stageObjects;
        public float rotationSpeed;
        public GameObject stagePrefab;
    }
    public ElevationStages[] stage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        stageMovement = GameObject.Find("StageMaster").GetComponent<StageMovement>();
        for (int i = 0; i < stage.Length; i++)
        {
            if (stage[i].stageActive)
            {
                startStage = i;
            }else if (i > startStage) 
            {
                stage[i].stageObjects.SetActive(false);
            }
        }
        activeStage = startStage;
 
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
            for (int i = 0; i < stage.Length; i++)
            {
                if (stage[i].stageActive && levitation >= stage[i].upGoal)
                {
                    if (i + 1 == stage.Length)
                    {
                        EndingParadise(goodPoints, goodPointsCollected);
                    }
                    else
                    {
                        stageUpSound.Play(0);
                        player.transform.position = new Vector3(0, player.transform.position.y, 0);
                        stage[i].stageActive = false;

                        ResetLevitation();
                        stage[i + 1].stageActive = true;
                        stage[i + 1].stageObjects.SetActive(true);
                        if (stage[i + 1].stageObjects.transform.childCount<2)
                        {
                            Instantiate(stage[i + 1].stagePrefab, stage[i + 1].stageObjects.transform);
                        }
                        Destroy(stage[i].stageObjects.gameObject.transform.GetChild(1).gameObject);
                        activeStage = i + 1;
                        stageMovement.MoveUp();
                    }
                }
                else if (stage[i].stageActive && levitation <= stage[i].downGoal)
                {
                    if (i == -1)
                    {
                        EndingUnderworld(goodPoints, goodPointsCollected);
                    }
                    else
                    {
                        stageDownSound.Play(0);
                        player.transform.position = new Vector3(0, player.transform.position.y, 0);
                        stage[i].stageActive = false;

                        ResetLevitation();
                        stage[i - 1].stageActive = true;
                        if (stage[i - 1].stageObjects.transform.childCount <2)
                        {
                            Instantiate(stage[i - 1].stagePrefab, stage[i - 1].stageObjects.transform);
                        }
                        activeStage = i - 1;
                        stage[i].stageObjects.SetActive(false);
                        Destroy(stage[i].stageObjects.gameObject.transform.GetChild(1).gameObject);
                        stageMovement.MoveDown();
                    }
                }
            }
        }
    }
    public static void LevitationUpdate(int amount)
    {
        levitation += amount;
    }

    void EndingParadise(int good, int total)
    {
        float score = good / total;
        if(score> 0.8f && good>1)
        {
            //PerfectEnding()
            Debug.Log("PERFECT ENDING");
        }
        else
        {
            //BadGoodEnding();
            Debug.Log("BAD GOOD ENDING");
        }

    } void EndingUnderworld(int good, int total)
    {
        float score = good / total;
        if(score < 0.2f)
        {
            //EvilEnding()
            Debug.Log("EVIL ENDING");
        }
        else
        {
            //BadBadEnding();
            Debug.Log("BAD BAD ENDING");
        }

    }
    private void ResetLevitation()
    {
        levitation = 0;
    }

}
