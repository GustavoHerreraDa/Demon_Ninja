using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public Transform startPosition;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        if(gameManager != null)
        {
            gameManager.AddPlayer(startPosition);
        }
    }
}
