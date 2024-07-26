using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialData", menuName = "Data/TutorialData")]
public class TutorialData : ScriptableObject {
  public bool firstTimePlaying = true;
  public int tutorialStep = 0;
}