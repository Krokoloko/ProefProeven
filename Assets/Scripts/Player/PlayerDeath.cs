using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private SwitchScene _switchScene;
    private GenericHealth _genericHealth;    

    private void Start() 
    {
        _switchScene = GetComponent<SwitchScene>();
        _genericHealth = GetComponent<GenericHealth>();        
        _genericHealth.onDeath.AddListener(PlayerDied);
    }
    private void PlayerDied() 
    {
        _switchScene.SwitchScenes();
        print("PlayerDied");
    }
    private void OnDestroy() 
    {
        _genericHealth.onDeath.RemoveListener(PlayerDied);
    }
}
