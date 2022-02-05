using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public bool playerIsAlive;
    public bool pause;
    [SerializeField] private GameObject tapToStartText;
    [SerializeField] private GameObject restartButton;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerIsAlive)
        {
            //pause = true;
            restartButton.SetActive(true);
        }

        if(playerIsAlive && pause)
        {
            if(Input.GetMouseButton(0))
            {
                TapToStartGame();
            }
        }

        if(pause)
        {
            Time.timeScale = 0;
        }else
        {
            Time.timeScale = 1;
        }
    }

    public void TapToStartGame()
    {
        tapToStartText.SetActive(false);
        pause = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        tapToStartText.SetActive(true);
        restartButton.SetActive(false);

        playerIsAlive = true;
        pause = true;
    }
}
