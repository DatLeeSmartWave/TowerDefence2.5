using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemSupport : MonoBehaviour {
    public Button btnHammer;
    private int priceHammer = 500;
    int slot;
    int iceNumber;
    [SerializeField] GameObject icePrefab;
    [SerializeField] TextMeshProUGUI slotText;
    [SerializeField] TextMeshProUGUI iceNumberText;
    [SerializeField] GameObject blackPanel;
    bool hasSpawn;

    public void Awake() {
        btnHammer.onClick.AddListener(() => { ClickHammer(); });
    }

    private void Start() {
        slot = PlayerPrefs.GetInt(Constant.Slot);
        slotText.text = slot.ToString();
        iceNumber = PlayerPrefs.GetInt(Constant.IceNumber);
        iceNumberText.text = iceNumber.ToString();
    }

    public void ClickHammer() {
        if (slot > 0) {
            slot--;
            PlayerPrefs.SetInt(Constant.Slot, slot);
            slotText.text = slot.ToString();
            CheckListWallNotUse();
            RfHolder.Ins.wallNotUse.CheckDarkPanel();
            AnimButtonWallNotUse();
        }
    }

    public void AnimButtonWallNotUse() {
        if (RfHolder.Ins.darkPanel.gameObject.activeSelf) {
            for (int i = 0; i < RfHolder.Ins.map.wallnotuse.Count; i++) {
                RfHolder.Ins.map.wallnotuse[i].transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f).SetLoops(-1, LoopType.Yoyo);
            }
        } else {
            for (int i = 0; i < RfHolder.Ins.map.wallnotuse.Count; i++) {
                RfHolder.Ins.map.wallnotuse[i].transform.DOKill();
                RfHolder.Ins.map.wallnotuse[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    public void CheckListWallNotUse() {
        if (RfHolder.Ins.map.wallnotuse.Count == 0) {
            RfHolder.Ins.darkPanel.SetActive(false);
        } else {
            RfHolder.Ins.darkPanel.SetActive(true);
        }
    }

    public void EnableSpawnICe() {
        if(iceNumber > 0) {
            blackPanel.SetActive(true);
            hasSpawn = true;
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && hasSpawn == true && iceNumber>0) {
            if (Input.touchCount > 0) {
                foreach (Touch touch in Input.touches) {
                    if (touch.phase == TouchPhase.Began) {
                        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
                        foreach (Collider2D collider in colliders) {
                            if (collider.CompareTag("WallMove")) {
                                Instantiate(icePrefab, collider.transform.position, collider.transform.rotation);
                                iceNumber--;
                                iceNumberText.text = iceNumber.ToString();
                                PlayerPrefs.SetInt(Constant.IceNumber, iceNumber);
                                hasSpawn = false;
                                blackPanel.SetActive(false);
                            }
                        }
                    }
                }
            }
        }
    }
}

