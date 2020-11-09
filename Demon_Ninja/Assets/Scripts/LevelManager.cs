using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public Transform startPosition;
    public Slider healthSlider;

    public PlayerController playerController;
    // Start is called before the first frame update

    public GameObject cnVictory;
    public GameObject cnDefeat;
    public GameObject cnGame;
    public GameObject cnPause;

    private bool isPauseActive;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        if(gameManager != null)
        {
            Debug.Log("Start Player " + this.name);

            gameManager.AddPlayer(startPosition);
        }
    }

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        
    }

    void Update()
    {
        //  healthSlider.value = playerController.CalculateHealthForSlider();
        if (playerController.CurrentHealth <= 0)
        {
            ActivateDefeatCanvas();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseActive)
                ActivatePause();
            else
                ActivateContinue();
        }
    }

    public void ActivateVictoryCanvas()
    {
        Debug.Log("ActivateVictoryCanvas");
        Debug.Log(cnVictory.gameObject.name);
        cnVictory.gameObject.SetActive(true);
        cnGame.gameObject.SetActive(false);
    }

    public void ActivateDefeatCanvas()
    {
        playerController.GetComponent<PlayerInput>().enabled = false;
        cnDefeat.SetActive(true);
        cnGame.SetActive(false);
    }

    public void ActivatePause()
    {
        Time.timeScale = 0;
        isPauseActive = true;
        cnPause.gameObject.SetActive(true);
        cnGame.gameObject.SetActive(false);
    }

    public void ActivateContinue()
    {
        Debug.Log("Active Continue");
        Time.timeScale = 1;
        isPauseActive = false;
        cnPause.gameObject.SetActive(false);
        cnGame.gameObject.SetActive(true);
    }
}
