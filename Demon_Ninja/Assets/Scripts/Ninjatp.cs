using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjatp : MonoBehaviour
{
    public Transform Destination;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = Destination.transform.position;
        }
    }
}
