using UnityEngine;
using UnityEngine.SceneManagement;


public enum SceneNumber
{
    mainMenu,
    tutorialBerserk,
    tutorialNinja,
    levelOne
}

public class Scene_Manager : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene((int)SceneNumber.mainMenu);
    }

    public void Play()
    {
        SceneManager.LoadScene((int)SceneNumber.levelOne);
    }

    public void PlayCurrentLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber + 1);
    }

    public void PlayCurrentLevel(SceneNumber sceneNumber)
    {
        SceneManager.LoadScene((int)sceneNumber);
    }

    public void RetryLevel(SceneNumber sceneNumber)
    {
        SceneManager.LoadScene((int)sceneNumber);
    }

    public void RetryLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void PlayNextLevel(SceneNumber sceneNumber)
    {
        SceneManager.LoadScene((int)sceneNumber);
    }
    public void Instructions()
    {
        //SceneManager.LoadScene((int)SceneNumber.tutorial);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
