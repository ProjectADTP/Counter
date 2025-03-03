using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _counterValue;
    
    public void ChangeCounterValue(float counterValue)
    {
        _counterValue = counterValue;
        ShowCounterValue();
    }

    private void Start()
    {
        ShowCounterValue();
    }

    private void ShowCounterValue()
    {
        _text.text = _counterValue.ToString();
    }
}