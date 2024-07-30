using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject countDownPanel;
    public GameObject informationPanel;
    public TextMeshProUGUI countDownText;
    public Button btnWin;
    public Button btnLose;
    public Button nextButton;
    public Button previousButton;
    public GameObject[] levelTexts;
    public GameObject[] stars;
    public GameObject[] wizardsProfiles;
    public GameObject[] onIcons;
    public GameObject[] offIcons;
    [SerializeField] GameObject levelNoticePanel;
    [SerializeField] GameObject heartNoticePanel;
    int myMoney;
    int myHeart;
    int slot;
    int iceNumber;
    [SerializeField] TextMeshProUGUI myHeartText;
    [SerializeField] TextMeshProUGUI slotText;
    [SerializeField] TextMeshProUGUI iceNumberText;
    public TextMeshProUGUI myMoneyText;
    public PlayerData playerData;

    private Dictionary<string, string> tagToPlayerPref = new Dictionary<string, string>() {
        { "Fire", "Fire" },
        { "Flash", "Flash" },
        { "Stone", "Stone" },
        { "Water", "Water" }
    };

    private int currentWizardIndex = 0; // Chỉ số wizard hiện tại

    public void Start() {
        if (SceneManager.GetActiveScene().name == "SelectLevel") {
            UpdateLevelUI();
        }
        if (SceneManager.GetActiveScene().name == "SampleScene") {
            btnLose.onClick.AddListener(() => LoadScene("SampleScene"));
            btnWin.onClick.AddListener(() => NextLevel());
            StartCoroutine(StartCountdown());
        }
        if (SceneManager.GetActiveScene().name == "MainScene") {
            nextButton.onClick.AddListener(NextWizard);
            previousButton.onClick.AddListener(PreviousWizard);
            myMoney = playerData.coin + PlayerPrefs.GetInt("Coin");
            myMoneyText.text = myMoney.ToString();
            myHeart = PlayerPrefs.GetInt(Constant.MyHeart, 2);
            PlayerPrefs.SetInt(Constant.MyHeart, myHeart);
            myHeartText.text = myHeart.ToString();
            slot = PlayerPrefs.GetInt(Constant.Slot);
            slotText.text = slot.ToString();
            iceNumber = PlayerPrefs.GetInt(Constant.IceNumber);
            iceNumberText.text = iceNumber.ToString();
            UpdateWizardProfiles();
            LoadButtonStates();
        }

    }

    private void UpdateLevelUI() {
        int passedLevel = PlayerPrefs.GetInt(Constants.PassedLevel);
        for (int i = 0; i < levelTexts.Length; i++) {
            if (i < passedLevel) {
                levelTexts[i].SetActive(false);
                stars[i].SetActive(true);
            } else {
                levelTexts[i].SetActive(true);
                stars[i].SetActive(false);
            }
        }
    }

    private IEnumerator StartCountdown() {
        Time.timeScale = 1.0f;
        countDownPanel.SetActive(true);
        int countdownValue = 3;
        while (countdownValue >= 0) {
            countDownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(1);
            countdownValue--;
        }
        countDownPanel.SetActive(false);
        FindObjectOfType<Map>().StartCoroutine(FindObjectOfType<Map>().SpawnEnemy());
    }

    public void OnPanel(GameObject panel) {
        panel.SetActive(true);
    }

    public void OffPanel(GameObject panel) {
        panel.SetActive(false);
        if (informationPanel.activeSelf) {
            panel.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName) {
        if (PlayerPrefs.GetInt(Constant.MyHeart) > 0)
            SceneManager.LoadScene(sceneName);
        else
            SceneManager.LoadScene("MainScene");
    }

    public void NextLevel() {
        RfHolder.Ins.mapControllerData.currentLevel++;
        LoadScene("SampleScene");
    }

    public void LoadLevel(int idx) {
        if (PlayerPrefs.GetInt(Constants.PassedLevel) >= idx &&
            PlayerPrefs.GetInt(Constant.MyHeart) > 0) {
            RfHolder.Ins.mapControllerData.currentLevel = idx;
            LoadScene("SampleScene");
        } else if (PlayerPrefs.GetInt(Constant.MyHeart) <= 0) {
            heartNoticePanel.SetActive(true);
            StartCoroutine(HideObject(heartNoticePanel));
            StartCoroutine(HideObject(levelNoticePanel));
        } else if (PlayerPrefs.GetInt(Constants.PassedLevel) < idx) {
            levelNoticePanel.SetActive(true);
            StartCoroutine(HideObject(levelNoticePanel));
            StartCoroutine(HideObject(heartNoticePanel));
        }
    }

    IEnumerator HideObject(GameObject obj) {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }

    public void NextWizard() {
        currentWizardIndex = (currentWizardIndex + 1) % wizardsProfiles.Length;
        UpdateWizardProfiles();
    }

    public void PreviousWizard() {
        currentWizardIndex = (currentWizardIndex - 1 + wizardsProfiles.Length) % wizardsProfiles.Length;
        UpdateWizardProfiles();
    }

    public void SwitchButton(string buttonName) {
        bool isOn = PlayerPrefs.GetInt(buttonName + "State", 1) == 1; // Mặc định là bật (1)

        if (buttonName == "Music") {
            onIcons[0].SetActive(!isOn);
            offIcons[0].SetActive(isOn);
            FindObjectOfType<MusicManager>().SwitchMusic();
        } else if (buttonName == "Sound") {
            onIcons[1].SetActive(!isOn);
            offIcons[1].SetActive(isOn);
            FindObjectOfType<SoundManager>().SwitchSound();
        } else if (buttonName == "Vibrate") {
            onIcons[2].SetActive(!isOn);
            offIcons[2].SetActive(isOn);
        }
        PlayerPrefs.SetInt(buttonName + "State", isOn ? 0 : 1); // Lưu trạng thái mới
        PlayerPrefs.Save();
    }

    private void LoadButtonStates() {
        UpdateButtonState("Music", onIcons[0], offIcons[0]);
        UpdateButtonState("Sound", onIcons[1], offIcons[1]);
        UpdateButtonState("Vibrate", onIcons[2], offIcons[2]);
    }

    private void UpdateButtonState(string buttonName, GameObject onIcon, GameObject offIcon) {
        bool isOn = PlayerPrefs.GetInt(buttonName + "State", 1) == 1; // Mặc định là bật (1)
        onIcon.SetActive(isOn);
        offIcon.SetActive(!isOn);
    }

    public void BuyCoinBtn(int number) {
        int newMoney = myMoney + number;
        myMoney = newMoney;
        PlayerPrefs.SetInt("Coin", newMoney);
        myMoneyText.text = myMoney.ToString();
    }

    public void BuySlotBtn(int price) {
        if (price <= myMoney) {
            slot++;
            slotText.text = slot.ToString();
            PlayerPrefs.SetInt(Constant.Slot, slot);
            int newNumber = myMoney - price;
            myMoney = newNumber;
            PlayerPrefs.SetInt("Coin", newNumber);
            myMoneyText.text = myMoney.ToString();
        }
    }

    public void BuyHeartBtn(int price) {
        if (price <= myMoney) {
            myHeart++;
            myHeartText.text = myHeart.ToString();
            PlayerPrefs.SetInt(Constant.MyHeart, myHeart);
            int newNumber = myMoney - price;
            myMoney = newNumber;
            PlayerPrefs.SetInt("Coin", newNumber);
            myMoneyText.text = myMoney.ToString();
        }
    }

    public void BuyIceBtn(int price) {
        if (price <= myMoney) {
            iceNumber++;
            iceNumberText.text = iceNumber.ToString();
            PlayerPrefs.SetInt(Constant.IceNumber, iceNumber);
            int newNumber = myMoney - price;
            myMoney = newNumber;
            PlayerPrefs.SetInt("Coin", newNumber);
            myMoneyText.text = myMoney.ToString();
        }
    }

    public void LoadSceneBtn(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGamne() {
        //Time.timeScale = 0;
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

    //public void ResumeGame() {
    //    Time.timeScale = 1;
    //}

    private void UpdateWizardProfiles() {
        for (int i = 0; i < wizardsProfiles.Length; i++) {
            wizardsProfiles[i].SetActive(i == currentWizardIndex);
        }
    }

    //void Update() {
    //    if (Input.touchCount > 0) {
    //        foreach (Touch touch in Input.touches) {
    //            if (touch.phase == TouchPhase.Began) {
    //                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //                Collider2D[] colliders = Physics2D.OverlapPointAll(touchPosition);
    //                foreach (Collider2D collider in colliders) {
    //                    string tag = collider.tag;
    //                    if (tagToPlayerPref.ContainsKey(tag) && PlayerPrefs.GetInt(tagToPlayerPref[tag]) == 0) {
    //                        OnPanel(informationPanel);
    //                        Time.timeScale = 0;
    //                        PlayerPrefs.SetInt(tagToPlayerPref[tag], 1);
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
