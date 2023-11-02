using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;// 一時停止画面のパネル

    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused; 
        PausePanel.SetActive(isPaused); 
        Time.timeScale = isPaused ? 0 : 1; // ゲームの時間を停止または再開する
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
