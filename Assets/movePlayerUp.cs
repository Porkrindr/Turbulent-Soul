using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerUp : MonoBehaviour
{
    public int levitationAmt;
    public int goodPoints;
    public GameManager gameManager;
    private ParticleSystem levUp;
    private ParticleSystem levDown;
    public ParticleSystem killedFx;
    public AudioSource saveAudio;
    public AudioSource killAudio;
    public AudioSource possessAudio;
    public int soulSaver;
    public int soulTaker;
    public bool isSoulLessie;
    public bool isSoulTofu;

    [SerializeField]
    private bool canSave;
    [SerializeField]
    private bool canKill;
    [SerializeField]
    private bool isPossessed;

    private void Awake()
    {
        saveAudio = GameObject.Find("saveAudio").GetComponent<AudioSource>();
        killAudio = GameObject.Find("killAudio").GetComponent<AudioSource>();
        possessAudio = GameObject.Find("possAudio").GetComponent<AudioSource>();
    }
    private void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        levUp = GameObject.Find("UpParticle").GetComponent<ParticleSystem>();        
        levDown = GameObject.Find("DownParticle").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.transform.parent.transform.parent.GetComponent<PlayerController>();
            if (GameManager.levitation >-5|| GameManager.levitation <5) {
                GameManager.LevitationUpdate(levitationAmt);
            }

            if (canSave)
            {
                saveAudio.Play(0);
                levUp.Play();
                if (isSoulLessie)
                {
                    GameManager.isSoulLessieActive = false;
                }
                if (isSoulTofu)
                {
                    GameManager.isSoulTofuActive = false;
                }
                GameManager.goodPoints += goodPoints;
            }
            if (canKill)
            {
                killAudio.Play(0);
                killedFx.Play();
                GameManager.goodPoints -= goodPoints;
            }

            if (!isPossessed)
            {
                GameManager.soulSaves += soulSaver;
                GameManager.soulTakes += soulTaker;
                GameManager.goodPointsCollected++;
                Destroy(transform.parent.gameObject);
            }
            else if (player.hitTimer<Time.time)
            {
                player.hitTimer = player.noHitTime + Time.time;
                levDown.Play();
                possessAudio.Play();
            }
        }
    }
}
