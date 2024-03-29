using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Coroutine _timeCounter;

    private float _timerValueInSeconds;
    private bool _isTimerWork;

    private void Start()
    {
        _isTimerWork = false;
        _timerValueInSeconds = 0;
    }

    private void OnDisable()
    {
        if (_timeCounter != null)
            StopCoroutine(_timeCounter);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            _isTimerWork = !_isTimerWork;

            if (_isTimerWork)
                _timeCounter = StartCoroutine(CountSeconds());
            else
                StopCoroutine(_timeCounter);
        }
    }

    private void UpdateTimeText()
    {
        _text.text = _timerValueInSeconds.ToString("0.0");
    }

    private IEnumerator CountSeconds()
    {
        float delayInSeconds = 0.5f;

        WaitForSeconds delay = new WaitForSeconds(delayInSeconds);

        yield return delay;

        while (_isTimerWork)
        {
            _timerValueInSeconds += delayInSeconds;
            UpdateTimeText();

            yield return delay;
        }
    }
}

