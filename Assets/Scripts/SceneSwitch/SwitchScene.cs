using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private int _sceneBuildNumber;
    [SerializeField] private GameObject[] _showImagesObject;
    [SerializeField] private GameObject _background;
    [SerializeField] private float _waitTimeBetweenImages;
    [SerializeField] private PlayerDeath _playerDeath;
    [SerializeField] private bool _showCutscene;

    private IEnumerator _coroutine;
    private bool _canTrigger = true;    

    private void Start()
    {
        _coroutine = SwitchSceneCoroutine();       
    }
    private void StartCoroutine() 
    {
        if(_canTrigger) 
        {
            _canTrigger = false;
            if(_showCutscene) 
            {
                _playerDeath.enabled = false;
                _background.SetActive(true);
            }

            StartCoroutine(_coroutine);
        }        
    }
    private void StopCoroutine() 
    {
        StopCoroutine(_coroutine);
    }
    private IEnumerator SwitchSceneCoroutine()
    {
        if(_showImagesObject.Length > 0) 
        {
            foreach(GameObject Object in _showImagesObject) 
            {
                Object.SetActive(true);

                yield return new WaitForSeconds(_waitTimeBetweenImages);

                Object.SetActive(false);

            }

        }
        SceneManager.LoadScene(_sceneBuildNumber);
        StopCoroutine();
    }
    public void SwitchScenes()
    {
        StartCoroutine();
    }
}
