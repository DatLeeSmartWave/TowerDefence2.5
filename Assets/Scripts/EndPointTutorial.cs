using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointTutorial : MonoBehaviour {
  public Transform pointSelect;

  public void Awake() {
    gameObject.transform.position = pointSelect.transform.position;
  }
}