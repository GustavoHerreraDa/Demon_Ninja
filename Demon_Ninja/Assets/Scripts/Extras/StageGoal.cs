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
                if (menu.levelType == CurrentLevelType.normal)
                    menu.ActivateVictoryCanvas();
                if (menu.levelType == CurrentLevelType.tutorial)
                    menu.ActivateNextLevel();

                player.GetComponent<PlayerInput>().enabled = false;
            }

        }
    }
}
