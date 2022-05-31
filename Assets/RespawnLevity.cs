using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLevity : MonoBehaviour
{
    public float spawnDelay;
    public float timer;
    public float spawnTime;
    private bool timerStarted;
    private int deadCount;
    private bool isSpawning;
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject objectToSpawn;
        public bool timerStarted;
        public float timer;
        public GameObject spawnedObject;
    }
    public SpawnableObject[] spawn;

    public class respawnObject
    {
        public GameObject objectToSpawn;
        public bool isDead;
        public bool timerStarted;
        public float timer;
        public GameObject spawnedObject;
    }
    public respawnObject[] respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawn.Length; i++)
        {
            if(spawn[i].spawnedObject == null && !spawn[i].timerStarted)
            {
                spawn[i].timer = Time.time + spawnDelay;
                spawn[i].timerStarted=true;

            }
            if (spawn[i].timer < Time.time && spawn[i].spawnedObject == null && spawn[i].timerStarted)
            {
                spawn[i].spawnedObject = Instantiate(spawn[i].objectToSpawn, gameObject.transform);
                spawn[i].timerStarted = false;

            }
        }



    }

}

/*respawn[respawn.Length].objectToSpawn = spawn[i].objectToSpawn;
respawn[respawn.Length].timerStarted = spawn[i].timerStarted;
respawn[respawn.Length].timer = spawn[i].timer;
respawn[respawn.Length].spawnedObject = spawn[i].spawnedObject;*/
/*if (spawn.Length == respawn.Length)
{
    timer = spawnTime + Time.time;
    if (timer < Time.time)
    {
        for (int i = 0; i < respawn.Length; i++)
        {
            spawn
        }
    }
}*/


/*if (spawn[i].timer < Time.time && spawn[i].spawnedObject == null)
{
    spawn[i].spawnedObject = Instantiate(spawn[i].objectToSpawn, gameObject.transform);
}*/