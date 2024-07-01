using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour {
  public bool canUse;

  public void LateUpdate() {
    CheckDistance();
  }

  public void CheckDistance() {
    canUse = true;
    foreach (GameObject tower in RfHolder.Ins.map.tower) {
      // Check if the tower exists before trying to access it
      if (tower != null) {
        float distance = Vector3.Distance(transform.position, tower.transform.position);
        if (distance < 0.5f && !tower.GetComponent<Tower>().isDragging) {
          canUse = false;
          return;
        }
      }
    }
  }
}