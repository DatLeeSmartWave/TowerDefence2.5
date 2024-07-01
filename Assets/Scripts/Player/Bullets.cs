using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    public BulletType bulletType;
    public enum BulletType {
        Fire,
        Water,
        Stone,
        Flash,
        Lava,
        Steam,
        Electric,
        Mud,
        Ceramic,
        Ice,
    }
    
    public Transform target;
    public float speed = 5f; 
    public int damage = 1; 

    public void Update() {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.5f) { 
                target.GetComponent<EnemyHealth>().TakeDamage(damage);
                if (bulletType == BulletType.Fire) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Fire, gameObject);
                } else if (bulletType == BulletType.Water) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Water, gameObject);
                } else if (bulletType == BulletType.Stone) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Stone, gameObject);
                } else if (bulletType == BulletType.Flash) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Flash, gameObject);
                } else if (bulletType == BulletType.Lava) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Lava, gameObject);
                } else if (bulletType == BulletType.Steam) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Steam, gameObject);
                } else if (bulletType == BulletType.Electric) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Electric, gameObject);
                } else if (bulletType == BulletType.Mud) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Mud, gameObject);
                } else if (bulletType == BulletType.Ceramic) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Ceramic, gameObject);
                } else if (bulletType == BulletType.Ice) {
                    ObjectPool.Ins.ReturnToPool(Constants.Bullet_Ice, gameObject);
                }
            }
        } else if (target == null) {
            //return pool
            if (bulletType == BulletType.Fire) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Fire, gameObject);
            } else if (bulletType == BulletType.Water) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Water, gameObject);
            } else if (bulletType == BulletType.Stone) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Stone, gameObject);
            } else if (bulletType == BulletType.Flash) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Flash, gameObject);
            } else if (bulletType == BulletType.Lava) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Lava, gameObject);
            } else if (bulletType == BulletType.Steam) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Steam, gameObject);
            } else if (bulletType == BulletType.Electric) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Electric, gameObject);
            } else if (bulletType == BulletType.Mud) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Mud, gameObject);
            } else if (bulletType == BulletType.Ceramic) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Ceramic, gameObject);
            } else if (bulletType == BulletType.Ice) {
                ObjectPool.Ins.ReturnToPool(Constants.Bullet_Ice, gameObject);
            }
        }
    }
}