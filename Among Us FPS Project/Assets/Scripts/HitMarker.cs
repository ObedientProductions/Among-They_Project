using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    public static bool HitTarget = false;
    public static Animator HitMarkerAnimator;

    public GameObject Marker;

    void Update()
    {
        
    }

    private void Start()
    {
        HitMarkerAnimator = GetComponent<Animator>();
    }
}
