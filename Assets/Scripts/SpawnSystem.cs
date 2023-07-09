using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject obj;
    public float minTime, maxTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        int randomIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(obj, SpawnPoints[randomIndex].position, transform.rotation);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(spawn());
    }
}
