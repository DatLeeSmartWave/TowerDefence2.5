using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Tutorial2 : MonoBehaviour {
  public Transform startPoint;
  public Transform endPoint;
  public GameObject handTutorial2;
  private Coroutine createHandCoroutine;
  public GameObject waterTower;
  public GameObject fireTower;
  public GameObject objMerge;
  public GameObject winPanel;
  public void Start() {
    createHandCoroutine = StartCoroutine(CreateHand());
  }
  
  public IEnumerator CreateHand() {
    while (true) {
      yield return new WaitForSeconds(5f);
      GameObject objHand = Instantiate(handTutorial2, startPoint.transform.position, Quaternion.identity);
      objHand.transform.SetParent(startPoint);
    }
  }

  public void StopCreateHand() {
    if (createHandCoroutine != null) {
      StopCoroutine(createHandCoroutine);
      createHandCoroutine = null;
      DOVirtual.DelayedCall(1f, () => {
        winPanel.SetActive(true);
        RfTutorial.Ins.tutorialManager.tutorialData.firstTimePlaying = false;
        SceneManager.LoadScene("MainScene");
      });
    }
  }

  public void MergeTower() {
    fireTower.SetActive(false);
    waterTower.SetActive(false);
    GameObject obj = Instantiate(objMerge, fireTower.transform.position, Quaternion.identity);
    obj.gameObject.transform.SetParent(gameObject.transform);
    StopCreateHand();
  }
}