using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IconSpawn : MonoBehaviour {
    public GameObject iconPrefab;
    private bool iconSpawned = false; 

    public void OnMouseUpAsButton() {
        if (FindObjectOfType<UiManager>().informationPanel.activeSelf) {
            if (!iconSpawned) {
                SpawnIcon();
                iconSpawned = true; 
            }
        } else {
            iconSpawned = false;
            SpawnIcon();
        }
    }

    private void SpawnIcon() {
        for (int i = 0; i < RfHolder.Ins.map.walluse.Count; i++) {
            if (RfHolder.Ins.map.walluse[i].GetComponent<WallSpawn>().canUse) {
                GameObject icon = Instantiate(iconPrefab, RfHolder.Ins.map.walluse[i].transform.position, Quaternion.identity);
                RfHolder.Ins.map.tower.Add(icon);
                icon.SetActive(false);
                transform.DOJump(RfHolder.Ins.map.walluse[i].transform.position, 1f, 1, 0.5f);
                transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1);
                transform.DOMove(RfHolder.Ins.map.walluse[i].transform.position, 0.5f).OnComplete(() => {
                    Destroy(gameObject);
                });
                icon.SetActive(true);
                break;
            }
        }
    }
}
