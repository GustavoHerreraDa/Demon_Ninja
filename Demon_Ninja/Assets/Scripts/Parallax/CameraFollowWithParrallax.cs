using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithParrallax : MonoBehaviour
{
 //   public Transform bg0;
 //   public float factor0 = 1f;

  //  public Transform bg1;
  //  public float factor1 = 1 / 2f;

   // public Transform bg2;
  //  public float factor2 = 1 / 4f;

    private float displacement;
  //  private float iniCamPosFrame;
  //  private float nextCamPosFrame;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
     //   iniCamPosFrame = transform.position.x;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
     //   nextCamPosFrame = transform.position.x;

       // bg0.position = new Vector3(bg0.position.x + (nextCamPosFrame - iniCamPosFrame) * factor0, bg0.position.y, bg0.position.z);
       // bg1.position = new Vector3(bg1.position.x + (nextCamPosFrame - iniCamPosFrame) * factor1, bg1.position.y, bg1.position.z);
       // bg2.position = new Vector3(bg2.position.x + (nextCamPosFrame - iniCamPosFrame) * factor2, bg2.position.y, bg2.position.z);
    }
}
