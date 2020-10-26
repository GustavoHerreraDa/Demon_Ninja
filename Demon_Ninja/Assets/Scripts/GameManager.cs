using System.Collections;
using System.Collections.Generic;
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
                Instantiate(Berserk, startPosition);

            if (playerElegible == PlayerElegible.Ninja)
                Instantiate(Ninja, startPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
