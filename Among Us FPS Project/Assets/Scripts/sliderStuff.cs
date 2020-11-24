using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderStuff : MonoBehaviour
{
    public static Slider HealthBar;

    private void Start()
    {
        HealthBar = GetComponent<Slider>();
    }
}
