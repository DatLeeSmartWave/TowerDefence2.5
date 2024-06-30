using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
  public Enemy enemy;

  private void OnValidate() {
    if (enemy == null) {
      enemy = GetComponent<Enemy>();
    }
  }

  public void FixedUpdate() {
    Move();
  }

  public void Move() {
    for (int i = 0; i < RfHolder.Ins.map.wallmove.Count; i++) {
      if (enemy.index == i) {
        enemy.target = RfHolder.Ins.map.wallmove[i].transform;
        transform.position = Vector3.MoveTowards(transform.position, enemy.target.position, enemy.speedMove * Time.deltaTime);
        if (transform.position == enemy.target.position) {
          enemy.index++;
        }
      }
    }
  }
}