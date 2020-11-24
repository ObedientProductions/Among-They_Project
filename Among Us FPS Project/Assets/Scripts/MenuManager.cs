using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public static string Name = "";
    public static float MusicVolume = 0.02f;

    public static bool NormalGraphics, UltraGraphics;
    public static int[] ListOfCharacters = { 1, 2, 3, 4 };

    public Slider Progress;
    public Text ProgressText;
    public GameObject Options, MainMenu, NameMenu, Loading, Map, SelectCharacter;
    public Slider GameVolume;
    public Text VolumePersentage;
    public InputField NameInput;

    public Transform SpawnPoint;

    public AudioSource Music;

    public GameObject Red, Blue, Black, Yellow;

    public Text EnteredName;

    float TimePast;
    bool IsCharLoaded = false;
    private void Update()
    {
        if (IsCharLoaded)
        {
            TimePast = TimePast + Time.deltaTime;
        }

        Debug.Log(Time.timeScale);
        EnteredName.text = Name;
        
    }

    private void Start()
    {
        Music.volume = MusicVolume;
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
    }

    public void OnSliderChanged() 
    {
        Music.volume = GameVolume.value;

        float MusicPercentage = Music.volume * 100f;
        MusicPercentage = Mathf.Round(MusicPercentage);

        VolumePersentage.text = MusicPercentage.ToString() + "%";

        MusicVolume = GameVolume.value;
    }

    public void SelectRed() 
    {
        if (SpawnPoint.childCount == 0)
        {
            Instantiate(Red, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[0];
        }

        else 
        {
            Destroy(SpawnPoint.GetChild(0).gameObject);
            Instantiate(Red, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[0];
        }
    }

    public void SelectBlue()
    {
        if (SpawnPoint.childCount == 0)
        {
            Instantiate(Blue, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[1];
        }

        else
        {
            Destroy(SpawnPoint.GetChild(0).gameObject);
            Instantiate(Blue, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[1];

        }
    }

    public void SelectBlack()
    {
        if (SpawnPoint.childCount == 0)
        {
            Instantiate(Black, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[2];
        }

        else
        {
            Destroy(SpawnPoint.GetChild(0).gameObject);
            Instantiate(Black, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[2];
        }
    }

    public void SelectYellow()
    {
        if (SpawnPoint.childCount == 0)
        {
            Instantiate(Yellow, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[3];

        }

        else
        {
            Destroy(SpawnPoint.GetChild(0).gameObject);
            Instantiate(Yellow, SpawnPoint.localPosition, Quaternion.identity, SpawnPoint);

            Gun.SelectedCharacter = ListOfCharacters[3];
        }
    }
    public void OpenOptions() 
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
        GameVolume.value = Music.volume;
    }

    public void CloseOptions()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }

    public void OpenNameMenu() 
    {
        MainMenu.SetActive(false);
        NameMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void SelectPlayer() 
    {
        SelectRed();
        Name = NameInput.text;
        NameMenu.SetActive(false);
        SelectCharacter.SetActive(true);
    }
    public void Connect()
    {
        SelectCharacter.SetActive(false);
        Loading.SetActive(true);

        ProgressText.text = "Attemting To Connect To Server...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        ProgressText.text = "Finding Room...";
        Progress.value = 0.25f;

        PhotonNetwork.NickName = Name;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        ProgressText.text = "Could Not Find Room, Making Room...";
        Progress.value = 0.65f;
        Debug.Log(returnCode + message);
        PhotonNetwork.CreateRoom("");
    }

    public override void OnJoinedRoom()
    {
        ProgressText.text = "Joining Room...";
        Progress.value = 1f;
        SceneManager.LoadScene(1);
    }



}
