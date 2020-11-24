using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SetName : MonoBehaviour
{
    public TextMesh DisplayName;
    public PhotonView PV;

    public Transform PlayerCam;

    void Start()
    {
        if (PV.IsMine)
        {
            DisplayName.text = MenuManager.Name;
            PlayerCam.tag = "MainCamera";

            if (DisplayName.text.Length > 20)
            {
                DisplayName.text = DisplayName.text.Remove(20);
            }
        }

        else
        {
            DisplayName.text = PV.Owner.NickName;

            if(DisplayName.text.Length > 20) 
            {
                DisplayName.text = DisplayName.text.Remove(20);
            }
        }
    }

    float TimePast = 0;
    private void Update()
    {
        TimePast = TimePast + Time.deltaTime;

        if (TimePast >= 0.2f)
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
