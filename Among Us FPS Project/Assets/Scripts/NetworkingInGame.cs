using Photon.Pun;
using UnityEngine;

public class NetworkingInGame : MonoBehaviourPunCallbacks
{
    public Transform SpawnPoint;
        
    void Start()
    {
        if (Gun.SelectedCharacter == 1)
        {
            PhotonNetwork.Instantiate("Players/Player Red", Gun.ListOfSpawnPoints[Random.Range(0, 4)], Quaternion.identity);
            Debug.Log("Start Instantiate Ran : Red");
        }

        if (Gun.SelectedCharacter == 2)
        {
            PhotonNetwork.Instantiate("Players/Player Blue", Gun.ListOfSpawnPoints[Random.Range(0, 4)], Quaternion.identity);
            Debug.Log("Start Instantiate Ran : Blue");
        }

        if (Gun.SelectedCharacter == 3)
        {
            PhotonNetwork.Instantiate("Players/Player Black", Gun.ListOfSpawnPoints[Random.Range(0, 4)], Quaternion.identity);
            Debug.Log("Start Instantiate Ran : Black");
        }

        if (Gun.SelectedCharacter == 4)
        {
            PhotonNetwork.Instantiate("Players/Player Yellow", Gun.ListOfSpawnPoints[Random.Range(0, 4)], Quaternion.identity);
            Debug.Log("Start Instantiate Ran : Yellow");
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Null Player", Gun.ListOfSpawnPoints[Random.Range(0,4)], Quaternion.identity);
        Debug.Log("OnJoinedROom Instantiate Ran");
    }
}
