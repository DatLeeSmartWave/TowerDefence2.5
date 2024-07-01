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
        //StartCoroutine(Attack());
        //Attack();
    }

    public void Attack() {
        if (tower.isDragging == false) {
            //while (true) {
            //yield return new WaitForSeconds(tower.fireRate);

            if (RfHolder.Ins.map.enemy.Count > 0) {
                if (tower.towerType == Tower.TowerType.Fire) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Fire, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Water) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Water, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Flash) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Flash, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Stone) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Stone, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Lava) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Lava, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Steam) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Steam, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Electric) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Electric, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Mud) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Mud, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Ceramic) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Ceramic, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                } else if (tower.towerType == Tower.TowerType.Ice) {
                    GameObject bullets = ObjectPool.Ins.SpawnFromPool(Constants.Bullet_Ice, tower.spawnBullets.position,
                      Quaternion.identity);
                    bullets.GetComponent<Bullets>().target = RfHolder.Ins.map.enemy[0].transform;
                    //}
                }
            }
        }
    }
}