using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                LevelManager menu = FindObjectOfType<LevelManager>();
                menu.ActivateVictoryCanvas();
                player.GetComponent<PlayerInput>().enabled = false;
            }

        }
    }
}
