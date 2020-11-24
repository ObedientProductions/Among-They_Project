using UnityEngine;
using UnityEngine.UI;

public class UIManagerIngame : MonoBehaviour
{
    public AudioSource Music;
    public Slider SoundSlider;
    public GameObject PauseMenu;
    public GameObject Options;
    public GameObject PausedBG;
    void Start()
    {
        SoundSlider.value = MenuManager.MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            
        }
    }


    public void OptionsMenu()
    {
        if (Options.activeSelf) 
        {
            Options.SetActive(false);
        }

        else 
        {
            Options.SetActive(true);
        }
    }

    public void ChangeGameVolume() 
    {
        SoundSlider.value = MenuManager.MusicVolume;
        Music.volume = MenuManager.MusicVolume;
    }
}
