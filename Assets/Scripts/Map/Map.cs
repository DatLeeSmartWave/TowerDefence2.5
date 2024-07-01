using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
  [Header("List")] public List<GameObject> wallmove = new List<GameObject>();
  public List<GameObject> walluse = new List<GameObject>();
  public List<GameObject> wallnotuse = new List<GameObject>();
  public List<GameObject> enemy = new List<GameObject>();
  public List<GameObject> tower = new List<GameObject>();

  [Header("Parent")] public GameObject wallparent;
  public GameObject walluseparent;
  public GameObject wallnotuseparent;
  public GameObject enemyParent;

  [Header("Start and End Point of Path")]
  public Transform startPoint;

  public Transform endPoint;

  [Header("Enemy Prefabs")] public GameObject enemyPrefabs;
  public GameObject boss;

  [Header("Number of Enemy Spawn")] public int numberEnemySpawn;
  public int currentEnemySpawn;
  public float timeToSpawn = 1f;

  [Header("Panel")] public GameObject darkPanel;
  public void Awake() {
    RfHolder.Ins.darkPanel = darkPanel;
    RfHolder.Ins.map = this;
    wallparent = GameObject.Find("Wall");
    walluseparent = GameObject.Find("Use");
    wallnotuseparent = GameObject.Find("NotUse");
    
    foreach (Transform child in wallparent.transform) {
      wallmove.Add(child.gameObject);
    }

    foreach (Transform child in walluseparent.transform) {
      walluse.Add(child.gameObject);
    }

    foreach (Transform child in wallnotuseparent.transform) {
      wallnotuse.Add(child.gameObject);
    }

    numberEnemySpawn = 10;
    currentEnemySpawn = 0;
  }


  public void Start() {
    //StartCoroutine(SpawnEnemy());
  }

  public IEnumerator SpawnEnemy() {
    if (currentEnemySpawn < numberEnemySpawn) {
      while (currentEnemySpawn < numberEnemySpawn) {
        GameObject enemyToSpawn;
        if (currentEnemySpawn == 9) {
          enemyToSpawn = boss;
        } else {
          enemyToSpawn = enemyPrefabs;
        }
        GameObject enemySpawn = Instantiate(enemyToSpawn, startPoint.position, Quaternion.identity);
        enemySpawn.transform.SetParent(enemyParent.transform);
        enemy.Add(enemySpawn);
        currentEnemySpawn++;
        yield return new WaitForSeconds(timeToSpawn);
      }
    }
  }
}