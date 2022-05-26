using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerUp : MonoBehaviour
{
    public int levitationAmt;
    public int goodPoints;
    private ParticleSystem levUp;
    private ParticleSystem levDown;

    [SerializeField]
    private bool canSave;
    [SerializeField]
    private bool canKill;
    [SerializeField]
    private bool isPossessed;

    private void Start()
    {
        levUp = GameObject.Find("UpParticle").GetComponent<ParticleSystem>();        
        levDown = GameObject.Find("DownParticle").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.LevitationUpdate(levitationAmt);

            if (canSave)
            {
                Debug.Log("SAVE ANIMATION");
                levUp.Play();
                GameManager.goodPoints += goodPoints;
            }
            if (canKill)
            {
                Debug.Log("Kill Animation");
                GameManager.goodPoints -= goodPoints;
            }

            if (!isPossessed)
            {
                GameManager.goodPointsCollected++;
                Destroy(transform.parent.gameObject);
            }
            else
            {
                levDown.Play();
            }
        }
    }
}
