using UnityEngine;

namespace ResourceGaining
{
    public class GainingTool : MonoBehaviour
    {
        private const string AnimName = "Dig";
        
        [SerializeField] private float _rayDistance = 5f;
        
        private Animator _animator;
        private RaycastHit _hit;
        private Ray _ray;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                CheckForResourceHit();
        }

        private void PlayAnimation()
        { 
            _animator.SetTrigger(AnimName);
        }
        
        private void CheckForResourceHit()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, _rayDistance))
            {
                PlayAnimation();

                if (_hit.collider.TryGetComponent(out Resource resource))
                {
                    Debug.Log("Gained");
                }
            }
        }
    }
}
