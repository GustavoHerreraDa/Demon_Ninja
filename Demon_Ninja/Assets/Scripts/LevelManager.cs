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
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        if(gameManager != null)
        {
            Debug.Log("Start Player");
            gameManager.AddPlayer(startPosition);
        }
    }

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        healthSlider.value = playerController.CalculateHealthForSlider();
    }
}
