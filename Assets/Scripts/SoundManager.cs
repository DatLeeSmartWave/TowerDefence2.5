using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip loseSound;
    int soundId;
    // Start is called before the first frame update
    void Start() {
        SoundStatus();
    }

    void SoundStatus() {
        soundId = PlayerPrefs.GetInt(Constant.Sound, 1);
        PlayerPrefs.SetInt(Constant.Sound, soundId);
        if (PlayerPrefs.GetInt(Constant.Sound) == 0)
            audioSource.volume = 0;
        else
            audioSource.volume = 1;
    }

    public void SwitchSound() {
        if (PlayerPrefs.GetInt(Constant.Sound) == 0) {
            audioSource.volume = 1;
            PlayerPrefs.SetInt(Constant.Sound, 1);
        } else {
            audioSource.volume = 0;
            PlayerPrefs.SetInt(Constant.Sound, 0);
        }
    }

    public void PlaySound(string soundName) {
        if(soundName == "winSound")
            audioSource.PlayOneShot(winSound);
        else if(soundName == "loseSound")
            audioSource.PlayOneShot(loseSound);
    }

    // Update is called once per frame
    void Update() {

    }
}
