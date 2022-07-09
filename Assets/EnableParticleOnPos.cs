using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableParticleOnPos : MonoBehaviour
{
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var em = ps.emission;
        if (transform.position.y < 5 && transform.position.y > -5)
        {
            em.enabled = true;

        }
        else { em.enabled = false; }
    }
}
