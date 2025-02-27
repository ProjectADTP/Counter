using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CounterCoroutine : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _counterValue = 0f;
    private float _duration = 0.5f;
    private Coroutine _counterCoroutine;

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

    private void Start()
    {
        _text.text = _counterValue.ToString();
    }

    private IEnumerator IncreaseCounterValue()
    {
        while (true)
        {
            _counterValue++;
            _text.text = _counterValue.ToString();

            yield return new WaitForSeconds(_duration);
        }
    }
}
