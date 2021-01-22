using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnHome()
    {

    }
}
