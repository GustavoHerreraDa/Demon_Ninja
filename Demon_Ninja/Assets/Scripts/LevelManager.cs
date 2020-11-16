using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CurrentLevelType
{
    normal,
    tutorial
}

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
    public GameObject cnNextLevel;

    private bool isPauseActive;

    public CurrentLevelType levelType;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
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

    public void ActivateNextLevel()
    {
        Time.timeScale = 0;
        isPauseActive = true;
        cnNextLevel.gameObject.SetActive(true);
        cnGame.gameObject.SetActive(false);
    }

    public void NextLevelButton()
    {
        var player = FindObjectOfType<PlayerController>();

        if (player.GetType() == typeof(BerserkController))
            StartGameViking();

        if(player.GetType() == typeof(NinjaController))
            StarGameNinja();
    }

    public void StartGameViking()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.playerElegible = PlayerElegible.Berserk;
        gameManager.levelType = LevelType.Normal;
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene(3);
    }

    public void StarGameNinja()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.playerElegible = PlayerElegible.Ninja;
        gameManager.levelType = LevelType.Normal;
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene(3);

    }

}
