using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int levitation;
    public static int goodPoints;
    public static int goodPointsCollected;
    public static int soulSaves;
    public static int soulTakes;
    public static bool pauseLevity = false;
    public bool isHit;
    public StageMovement stageMovement;
    public AudioSource stageDownSound;
    public AudioSource stageUpSound;
    [SerializeField]
    private int startStage;
    private GameObject player;
    public int activeStage;
    public GameObject fadeOutPanel;


    [System.Serializable]
    public class ElevationStages
    {
        public int upGoal;
        public int downGoal;
        public bool stageActive;
        public GameObject stageObjects;
        public float rotationSpeed;
        public GameObject stagePrefab;
        public float stageRadius;
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
                        EndingParadise(soulSaves, soulTakes);
                    }
                    else
                    {
                        stage[i + 1].stageObjects.SetActive(true);
                        if (stage[i + 1].stageObjects.transform.childCount < 1)
                        {
                            Instantiate(stage[i + 1].stagePrefab, stage[i + 1].stageObjects.transform);
                        }
                        stageUpSound.Play(0);
                        player.transform.position = new Vector3(0, player.transform.position.y, 0);
                        stage[i].stageActive = false;
                        Destroy(stage[i].stageObjects.gameObject.transform.GetChild(0).gameObject);
                        ResetLevitation();
                        stage[i + 1].stageActive = true;

                        activeStage = i + 1;
                        stageMovement.MoveUp();
                        stage[i].stageObjects.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
                else if (stage[i].stageActive && levitation <= stage[i].downGoal)
                {
                    if (i == 0)
                    {
                        EndingUnderworld(soulSaves, soulTakes);
                    }
                    else
                    {
                        if (stage[i - 1].stageObjects.transform.childCount < 1)
                        {
                            Instantiate(stage[i - 1].stagePrefab, stage[i - 1].stageObjects.transform);
                        }
                        stageDownSound.Play(0);
                        player.transform.position = new Vector3(0, player.transform.position.y, 0);
                        stage[i].stageActive = false;
                        Destroy(stage[i].stageObjects.gameObject.transform.GetChild(0).gameObject);
                        ResetLevitation();
                        activeStage = i - 1;
                        stageMovement.MoveDown();
                        stage[i].stageObjects.transform.GetChild(0).gameObject.SetActive(false);
                        stage[i - 1].stageActive = true;
                    }
                }
            }
        }
    }
    public static void LevitationUpdate(int amount)
    {
        if (pauseLevity == false)
        {
            levitation += amount;
        }
        else
            return;
    }

    void EndingParadise(int save, int take)
    {
        PauseLevity();

        if (take> save )
        {

            SceneManager.LoadScene(4);
        }
        if(save< 2 )
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
        }

    } void EndingUnderworld(int save, int take)
    {
        PauseLevity();

        if ((save >0 || take > 0) )
        {
            SceneManager.LoadScene(6);
        }
        else 
        {
            SceneManager.LoadScene(5);
        }

    }
    private void ResetLevitation()
    {
        levitation = 0;
    }
    public static void PauseLevity()
    {
        pauseLevity = true;
    }
    public static void UnpauseLevity()
    {
        pauseLevity = false;
    }

}
