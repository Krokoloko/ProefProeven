 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRoll : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _rollDistance = 2;

    [SerializeField]
    private int _invulnerableFrames;

    [SerializeField]
    private int _totalRollFrames;

    [SerializeField]
    private int _invulnerableLayer;

    [SerializeField]
    private UnityEvent _onRollEnter;

    [SerializeField]
    private UnityEvent _onRollStay;

    [SerializeField]
    private UnityEvent _onRollExit;

    private bool _rolling = false;

    public delegate void onRol();
    public event onRol OnRol;

    void Awake()
    {
        _player = (!_player) ? gameObject : _player;    
    }

    public void TriggerRoll()
    {
        if (!_rolling)
        {
            _rolling = true;
            OnRol?.Invoke();
            StartCoroutine("Roll");
        }
    }

    private IEnumerator Roll()
    {
        Vector3 direction = (_player.transform.position - _player.transform.position+Vector3.forward).normalized;
        Vector3 destination = _player.transform.position + direction*_rollDistance;
        float rollDistancePerFrame = Vector3.Distance(_player.transform.position, destination)/_totalRollFrames;
        int originalLayer = _player.layer;
        _player.layer = _invulnerableLayer;

        _onRollEnter?.Invoke();
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < _totalRollFrames; i++) { 
            if (i == _invulnerableFrames)
            {
                _player.layer = originalLayer;
            }

            _player.transform.Translate(direction * rollDistancePerFrame);

            _onRollStay?.Invoke();
            yield return new WaitForEndOfFrame();
        }
        _onRollExit?.Invoke();
        _rolling = false;
    }
}
