using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnObjects : MonoBehaviour
{
    public float l1Height;
    public float l2Height;
    public float l3Height;
    public float l4Height;
    public float l5Height;
    private IEnumerator coroutine;
    public float spawnDelay;

    [System.Serializable]
    public class objectToSpawn
    {
        public GameObject obj;
        public float distFromCenter;
        public float l1Frequency;
        public float l2Frequency;
        public float l3Frequency;
        public float l4Frequency;
        public float l5Frequency;
        public bool active;
    }
    public objectToSpawn[] objects;


    private void Start()
    {
        coroutine = SpawnTime(spawnDelay);
        StartSpawn();

    }
    IEnumerator SpawnTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private void StartSpawn()
    {
        /*for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].active)
            {
                for (int l1 = 0; l1 <= objects[i].l1Frequency; l1++)
                {
                    Debug.Log(l1);
                    GameObject spawn = Instantiate(objects[i].obj, new Vector3(transform.position.x, l1Height, objects[i].distFromCenter), Quaternion.identity);
                    spawn.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.Impulse);
                }
                for (int l2 = 0; l2 <= objects[i].l2Frequency; l2++)
                {
                    Instantiate(objects[i].obj, new Vector3(transform.position.x, l2Height, objects[i].distFromCenter), Quaternion.identity);
                }
                for (int l3 = 0; l3 <= objects[i].l3Frequency; l3++)
                {
                    Instantiate(objects[i].obj, new Vector3(transform.position.x, l3Height, objects[i].distFromCenter), Quaternion.identity);
                }
                for (int l4 = 0; l4 <= objects[i].l4Frequency; l4++)
                {
                    Instantiate(objects[i].obj, new Vector3(transform.position.x, l4Height, objects[i].distFromCenter), Quaternion.identity);
                }
                for (int l5 = 0; l5 <= objects[i].l5Frequency; l5++)
                {
                    Instantiate(objects[i].obj, new Vector3(transform.position.x, l5Height, objects[i].distFromCenter), Quaternion.identity);
                }
            }
        }*/

    }

}