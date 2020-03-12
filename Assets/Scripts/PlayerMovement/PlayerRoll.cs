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
    private LayerMask _invulnerableLayer;

    [SerializeField]
    private UnityEvent _OnRollEnter;

    [SerializeField]
    private UnityEvent _OnRollStay;

    [SerializeField]
    private UnityEvent _OnRollExit;

    private bool _rolling = false;

    void Awake()
    {
        _player = (!_player) ? gameObject : _player;    
    }

    public void TriggerRoll()
    {
        if (!_rolling)
        {
            _OnRollEnter?.Invoke();
            _rolling = true;

            StartCoroutine("Roll");
        }
    }

    private IEnumerator Roll()
    {
        Vector3 direction = (_player.transform.position - _player.transform.position+Vector3.forward).normalized;
        Vector3 destination = _player.transform.position + direction*_rollDistance;
        float rollDistancePerFrame = Vector3.Distance(_player.transform.position, destination)/_totalRollFrames;
        _player.layer += _invulnerableLayer;

        _OnRollEnter?.Invoke();
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < _totalRollFrames; i++) { 
            if (i == _invulnerableFrames)
            {
                _player.layer -= _invulnerableLayer;
            }

            _player.transform.Translate(direction * rollDistancePerFrame);

            _OnRollStay?.Invoke();
            yield return new WaitForEndOfFrame();
        }
        _OnRollExit?.Invoke();
        _rolling = false;
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
