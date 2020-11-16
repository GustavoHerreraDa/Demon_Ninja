using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontFlip : MonoBehaviour
{
    public GameObject viking;

    public SpriteRenderer thisRender;
    // Start is called before the first frame update
    void Start()
    {
        viking = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (viking.transform.localScale.x < 0)
        {
            thisRender.flipX = true;
        }
        if (viking.transform.localScale.x > 0)
        {
            thisRender.flipX = false;
        }
    }
}
