using UnityEngine;

public enum PlayerElegible
{
    Berserk,
    Ninja,
    Invoker
}

public enum LevelType
{
    Menu,
    Normal
}

public class GameManager : MonoBehaviour
{
    public PlayerElegible playerElegible;
    public LevelType levelType;

    public GameObject Ninja;
    public GameObject Invoker;
    public GameObject Berserk;


    // Start is called before the first frame update
    void Awake()
    {


    }

    public void AddPlayer(Transform startPosition)
    {
        if (levelType == LevelType.Normal)
        {
            if (playerElegible == PlayerElegible.Berserk)
            {
                var berserk = Instantiate(Berserk);
                berserk.transform.position = startPosition.position;
            }
            if (playerElegible == PlayerElegible.Ninja)
            {
                var ninja = Instantiate(Ninja);
                ninja.transform.position = startPosition.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
