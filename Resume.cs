using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject pauseMenuUI; // ポーズメニューのUIオブジェクト

    public void ResumeButtonClicked()
    {
        pauseMenuUI.SetActive(false);

        // ゲームのポーズを解除
        Time.timeScale = 1f;
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
