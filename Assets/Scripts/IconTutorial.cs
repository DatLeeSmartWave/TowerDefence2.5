using UnityEngine;
using DG.Tweening;

public class IconTutorial : MonoBehaviour {
  public void OnMouseUp() {
    RfTutorial.Ins.tutorial1.StopCreateHand();
    transform.DORotate(new Vector3(0, 90, 0), 0.5f).SetLoops(-1);
    transform.DOMove(RfTutorial.Ins.tutorial1.wallUse.transform.position, 1f).OnComplete( () => {
      Destroy(gameObject);
      GameObject obj = Instantiate(RfTutorial.Ins.tutorial1.objSpawn, RfTutorial.Ins.tutorial1.wallUse.transform.position, Quaternion.identity);
      obj.transform.SetParent(RfTutorial.Ins.tutorial1.wallUse.transform);
      DOVirtual.DelayedCall(0.5f, () => {
        RfTutorial.Ins.tutorialManager.tutorialData.tutorialStep++;
        RfTutorial.Ins.tutorialManager.tutorialStep = RfTutorial.Ins.tutorialManager.tutorialData.tutorialStep;
        RfTutorial.Ins.tutorialManager.LoadTutorialObjects();
      });
    });
  }
}