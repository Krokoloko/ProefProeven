using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private SwitchScene _switchScene;

    private void Start()
    {
        _switchScene = GetComponent<SwitchScene>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            _switchScene.SwitchScenes();
        }
    }
}
