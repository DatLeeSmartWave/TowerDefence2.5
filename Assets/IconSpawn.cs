using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpawn : MonoBehaviour
{
  public GameObject iconPrefab;

  public void OnMouseUpAsButton() {
    for (int i = 0; i < RfHolder.Ins.map.walluse.Count; i++) {
      if (RfHolder.Ins.map.walluse[i].GetComponent<WallSpawn>().canUse) {
        GameObject icon = Instantiate(iconPrefab, RfHolder.Ins.map.walluse[i].transform.position, Quaternion.identity);
        icon.transform.SetParent(RfHolder.Ins.map.walluse[i].transform);
        RfHolder.Ins.map.walluse[i].GetComponent<WallSpawn>().canUse = false;
        break;
      }
    }
    
    Destroy(gameObject);
  }
}
