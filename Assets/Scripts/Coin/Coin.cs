using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour {
    public int coin;
    private Transform target;

    // Start is called before the first frame update
    void Start() {
        coin = Random.Range(5, 15);
        target = GameObject.FindGameObjectWithTag("TextCoin").transform;
        StartCoroutine(JumpTwiceAndFlyToTarget());
    }

    private IEnumerator JumpTwiceAndFlyToTarget() {
        transform.DOJump(transform.position + new Vector3(0, 0.2f, 0), 0.2f, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        transform.DOJump(transform.position + new Vector3(0, 0.2f, 0), 0.2f, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FlyToTargetAndDestroy());
    }

    private IEnumerator FlyToTargetAndDestroy() {
        Vector3 targetPosition = target.position;

        transform.DOMove(targetPosition, 1f).SetEase(Ease.InOutQuad);
        transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
        yield return new WaitForSeconds(1f);
        GainCoin();
        gameObject.SetActive(false);
    }

    public void GainCoin() {
        int coinNumber = coin + PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin", coinNumber);
        FindObjectOfType<CoinPlayer>().txtCoin.text = (FindObjectOfType<CoinPlayer>().coinPlayer + coinNumber).ToString();
    }
}
