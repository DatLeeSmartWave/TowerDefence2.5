using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnIcon : MonoBehaviour {
  public IconTowerData[] iconTowerData;
  public Button[] btnIcon;
  private int priceSpawn = 100;
  private void Start() {
    LoadIconTower();
  }

  public void CreateIcon(GameObject iconSpawn) {
    if (BuyIcon()) {
      Vector3 pos = new Vector3(0, 0, 0);
      GameObject icon = Instantiate(iconSpawn, pos, Quaternion.identity);
      icon.SetActive(false);
      icon.SetActive(true);
    }
  }

  public void LoadIconTower() {
    for (int i = 0; i < iconTowerData.Length; i++) {
      int index = i;
      btnIcon[i].onClick.AddListener(() => CreateIcon(iconTowerData[index].prefabTower));
      btnIcon[i].image.sprite = iconTowerData[i].imgIcon;
    }
  }

  public bool BuyIcon() {
    if (RfHolder.Ins.coinPlayer.coinPlayer >= priceSpawn) {
      RfHolder.Ins.coinPlayer.coinPlayer -= priceSpawn;
      RfHolder.Ins.coinPlayer.UpdateTextCoin();
      return true;
    }
    else {
      Debug.Log("Not enough coin");
      return false;
    }
  }
}