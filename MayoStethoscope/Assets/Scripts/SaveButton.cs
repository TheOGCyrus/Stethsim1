using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
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

    public string saveName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Button Clicked");
        SaveScenario();
    }

    public void SaveScenario()
    {
        SaveSounds save = new SaveSounds();
        save.Lneck = Lneck.GetComponent<AudioSource>().clip;
        save.Rneck = Rneck.GetComponent<AudioSource>().clip;
        save.LTopChest = LTopChest.GetComponent<AudioSource>().clip;
        save.LMiddleChest = LMiddleChest.GetComponent<AudioSource>().clip;
        save.LBottomChest = LBottomChest.GetComponent<AudioSource>().clip;
        save.RTopChest = RTopChest.GetComponent<AudioSource>().clip;
        save.RMiddleChest = RMiddleChest.GetComponent<AudioSource>().clip;
        save.RBottomChest = RBottomChest.GetComponent<AudioSource>().clip;
        save.Chest_1 = Chest_1.GetComponent<AudioSource>().clip;
        save.Chest_2 = Chest_2.GetComponent<AudioSource>().clip;
        save.Heart_1 = Heart_1.GetComponent<AudioSource>().clip;
        save.Heart_2 = Heart_2.GetComponent<AudioSource>().clip;
        save.LTopStomach = LTopStomach.GetComponent<AudioSource>().clip;
        save.LBottomStomach = LBottomStomach.GetComponent<AudioSource>().clip;
        save.RTopStomach = RTopStomach.GetComponent<AudioSource>().clip;
        save.RBottomStomach = RBottomStomach.GetComponent<AudioSource>().clip;

        string json = JsonUtility.ToJson(save);
        Debug.Log(json);
        PlayerPrefs.SetString(saveName, json);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
