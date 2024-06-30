using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    public Transform target; // The bullet's target
    public float speed = 5f; // The speed at which the bullet moves
    public int damage = 1; // The damage the bullet deals

    public void Update() {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Move the bullet towards the target

            if (Vector3.Distance(transform.position, target.position) <= 0.5f) { // If the bullet is within a certain distance from the target
                target.GetComponent<EnemyHealth>().TakeDamage(damage); // Call the TakeDamage method on the enemy
                Destroy(gameObject); // Destroy the bullet
            }
        } else {
            Destroy(gameObject); // Destroy the bullet if there is no target
        }
    }
}