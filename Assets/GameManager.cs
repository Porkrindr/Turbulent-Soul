using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int levitation;
    public static int goodPoints;
    public static int goodPointsCollected;
    public StageMovement stageMovement;
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
                    player.transform.position = new Vector3(0, player.transform.position.y, 0);
                    stage[i].stageActive = false;
                    stage[i + 1].stageActive = true;
                    stage[i + 1].stageObjects.SetActive(true);
                    activeStage = i + 1;
                    stageMovement.MoveUp();
                }
            }
            else if (stage[i].stageActive && levitation <= stage[i].downGoal)
            {
                if (i == 0)
                {
                    EndingUnderworld(goodPoints, goodPointsCollected);
                }
                else
                {
                    player.transform.position = new Vector3(0, player.transform.position.y, 0);
                    stage[i].stageActive = false;
                    stage[i - 1].stageActive = true;
                    activeStage = i - 1;
                    stage[i].stageObjects.SetActive(false);
                    stageMovement.MoveDown();
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
        if(good> 0.8f)
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
        if(good< 0.2f)
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

}
