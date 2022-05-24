using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationController : MonoBehaviour
{
    public static int _elevationSpeed;
    public float elevationAmtModifier;

    void Update()
    {
        transform.position += new Vector3(0, _elevationSpeed * elevationAmtModifier, 0);
    }
}
