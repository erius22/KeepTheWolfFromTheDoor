﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<GameObject> ghostSpawns;
    public List<GameObject> wolfSpawns;
    public List<GameObject> vampireSpawns;
    public GameObject bombSpawn;
    public Light lightBomb;

    public float initialWolfSpawnTime = 120;
    public float initialVampireSpawnTime = 240;

    public float ghostSpawnTime = 2;

    public float wolfSpawnTime = 2;

    public float vampireSpawnTime = 2;

    public float spawnTimeBomb = 1;

    public GameObject ghostPrefab;
    public GameObject wolfPrefab;
    public GameObject vampirePrefab;

    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnGhost(5));
        StartCoroutine(spawnWolf(initialWolfSpawnTime));
        StartCoroutine(spawnVampire(initialVampireSpawnTime));
        StartCoroutine(spawnBomb(spawnTimeBomb));

    }

    private IEnumerator spawnGhost(float a_Delay)
    {

        yield return new WaitForSeconds(a_Delay);
        float t_NewDelay = ghostSpawnTime;

        int t_SpawnPoint = Random.Range(0, ghostSpawns.Count);
        Instantiate(ghostPrefab, ghostSpawns[t_SpawnPoint].transform.position, Quaternion.identity);

        StartCoroutine(spawnGhost(a_Delay));
    }
    private IEnumerator spawnWolf(float a_Delay)
    {
        yield return new WaitForSeconds(a_Delay);

        float t_NewDelay = wolfSpawnTime;
        int t_SpawnPoint = Random.Range(0, wolfSpawns.Count);
        
        Instantiate(wolfPrefab, wolfSpawns[t_SpawnPoint].transform.position, Quaternion.identity);
        StartCoroutine(spawnWolf(t_NewDelay));
    }
    private IEnumerator spawnVampire(float a_Delay)
    {
        yield return new WaitForSeconds(a_Delay);
        float t_NewDelay = vampireSpawnTime;
        int t_SpawnPoint = Random.Range(0, vampireSpawns.Count);
        Instantiate(vampirePrefab, vampireSpawns[t_SpawnPoint].transform.position, Quaternion.identity);

        StartCoroutine(spawnVampire(t_NewDelay));
    }

    private IEnumerator spawnBomb(float a_Delay) {
        yield return new WaitForSeconds(a_Delay);
        Debug.Log("BOMB");
        float t_NewDelay = 60;
        Instantiate(bombPrefab, bombSpawn.transform.position, Quaternion.Euler(0, 90, 0));
        Instantiate(lightBomb, bombSpawn.transform.position, Quaternion.Euler(110, 0, 0));

        StartCoroutine(spawnBomb(t_NewDelay));

    }

    public void raiseTimeSpawn()
    {
        ghostSpawnTime--;
        vampireSpawnTime--;

        if (ghostSpawnTime <= 0)
        {
            ghostSpawnTime = 0;
        }
        if (vampireSpawnTime <= 0)
        {
            vampireSpawnTime = 0;
        }
        
            
       
        

        
    }
}