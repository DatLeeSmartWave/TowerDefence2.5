using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
    private int countPanelEndGame;
    public void Start() {
        countPanelEndGame = 1;
    }
    public void Update() {
        CheckDistance();
    }

    public void CheckDistance() {
        foreach (GameObject enemy in RfHolder.Ins.map.enemy) {
            if (enemy != null) {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < 1f) {
                    if (countPanelEndGame == 1) {
                        RfHolder.Ins.uiManager.OnPanel(RfHolder.Ins.uiManager.losePanel);
                        Time.timeScale = 0f;
                        countPanelEndGame--;
                    }
                }
            }
        }
    }
}