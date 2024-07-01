using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tutorial1 : MonoBehaviour {
   public GameObject wallUse;
   public GameObject objSpawn;
   public GameObject handTutorial1;
   public Transform startPoint;
   public Transform endPoint;
   private Coroutine createHandCoroutine;

   public void Start() {
      createHandCoroutine = StartCoroutine(CreateHand());
   }

   public IEnumerator CreateHand() {
      while (true) {
         yield return new WaitForSeconds(5f);
         GameObject objHand = Instantiate(handTutorial1, startPoint.transform.position, Quaternion.identity);
         objHand.transform.SetParent(startPoint);
      }
   }

   public void StopCreateHand() {
      if (createHandCoroutine != null) {
         StopCoroutine(createHandCoroutine);
         createHandCoroutine = null;
      }
   }
}