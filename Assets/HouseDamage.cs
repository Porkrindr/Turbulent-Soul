using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDamage : MonoBehaviour
{
    public AudioSource defeatSound;
    public ParticleSystem takeDmg;
    public ParticleSystem defeated;
    public GameObject house;
    public int health;
    private float timer;
    public float invincibleTimer;
    private float finalTimer;
    public float finalTime;
    public bool isDefeated;
    private void Start()
    {
        
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
            if (health <= 0)
            {
                if (!isDefeated)
                {
                    StartFinalTimer();
                    GameManager.PauseLevity();
                    defeated.Play();
                    isDefeated= true;
                }

                if (finalTimer < Time.time)
                {
                    GameManager.UnpauseLevity();
                    GameManager.LevitationUpdate(100);
                    Destroy(house, 1f);
                }
            }
        }
    }

    public void TakeDamage()
    {
        if (timer < Time.time)
        {
            if (health > 1)
            {

                takeDmg.Play();
            }
            health--;
            timer = Time.time + invincibleTimer;
        }
    }
    void StartFinalTimer()
    {
            finalTimer = finalTime + Time.time;
            isDefeated = true;
    }
}
