using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDamage : MonoBehaviour
{
    public ParticleSystem takeDmg;
    public ParticleSystem defeated;
    public GameObject house;
    public int health;
    // Start is called before the first frame update
    void Start()
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
                defeated.Play();
                GameManager.levitation += 100;
                Destroy(house, 5f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            if (health > 1)
            {
                takeDmg.Play();
            }
            health--;
        }
    }
}
