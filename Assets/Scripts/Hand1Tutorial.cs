using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hand1Tutorial : MonoBehaviour {
  public void Start() {
    MoveHand();
  }

  public void MoveHand() {
    transform.DOMove(RfTutorial.Ins.tutorial1.endPoint.position, 1f).OnComplete(() => {
      DOVirtual.DelayedCall(0.5f, () => { Destroy(gameObject); });
    });
  }
}