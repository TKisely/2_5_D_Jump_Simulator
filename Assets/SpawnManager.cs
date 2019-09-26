using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    //public GameObject obstaclePrefab;

    private PlayerController player;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObstacle), startDelay, repeatRate);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomObstacle()
    {
        if (!player.gameOver)
        {
            int chosenIndex = Random.Range(0, obstaclePrefabs.Length);

            Instantiate(obstaclePrefabs[chosenIndex], spawnPosition, obstaclePrefabs[chosenIndex].transform.rotation);
        }
        

        //Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
