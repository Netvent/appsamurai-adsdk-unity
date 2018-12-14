using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSceneScript : MonoBehaviour {

	void Start () {
	}
	
    public void BannerClicked () {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BannerScene");
    }

    public void InterstitialClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InterstitialScene");
    }

    public void RewardedVideoClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("RewardedVideoScene");
    }

}
