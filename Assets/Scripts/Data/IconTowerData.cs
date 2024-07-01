using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ CreateAssetMenu(fileName = "IconTowerData", menuName = "Data/IconTowerData", order = 1) ]
public class IconTowerData : ScriptableObject {
   public Sprite imgIcon;
   public GameObject prefabTower;
   public int price;
}
