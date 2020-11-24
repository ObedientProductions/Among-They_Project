using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MatchManager : MonoBehaviourPunCallbacks
{
    public static int PlayerCount;

    public Text JoinedText;

    public GameObject AreYouSureScreen;
    public GameObject YOUWON;
    public Text Kills;
    public static int Eliminations = 0;
    float Percentage;

    float MaxKills = 50;
    bool UWin = false;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient) 
        {
            PhotonNetwork.CurrentRoom.MaxPlayers = 8;
        }
    }

    void Update()
    {
        Percentage = (float)Eliminations / MaxKills * 100;
        Kills.text = "Eliminations: " + Eliminations + " [" + Percentage + "%" + " Complete]";

        if(Eliminations >= MaxKills) 
        {
            if (UWin == false)
            {
                YOUWON.SetActive(true);
                AreYouSureScreen.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

                UWin = true;
            }
        }

        PlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        JoinedText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers + "Players Joined" + "\n" + "Players In Lobby:";

        if (PhotonNetwork.PlayerList.Length == 1)
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;

            if(PhotonNetwork.PlayerList[0].NickName.Length > 20) 
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }
        }

        if (PhotonNetwork.PlayerList.Length == 2) 
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }
        }

        if (PhotonNetwork.PlayerList.Length == 3) 
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[2].NickName;
            if (PhotonNetwork.PlayerList[2].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[2].NickName = PhotonNetwork.PlayerList[2].NickName.Remove(20);
            }
        }

        if(PhotonNetwork.PlayerList.Length == 4) 
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[2].NickName;
            if (PhotonNetwork.PlayerList[2].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[2].NickName = PhotonNetwork.PlayerList[2].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[3].NickName;
            if (PhotonNetwork.PlayerList[3].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[3].NickName = PhotonNetwork.PlayerList[3].NickName.Remove(20);
            }
        }

        if (PhotonNetwork.PlayerList.Length == 5)
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[2].NickName;
            if (PhotonNetwork.PlayerList[2].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[2].NickName = PhotonNetwork.PlayerList[2].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[3].NickName;
            if (PhotonNetwork.PlayerList[3].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[3].NickName = PhotonNetwork.PlayerList[3].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[4].NickName;
            if (PhotonNetwork.PlayerList[3].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[3].NickName = PhotonNetwork.PlayerList[4].NickName.Remove(20);
            }
        }

        if (PhotonNetwork.PlayerList.Length == 6)
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[2].NickName;
            if (PhotonNetwork.PlayerList[2].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[2].NickName = PhotonNetwork.PlayerList[2].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[3].NickName;
            if (PhotonNetwork.PlayerList[3].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[3].NickName = PhotonNetwork.PlayerList[3].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[4].NickName;
            if (PhotonNetwork.PlayerList[4].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[4].NickName = PhotonNetwork.PlayerList[4].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[5].NickName;
            if (PhotonNetwork.PlayerList[5].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[5].NickName = PhotonNetwork.PlayerList[5].NickName.Remove(20);
            }
        }

        if (PhotonNetwork.PlayerList.Length == 7)
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[2].NickName;
            if (PhotonNetwork.PlayerList[2].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[2].NickName = PhotonNetwork.PlayerList[2].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[3].NickName;
            if (PhotonNetwork.PlayerList[3].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[3].NickName = PhotonNetwork.PlayerList[3].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[4].NickName;
            if (PhotonNetwork.PlayerList[4].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[4].NickName = PhotonNetwork.PlayerList[4].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[5].NickName;
            if (PhotonNetwork.PlayerList[5].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[5].NickName = PhotonNetwork.PlayerList[5].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[6].NickName;
            if (PhotonNetwork.PlayerList[6].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[6].NickName = PhotonNetwork.PlayerList[6].NickName.Remove(20);
            }
        }

        if (PhotonNetwork.PlayerList.Length == 8)
        {
            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[0].NickName;
            if (PhotonNetwork.PlayerList[0].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[0].NickName = PhotonNetwork.PlayerList[0].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[1].NickName;
            if (PhotonNetwork.PlayerList[1].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[1].NickName = PhotonNetwork.PlayerList[1].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[2].NickName;
            if (PhotonNetwork.PlayerList[2].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[2].NickName = PhotonNetwork.PlayerList[2].NickName.Remove(20);
            }


            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[3].NickName;
            if (PhotonNetwork.PlayerList[3].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[3].NickName = PhotonNetwork.PlayerList[3].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[4].NickName;
            if (PhotonNetwork.PlayerList[4].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[4].NickName = PhotonNetwork.PlayerList[4].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[5].NickName;
            if (PhotonNetwork.PlayerList[5].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[5].NickName = PhotonNetwork.PlayerList[5].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[6].NickName;
            if (PhotonNetwork.PlayerList[6].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[6].NickName = PhotonNetwork.PlayerList[6].NickName.Remove(20);
            }

            JoinedText.text = JoinedText.text + "\n" + PhotonNetwork.PlayerList[7].NickName;
            if (PhotonNetwork.PlayerList[7].NickName.Length > 20)
            {
                PhotonNetwork.PlayerList[7].NickName = PhotonNetwork.PlayerList[7].NickName.Remove(20);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape) && AreYouSureScreen.activeSelf)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                PhotonNetwork.Disconnect();
            }

            AreYouSureScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        if (AreYouSureScreen.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                YOUWON.SetActive(false);
                AreYouSureScreen.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }
}
