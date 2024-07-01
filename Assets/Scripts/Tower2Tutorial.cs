using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower2Tutorial : MonoBehaviour {
  public bool isDragging;
  public Vector3 offset;
  public Vector3 originalPosition;
  public GameObject walltarget;
  // public GameObject fireTower;
  // public GameObject objMerge;
  public void Start() {
    isDragging = false;
  }

  private void OnMouseDown() {
    isDragging = true;
    offset = transform.position - GetMouseWorldPos();
    originalPosition = transform.position;                          
  }
  
  private void OnMouseDrag() {
    if (isDragging) {
      transform.position = GetMouseWorldPos() + offset;
    }
  }
  
  private Vector3 GetMouseWorldPos() {
    Vector3 mousePoint = Input.mousePosition;
    mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
    return Camera.main.ScreenToWorldPoint(mousePoint);
  }

  private void OnMouseUp() {
    isDragging = false;
    if (Vector3.Distance(transform.position, walltarget.transform.position) < 0.5f) {
      transform.position = walltarget.transform.position;
      RfTutorial.Ins.tutorial2.MergeTower();
    }
    else {
      transform.position = originalPosition;
    }
  }
}