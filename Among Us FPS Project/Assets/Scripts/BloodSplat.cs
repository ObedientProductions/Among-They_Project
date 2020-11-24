using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    float TimePast = 0;

    // Update is called once per frame
    void Update()
    {
        TimePast = TimePast + Time.deltaTime;
        if (TimePast >= 2f)
        {
            Destroy(gameObject);
        }
    }
}
