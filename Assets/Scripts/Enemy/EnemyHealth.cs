using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public Enemy enemy;
    public GameObject[] iconTowers;
    [Range(0, 100)]
    float spawnProbability = 50f;

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
            CheckListEnemy();
            Die();
        }
    }

    public void Die() {
        SpawnRandomIconTower();
        enemy.RandomCoin();
        Destroy(gameObject);
        RfHolder.Ins.map.enemy.Remove(gameObject);
        CheckListEnemy();
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Bullets")) {
            TakeDamage(col.gameObject.GetComponent<Bullets>().damage);
            Destroy(col.gameObject);
        }
    }

    public void CheckListEnemy() {
        if (RfHolder.Ins.map.enemy.Count == 0) {
            RfHolder.Ins.uiManager.OnPanel(RfHolder.Ins.uiManager.winPanel);

            int currentLevel = RfHolder.Ins.mapControllerData.currentLevel;
            int passedLevel = PlayerPrefs.GetInt(Constants.PassedLevel, 0);
            if (currentLevel >= passedLevel) {
                PlayerPrefs.SetInt(Constants.PassedLevel, currentLevel + 1);
            }
            if(passedLevel >= currentLevel) {
                GainAward();
            }
            Time.timeScale = 0f;
        }
    }

    void GainAward() {
        int amount = PlayerPrefs.GetInt("Coin") + 500;
        PlayerPrefs.SetInt("Coin", amount);
    }

    private void SpawnRandomIconTower() {
        float randomValue = UnityEngine.Random.Range(0f, 100f);
        if (randomValue < spawnProbability) {
            int randomIndex = UnityEngine.Random.Range(0, iconTowers.Length);
            Instantiate(iconTowers[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
