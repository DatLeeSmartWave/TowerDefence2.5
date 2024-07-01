using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour {
  public Tower tower;
  public TowerAttack towerAttack;

  private void OnValidate() {
    tower = tower ?? GetComponent<Tower>();
    towerAttack = towerAttack ?? GetComponent<TowerAttack>();
  }

  private void OnMouseDown() {
    tower.isDragging = true;
    tower.offset = transform.position - GetMouseWorldPos();
    tower.originalPosition = transform.position;
  }

  private void OnMouseDrag() {
    if (tower.canMove && tower.isDragging) {
      transform.position = GetMouseWorldPos() + tower.offset;
    }
  }

  private void OnMouseUp() {
    if (!tower.canMove) return;

    tower.isDragging = false;
    GameObject closestWallUse = null;
    float closestDistance = Mathf.Infinity;

    foreach (GameObject wallUse in RfHolder.Ins.map.walluse) {
      float distance = Vector3.Distance(transform.position, wallUse.transform.position);
      if (distance < closestDistance) {
        closestDistance = distance;
        closestWallUse = wallUse;
      }
    }

    CheckForTowerMerge();

    if (closestWallUse != null && closestDistance < 0.5f) {
      transform.position = closestWallUse.GetComponent<WallSpawn>().canUse
        ? closestWallUse.transform.position
        : tower.originalPosition;
    }
    else {
      transform.position = tower.originalPosition;
    }
  }

  private Vector3 GetMouseWorldPos() {
    Vector3 mousePoint = Input.mousePosition;
    mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
    return Camera.main.ScreenToWorldPoint(mousePoint);
  }

  private void CheckForTowerMerge() {
    List<GameObject> towersToRemove = new List<GameObject>();

    foreach (GameObject otherTower in RfHolder.Ins.map.tower) {
      if (Vector3.Distance(transform.position, otherTower.transform.position) < 0.5f && otherTower != gameObject) {
        GameObject newTower = TryMergeTowers(otherTower);
        if (newTower != null) {
          towersToRemove.Add(gameObject);
          towersToRemove.Add(otherTower);
          break;
        }
      }
    }

    foreach (GameObject towerToRemove in towersToRemove) {
      RfHolder.Ins.map.tower.Remove(towerToRemove);
      Destroy(towerToRemove);
    }
  }

  private GameObject TryMergeTowers(GameObject otherTower) {
    Tower otherTowerComponent = otherTower.GetComponent<Tower>();

    if (tower.towerState == Tower.TowerState.Single && otherTowerComponent.towerState == Tower.TowerState.Single) {
      tower.target = otherTower.transform;

      GameObject newTower = null;

      if (IsMergeConditionMet(tower.towerType, otherTowerComponent.towerType, out newTower)) {
        RfHolder.Ins.map.tower.Add(newTower);
        DisableWallSpawn(tower.target.position);
        return newTower;
      }
    }

    tower.target = null;
    return null;
  }

  private bool IsMergeConditionMet(Tower.TowerType type1, Tower.TowerType type2, out GameObject newTower) {
    newTower = null;

    if ((type1 == Tower.TowerType.Fire && type2 == Tower.TowerType.Water) ||
        (type1 == Tower.TowerType.Water && type2 == Tower.TowerType.Fire)) {
      newTower = Instantiate(tower.Steam, tower.target.position, Quaternion.identity);
      return true;
    }

    if ((type1 == Tower.TowerType.Fire && type2 == Tower.TowerType.Stone) ||
        (type1 == Tower.TowerType.Stone && type2 == Tower.TowerType.Fire)) {
      newTower = Instantiate(tower.Lava, tower.target.position, Quaternion.identity);
      return true;
    }
    
    if ((type1 == Tower.TowerType.Fire && type2 == Tower.TowerType.Flash) ||
        (type1 == Tower.TowerType.Flash && type2 == Tower.TowerType.Fire)) {
      newTower = Instantiate(tower.Electric, tower.target.position, Quaternion.identity);
      return true;
    }

    if ((type1 == Tower.TowerType.Stone && type2 == Tower.TowerType.Water) ||
        (type1 == Tower.TowerType.Water && type2 == Tower.TowerType.Stone)) {
      newTower = Instantiate(tower.Mud, tower.target.position, Quaternion.identity);
      return true;
    }

    if ((type1 == Tower.TowerType.Stone && type2 == Tower.TowerType.Flash) ||
        (type1 == Tower.TowerType.Flash && type2 == Tower.TowerType.Stone)) {
      newTower = Instantiate(tower.Ceramic, tower.target.position, Quaternion.identity);
      return true;
    }

    if ((type1 == Tower.TowerType.Water && type2 == Tower.TowerType.Flash) ||
        (type1 == Tower.TowerType.Flash && type2 == Tower.TowerType.Water)) {
      newTower = Instantiate(tower.Ice, tower.target.position, Quaternion.identity);
      return true;
    }

    return false;
  }

  private void DisableWallSpawn(Vector3 position) {
    foreach (GameObject wallUse in RfHolder.Ins.map.walluse) {
      if (wallUse.transform.position == position) {
        wallUse.GetComponent<WallSpawn>().canUse = false;
        break;
      }
    }
  }
}