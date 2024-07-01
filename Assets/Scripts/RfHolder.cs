using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RfHolder : Singleton<RfHolder> {
  public Map map;
  public GameObject darkPanel;
  public GameObject prefabsWallUse;
  public WallNotUse wallNotUse;
  public ItemSupport itemSupport;
  public Transform spawnPoint;
  public UiManager uiManager;
  public CoinPlayer coinPlayer;
  public MapControllerData mapControllerData;

  public void OnValidate() {
    if (uiManager == null) {
      uiManager = FindObjectOfType<UiManager>();
    }

    if (map == null) {
      map = FindObjectOfType<Map>();
    }

    if (wallNotUse == null) {
      wallNotUse = FindObjectOfType<WallNotUse>();
    }

    if (itemSupport == null) {
      itemSupport = FindObjectOfType<ItemSupport>();
    }
    
    if (coinPlayer == null) {
      coinPlayer = FindObjectOfType<CoinPlayer>();
    }
  }
}