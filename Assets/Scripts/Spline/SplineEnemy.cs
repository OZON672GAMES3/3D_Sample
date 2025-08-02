using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace.Spline
{
    public class SplineEnemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        
        private SplineContainer _splineContainer;
        private float _distanceTravelled;
        private float _splineLength;
        private float _yOffset;

        public void SetSpline(SplineContainer splineContainer, float offset)
        {
            _yOffset = offset;
            _splineContainer = splineContainer;
            _splineLength = splineContainer.CalculateLength();
            _distanceTravelled = 0f;
        }

        private void Update()
        {
            _distanceTravelled += _speed * Time.deltaTime;

            if (_distanceTravelled >= _splineLength)
            {
                OnReachEnd();
                return;
            }
            
            float t = _distanceTravelled / _splineLength;

            Vector3 pos = _splineContainer.EvaluatePosition(t);
            Vector3 forward = _splineContainer.EvaluateTangent(t);
            transform.position = pos + Vector3.up * _yOffset;

            if (forward != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }

        private void OnReachEnd()
        {
            Destroy(gameObject);
        }
    }
}