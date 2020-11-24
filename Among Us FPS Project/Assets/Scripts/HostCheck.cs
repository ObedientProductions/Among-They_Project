using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HostCheck : MonoBehaviourPunCallbacks
{
    //float TimePast = 10;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //HostView = photonView;
        }
    }
    private void Update()
    {
        
    }
    void SetTimer()
    {

    }

    [PunRPC]
    void DisconnectPlayer() 
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
