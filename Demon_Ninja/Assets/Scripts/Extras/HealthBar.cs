using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider Healtslider;
    public PlayerController player;
    void Start()
    {
        Healtslider = GetComponent<Slider>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Healtslider.value = player.CalculateHealthForSlider();
    }
}
