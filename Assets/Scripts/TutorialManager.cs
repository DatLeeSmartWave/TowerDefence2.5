using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TutorialData tutorialData;

    public bool firstTimePlaying;
    public int tutorialStep;
    public List<GameObject> tutorialObjects;
    
    public void Awake() {
        firstTimePlaying = tutorialData.firstTimePlaying;
        tutorialStep = tutorialData.tutorialStep;
    }
    
    public void Start() {
      LoadTutorialObjects();
    }
    
    public void LoadTutorialObjects() {
      foreach(GameObject tutorialObject in tutorialObjects) {
        tutorialObject.SetActive(false);
      }
      
      tutorialObjects[tutorialStep].SetActive(true);
    }
}
