using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneSelect(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ActiveTrue(GameObject obj) {
        obj.gameObject.SetActive(true);
    }
    
    public void ActiveFalse(GameObject obj) {
        obj.gameObject.SetActive(false);
    }
}
