using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Counter : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CounterView _counterView;

    private float _counterValue;
    private float _duration = 0.5f;
    private Coroutine _counterCoroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_duration);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_counterCoroutine == null)
        {
            _counterCoroutine = StartCoroutine(IncreaseCounterValue());
        }
        else
        {
            StopCoroutine(_counterCoroutine);

            _counterCoroutine = null;
        }
    }

    private IEnumerator IncreaseCounterValue()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime / 2;

            _counterValue++;
            _counterView.ChangeCounterValue(_counterValue);

            yield return _wait; 
        }
    }
}
