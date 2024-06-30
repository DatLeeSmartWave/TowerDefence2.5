using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour {
  public Tower tower;

  public void OnValidate() {
    if (tower == null) {
      tower = GetComponent<Tower>();
    }
  }

  public void Start() {
    StartCoroutine(Attack());
  }

  public IEnumerator Attack() {
    while (true) {
      yield return new WaitForSeconds(tower.fireRate); // Wait for fireRate seconds

      if (RfHolder.Ins.map.enemy.Count > 0) {
        GameObject bullet = Instantiate(tower.bulletPrefab, tower.spawnBullets.position, Quaternion.identity);
        bullet.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
      }
    }
  }
}