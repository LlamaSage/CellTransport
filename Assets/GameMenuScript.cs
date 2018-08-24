using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour {

    public AudioSource[] gameMusic;
    private int currentAudioSource = 0;
    public Canvas mainMenuCanvas;
    public Slider volumeSlider;



	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenuCanvas.gameObject.SetActive(!mainMenuCanvas.gameObject.activeInHierarchy);
        }
	}


    public void reloadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void quitGame()
    {
        if(Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }

    public void changeMusicTrack(int newTrack)
    {
        gameMusic[currentAudioSource].Stop();
        gameMusic[newTrack].Play();
        currentAudioSource = newTrack;
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
