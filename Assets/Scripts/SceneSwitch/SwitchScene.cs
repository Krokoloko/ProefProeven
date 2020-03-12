using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private int _sceneBuildNumber;
    [SerializeField] private GameObject[] _showImagesObject;
    [SerializeField] private float _waitTimeBetweenImages;

    private IEnumerator _coroutine;

    private void Start()
    {
        _coroutine = SwitchSceneCoroutine();       
    }
    private void StartCoroutine() 
    {
        StartCoroutine(_coroutine);
    }
    private void StopCoroutine() 
    {
        StopCoroutine(_coroutine);
    }
    private IEnumerator SwitchSceneCoroutine()
    {
        if(_showImagesObject.Length > 0) 
        {
            GameObject _previousObject = null;
            foreach(GameObject Object in _showImagesObject) 
            {
                Object.SetActive(true);

                yield return new WaitForSeconds(_waitTimeBetweenImages);

                if(_previousObject != null)
                {
                    _previousObject.SetActive(false);
                }
                _previousObject = Object;
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
