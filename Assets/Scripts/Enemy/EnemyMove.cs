using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public Enemy enemy;
    private bool isPaused = false; 

    private void OnValidate() {
        if (enemy == null) {
            enemy = GetComponent<Enemy>();
        }
    }

    public void FixedUpdate() {
        if (!isPaused) {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ice")) {
            StartCoroutine(PauseMovement());
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator PauseMovement() {
        isPaused = true; 
        yield return new WaitForSeconds(3); 
        isPaused = false; 
    }

    public void Move() {
        for (int i = 0; i < RfHolder.Ins.map.wallmove.Count; i++) {
            if (enemy.index == i) {
                enemy.target = RfHolder.Ins.map.wallmove[i].transform;
                Vector3 targetPosition = enemy.target.position;
                Vector3 currentPosition = transform.position;
                transform.position = Vector3.MoveTowards(currentPosition, targetPosition, enemy.speedMove * Time.deltaTime);
                if (transform.position == targetPosition) {
                    enemy.index++;
                }
                if (targetPosition.x > currentPosition.x) {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                } else if (targetPosition.x < currentPosition.x) {
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }
}
