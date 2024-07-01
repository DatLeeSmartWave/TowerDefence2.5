using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ItemSupport : MonoBehaviour {
  public Button btnHammer;
  private int priceHammer = 500;
  public void Awake() {
    btnHammer.onClick.AddListener(() => { ClickHammer(); });
  }

  public void ClickHammer() {
    if (BuyHammer()) {
      CheckListWallNotUse();
      RfHolder.Ins.wallNotUse.CheckDarkPanel();
      AnimButtonWallNotUse();
    }
  }

  public void AnimButtonWallNotUse() {
    if (RfHolder.Ins.darkPanel.gameObject.activeSelf) {
      for (int i = 0; i < RfHolder.Ins.map.wallnotuse.Count; i++) {
        RfHolder.Ins.map.wallnotuse[i].transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f).SetLoops(-1, LoopType.Yoyo);
      }
    }
    else {
      for (int i = 0; i < RfHolder.Ins.map.wallnotuse.Count; i++) {
        RfHolder.Ins.map.wallnotuse[i].transform.DOKill();
        RfHolder.Ins.map.wallnotuse[i].transform.localScale = new Vector3(1f, 1f, 1f);
      }
    }
  }

  public void CheckListWallNotUse() {
    if (RfHolder.Ins.map.wallnotuse.Count == 0) {
      RfHolder.Ins.darkPanel.SetActive(false);
    }
    else {
      RfHolder.Ins.darkPanel.SetActive(true);
    }
  }

  public bool BuyHammer() {
    if (RfHolder.Ins.coinPlayer.coinPlayer >= priceHammer) {
      RfHolder.Ins.coinPlayer.coinPlayer -= priceHammer;
      RfHolder.Ins.coinPlayer.UpdateTextCoin();
      return true;
    }
    else {
      Debug.Log("Not enough coin");
      return false;
    }
  }
}