using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySoundPlay : MonoBehaviour
{

    private AudioController audioController;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    { 
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        PlayAudio();
    }

    void PlayAudio()
    {
        //audioController.AudioStop();
        if (audioController.playing == true && audioController.audioSource == gameObject.GetComponent<AudioSource>())
        {
            audioController.AudioStop();
        }
        else
        {
            audioController.AudioStop();
            audioController.audioSource = gameObject.GetComponent<AudioSource>();
            audioController.AudioPlay();
        }
    }
}
