using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject Lneck;
    public GameObject Rneck;
    public GameObject LTopChest;
    public GameObject LMiddleChest;
    public GameObject LBottomChest;
    public GameObject RTopChest;
    public GameObject RMiddleChest;
    public GameObject RBottomChest;
    public GameObject Chest_1;
    public GameObject Chest_2;
    public GameObject Heart_1;
    public GameObject Heart_2;
    public GameObject LTopStomach;
    public GameObject LBottomStomach;
    public GameObject RTopStomach;
    public GameObject RBottomStomach;

    public bool playing = false;

    public AudioSource audioSource;

    void Awake()
    {

        audioSource = GetComponent<AudioSource>();

    }

    public void LoadScenario(string scenarioName)
    {
        string load = PlayerPrefs.GetString(scenarioName);
        SaveSounds s = JsonUtility.FromJson<SaveSounds>(load);

        Lneck.GetComponent<AudioSource>().clip = s.Lneck;
        Rneck.GetComponent<AudioSource>().clip = s.Rneck;
        LTopChest.GetComponent<AudioSource>().clip = s.LTopChest;
        LMiddleChest.GetComponent<AudioSource>().clip = s.LMiddleChest;
        LBottomChest.GetComponent<AudioSource>().clip = s.LBottomChest;
        RTopChest.GetComponent<AudioSource>().clip = s.RTopChest;
        RMiddleChest.GetComponent<AudioSource>().clip = s.RMiddleChest;
        RBottomChest.GetComponent<AudioSource>().clip = s.RBottomChest;
        Chest_1.GetComponent<AudioSource>().clip = s.Chest_1;
        Chest_2.GetComponent<AudioSource>().clip = s.Chest_2;
        Heart_1.GetComponent<AudioSource>().clip = s.Heart_1;
        Heart_2.GetComponent<AudioSource>().clip = s.Heart_2;
        LTopStomach.GetComponent<AudioSource>().clip = s.LTopStomach;
        LBottomStomach.GetComponent<AudioSource>().clip = s.LBottomStomach;
        RTopStomach.GetComponent<AudioSource>().clip = s.RTopStomach;
        RBottomStomach.GetComponent<AudioSource>().clip = s.RBottomStomach;

    }

    public void AudioPlay()
    {
        playing = true;
        audioSource.Play();
    }

    public void AudioStop()
    {
        playing = false;
        audioSource.Stop();
    }
}
