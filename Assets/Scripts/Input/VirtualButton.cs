using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VirtualButton : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onClickEnter;

    [SerializeField]
    private UnityEvent _onClickStay;

    [SerializeField]
    private UnityEvent _onClickExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
