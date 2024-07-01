using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [Header( "Tower Type")]
    public TowerState towerState;
    public TowerType towerType;
    public enum TowerState{
        Single,
        Merge
    }
    
    public enum TowerType {
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

    [Header("GameObject Merge")] public GameObject Lava;
    public GameObject Steam;
    public GameObject Electric;
    public GameObject Mud;
    public GameObject Ceramic;
    public GameObject Ice;

    [Header("Tower Properties")]
    public int damage;
    public float fireRate;
    public Transform spawnBullets;
    public Transform target;
    public GameObject bulletPrefab;
    public bool isDragging = false;
    public bool canMove = true;
    public Vector3 offset;
    public Vector3 originalPosition;
}
