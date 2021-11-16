using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;

    bool stop;
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

   
    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
            GeneratePosition();
            Instantiate(platform, newPosition, Quaternion.identity);
            lastPosition = newPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }
    private void GeneratePosition()
    {
        newPosition = lastPosition;
        int rand = Random.Range(0, 2);
        if(rand > 0)
        {
            newPosition.x += 2f;
        }
        else
        {
            newPosition.z += 2f;
        }
    }
}
