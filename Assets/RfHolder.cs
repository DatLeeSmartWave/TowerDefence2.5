using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RfHolder : Singleton<RfHolder> {
  public Map map;

  public void OnValidate() {
    if (map == null) {
      map = FindObjectOfType<Map>();
    }
  }
}