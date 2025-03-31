using UnityEngine;
using UnityEngine.UI;

namespace Clock
{
    public class Clock : MonoBehaviour
    {
        [SerializeField] private Text _clockText;
        [SerializeField] private float _timeScale = 1f;

        private int _minutes;
        private int _hours;
        private int _seconds;
        private float _counter;

        private void Update()
        {
            _counter += Time.deltaTime * _timeScale;

            if (_counter >= 1f)
            {
                _counter -= 1f;
                _seconds++;
                
                if (_seconds >= 60)
                {
                    _seconds = 0;
                    _minutes++;

                    if (_minutes >= 60)
                    {
                        _minutes = 0;
                        _hours++;

                        if (_hours >= 24)
                            _hours = 0;
                    }
                }
                
                UpdateClockDisplay();
            }
        }
        
        private void UpdateClockDisplay()
        {
            _clockText.text = $"{_hours:00}:{_minutes:00}:{_seconds:00}";
        }
    }
}