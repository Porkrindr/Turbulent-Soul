using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int levitation;
    public StageMovement stageMovement;
    [SerializeField]
    private int startStage;


    [System.Serializable]
    public class ElevationStages
    {
        public int upGoal;
        public int downGoal;
        public bool stageActive;
        public GameObject stageObjects;
    }
    public ElevationStages[] stage;
    // Start is called before the first frame update
    void Start()
    { 
        stageMovement = GameObject.Find("StageMaster").GetComponent<StageMovement>();
        for (int i = 0; i < stage.Length; i++)
        {
            if (stage[i].stageActive)
            {
                startStage = i;
            }else if (i > startStage) 
            { 
                stage[i].stageObjects.GetComponent<StageVisibility>().isVisible = false;
            }
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stage.Length; i++)
        {
            if (stage[i].stageActive && levitation >= stage[i].upGoal)
            {
                stage[i].stageActive = false;
                stage[i + 1].stageActive = true;
                stageMovement.MoveUp();
            }
            else if (stage[i].stageActive && levitation <= stage[i].downGoal)
            {
                stage[i].stageActive = false;
                stage[i - 1].stageActive = true;
                stageMovement.MoveDown();
            }
        }
    }
    public static void LevitationUpdate(int amount)
    {
        levitation += amount;
    }

}
