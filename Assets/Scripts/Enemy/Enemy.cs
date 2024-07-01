using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  public float speedMove;
  public Transform target;
  public int index;

  public int maxHealth;
  public int currentHealth;

  public int coinMax = 5;
  public int coinMin = 3;
  public int currentCoin;

  public GameObject coinPrefab;
  public void RandomCoin() {
    int coin = UnityEngine.Random.Range(coinMin, coinMax);
    currentCoin = coin;
    Instantiate(coinPrefab, transform.position, Quaternion.identity);
  }
}