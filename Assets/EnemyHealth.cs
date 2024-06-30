using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
  public Enemy enemy;

  private void OnValidate() {
    if (enemy == null) {
      enemy = GetComponent<Enemy>();
    }
  }

  public void Start() {
    enemy.currentHealth = enemy.maxHealth;
  }

  public void TakeDamage(int damage) {
    enemy.currentHealth -= damage;
    if (enemy.currentHealth <= 0) {
      Die();
    }
  }

  public void Die() {
    Destroy(gameObject);
    RfHolder.Ins.map.enemy.Remove(gameObject);
  }

  public void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.CompareTag("Bullets")) {
      TakeDamage(col.gameObject.GetComponent<Bullets>().damage);
      Destroy(col.gameObject);
    }
  }
}