using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScenario : MonoBehaviour
{

    public GameObject audioController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        audioController.GetComponent<AudioController>().AudioStop();
        audioController.GetComponent<AudioController>().LoadScenario(GetComponentInChildren<Text>().text);
    }
}
