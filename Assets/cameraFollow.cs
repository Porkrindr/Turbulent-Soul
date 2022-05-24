using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    private Transform cam;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;

    [SerializeField]
    private float followSpeed;

    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            cam.position = new Vector3(target.position.x, target.position.y + yOffset, Mathf.Lerp(cam.position.z, target.position.z + zOffset, Time.deltaTime * followSpeed));
        }
    }
}
