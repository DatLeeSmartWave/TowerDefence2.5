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
}