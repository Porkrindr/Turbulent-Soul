using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerUp : MonoBehaviour
{
    public int levitationAmt;
    public int goodPoints;
    private ParticleSystem levUp;
    private ParticleSystem levDown;
    public ParticleSystem killedFx;
    public AudioSource saveAudio;
    public AudioSource killAudio;
    public AudioSource possessAudio;
    public int soulSaver;
    public int soulTaker;

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
        levUp = GameObject.Find("UpParticle").GetComponent<ParticleSystem>();        
        levDown = GameObject.Find("DownParticle").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.levitation >-5|| GameManager.levitation <5) {
                GameManager.LevitationUpdate(levitationAmt);
            }

            if (canSave)
            {
                saveAudio.Play(0);
                levUp.Play();
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
            else
            {
                possessAudio.Play(0);
                levDown.Play();
            }
        }
    }
}
