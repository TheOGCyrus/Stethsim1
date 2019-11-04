using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStack 
{
    //List that will hold all the sound files
    //List<AudioClip> audioList = new List<AudioClip>();
    public AudioClip[] audioClip;
    
    void Awake()
    {
        audioClip = Resources.LoadAll<AudioClip>("");
    }
   
    public DataStack()
    {
        audioClip = audioClip;
    }

        

    
  
  
        
       
  

    public void printSound()
    {
       foreach(var t in audioClip)
        {
            Debug.Log(t.name);
        }



    }


}
