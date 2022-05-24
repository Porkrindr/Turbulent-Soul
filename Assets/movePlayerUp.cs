using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerUp : MonoBehaviour
{
    public int levitationAmt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.LevitationUpdate(levitationAmt);
            Destroy(transform.parent.gameObject);
        }
    }
}
