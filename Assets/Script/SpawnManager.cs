using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclesPrefabs;
    // Spawn clones at this point
    private Vector3 spawnPos = new Vector3(25, 0, 0); 
    private float startDelay = 2;
    private float repeatRate = 2;
    
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    void SpawnObstacles()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclesPrefabs, spawnPos, obstaclesPrefabs.transform.rotation);
        }
    }
}
