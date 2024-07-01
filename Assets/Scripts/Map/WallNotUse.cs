using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallNotUse : MonoBehaviour {
  public SpriteRenderer spriteRenderer;
  public bool isChecked;

  public void Awake() {
    RfHolder.Ins.wallNotUse = this;
  }

  private void OnValidate() {
    if (spriteRenderer == null) {
      spriteRenderer = GetComponent<SpriteRenderer>();
    }
  }

  public void CheckDarkPanel() {
    isChecked = RfHolder.Ins.darkPanel.gameObject.activeSelf;
  }

  public void OnMouseEnter() {
    CheckDarkPanel();
    if (isChecked) {
      spriteRenderer.color = Color.black;
    }
  }

  public void OnMouseExit() {
    CheckDarkPanel();
    if (isChecked) {
      spriteRenderer.color = new Color(192f / 255f, 221f / 255f, 130f / 255f);
    }
  }

  public void OnMouseDown() {
    CheckDarkPanel();
    if (isChecked) {
      RfHolder.Ins.map.wallnotuse.Remove(this.gameObject);
      Destroy(this.gameObject);
      GameObject wallUse = Instantiate(RfHolder.Ins.prefabsWallUse, transform.position, Quaternion.identity);
      RfHolder.Ins.map.walluse.Add(wallUse);
      RfHolder.Ins.darkPanel.SetActive(false);
      RfHolder.Ins.itemSupport.AnimButtonWallNotUse();
      isChecked = false;
    }
  }
}