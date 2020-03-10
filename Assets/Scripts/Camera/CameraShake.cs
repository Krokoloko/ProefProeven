using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public static CameraShake Instance;

    private Vector3 _originalPos;
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;

    private void Awake()
    {
        Instance = this;
    }

    private void Update() {
        // Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;
    }

    /// <summary>
    /// Shake the camera
    /// </summary>
    /// <param name="duration">How long to shake</param>
    /// <param name="amount">Intensity of the shake</param>
    public static void Shake (float duration, float amount) {
        Instance._originalPos = Instance.gameObject.transform.localPosition;
        Instance.StopAllCoroutines();
        Instance.StartCoroutine(Instance.cShake(duration, amount));
    }

    private IEnumerator cShake (float duration, float amount) {
        float endTime = Time.time + duration;

        while (duration > 0) {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= _fakeDelta;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}