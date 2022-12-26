using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas controlMenuCanvas;
    public Canvas creditsMenuCanvas;
    public Canvas playMenuCanvas;
    public int menuState = 1;
    void Start()
    {
        /* mainMenuCanvas = GameObject.Find("MainMenu").GetComponent<Canvas>();
         controlMenuCanvas = GameObject.Find("ControlsMenu").GetComponent<Canvas>();
         creditsMenuCanvas = GameObject.Find("CreditsMenu").GetComponent<Canvas>();
         playMenuCanvas = GameObject.Find("LevelSelectMenu").GetComponent<Canvas>();*/
        menuState = 1;
    }

    void Update()
    {
        CheckMenuState();

    }
    public void CheckMenuState()
    {

        switch (menuState)
        {
            case 1:
                Debug.Log(menuState + " " + mainMenuCanvas.name);
                mainMenuCanvas.enabled = true;
                controlMenuCanvas.enabled = false;
                creditsMenuCanvas.enabled = false;
                playMenuCanvas.enabled = false;
                break;
            case 2:
                Debug.Log(menuState + " " + playMenuCanvas.name);
                mainMenuCanvas.enabled = false;
                controlMenuCanvas.enabled = false;
                creditsMenuCanvas.enabled = false;
                playMenuCanvas.enabled = true;
                break;
            case 3:
                Debug.Log(menuState + " " + controlMenuCanvas.name);
                mainMenuCanvas.enabled = false;
                controlMenuCanvas.enabled = true;
                creditsMenuCanvas.enabled = false;
                playMenuCanvas.enabled = false;
                break;
            case 4:
                Debug.Log(menuState + " " + creditsMenuCanvas.name);
                mainMenuCanvas.enabled = false;
                controlMenuCanvas.enabled = false;
                creditsMenuCanvas.enabled = true;
                playMenuCanvas.enabled = false;
                break;
        }
    }

    public void OnClick(int state)
    {
        menuState = state;
    }
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void DoExitGame()
    {
        Application.Quit();
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

    public void StarGameTutorialViking()
    {
        var gameManager = FindObjectOfType<GameManager>();
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene(1);
    }

    public void StarGameTutorialNinja()
    {
        var gameManager = FindObjectOfType<GameManager>();
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene(2);
    }

    public void StarGameInvoker()
    {

    }

}