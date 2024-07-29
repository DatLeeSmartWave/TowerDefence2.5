using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    int musicId;
    // Start is called before the first frame update
    void Start()
    {
        MusicStatus();
    }

    void MusicStatus() {
        musicId = PlayerPrefs.GetInt(Constant.Music,1);
        PlayerPrefs.SetInt(Constant.Music, musicId);
        if (PlayerPrefs.GetInt(Constant.Music) == 0)
            audioSource.volume = 0;
        else
            audioSource.volume = 1;
    }

    public void SwitchMusic() {
        if (PlayerPrefs.GetInt(Constant.Music) == 0) {
            audioSource.volume = 1;
            PlayerPrefs.SetInt(Constant.Music,1);
        } else {
            audioSource.volume = 0;
            PlayerPrefs.SetInt(Constant.Music, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
