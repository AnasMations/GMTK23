using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepMeter : MonoBehaviour
{
    public Slider slider;
    public static float SleepoMeter=100;
    public float RechargeFactor;
    private float MaxSleepoMeter;


    // Start is called before the first frame update
    void Start()
    {
        MaxSleepoMeter = SleepoMeter;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SleepoMeter>MaxSleepoMeter) SleepoMeter = MaxSleepoMeter;
        slider.value = SleepoMeter / MaxSleepoMeter;
        SleepoMeter -= RechargeFactor;
    }
}
