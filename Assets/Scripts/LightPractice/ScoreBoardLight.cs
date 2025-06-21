using TMPro;
using UnityEngine;

namespace DefaultNamespace.LightPractice
{
    public class ScoreBoardLight : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreBoardText;

        private int _counter;

        public void AddScore(int score)
        {
            _counter += score;
        }
        
        private void Update()
        {
            _scoreBoardText.text = _counter.ToString();
        }
    }
}