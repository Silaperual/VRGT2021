using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public bool isPaused=true;

    private GameObject tileManager;
    private GameObject gameController;
    private GameObject uiSettings;
    private GameObject scoreCanvas;

    // Start is called before the first frame update
    void Start()
    {
        tileManager = GameObject.Find("TilesManager").gameObject;
        gameController = GameObject.Find("GameController").gameObject;
        uiSettings = GameObject.Find("settingUI").gameObject;
        scoreCanvas = GameObject.Find("ScoreCanvas").gameObject;

        tileManager.SetActive(false);
        scoreCanvas.SetActive(false);
        gameController.GetComponent<GameController>().enabled = false;
        //gameController.SetActive(false);
        //PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        isPaused = false;
        tileManager.SetActive(true);
        scoreCanvas.SetActive(true);
        gameController.GetComponent<GameController>().enabled = true;
        uiSettings.SetActive(false);
        //Time.timeScale = 1f;
    }
}
