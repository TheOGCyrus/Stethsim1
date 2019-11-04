using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{

    private DataStack stack = new DataStack();
    //sound will hold the actual sound file
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
    
    }


    void Update()
    {
        Debug.Log("Sound filevv");
        stack.printSound();


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Rneck")
                {
                    //if the touched gameobject is a body part
                    print("HIT");
                    PlaySound();

                }
                   
            }


        }

 
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);

    }



}

