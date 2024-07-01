using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPlayer : MonoBehaviour {
  public PlayerData playerData;
  public int coinPlayer;
  public TMP_Text txtCoin;

  private void Start() {
    coinPlayer = playerData.coin + PlayerPrefs.GetInt("Coin")   ;
    UpdateTextCoin();
  }

  public void UpdateTextCoin() {
    txtCoin.text = coinPlayer.ToString();
  }
}