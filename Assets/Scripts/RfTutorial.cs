using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RfTutorial : Singleton<RfTutorial> {
    public TutorialManager tutorialManager;
    public Tutorial1 tutorial1;
    public Tutorial2 tutorial2;
    private void OnValidate() {
        tutorialManager = tutorialManager ?? FindObjectOfType<TutorialManager>();
        tutorial1 = tutorial1 ?? FindObjectOfType<Tutorial1>();
        tutorial2 = tutorial2 ?? FindObjectOfType<Tutorial2>();
    }
}
