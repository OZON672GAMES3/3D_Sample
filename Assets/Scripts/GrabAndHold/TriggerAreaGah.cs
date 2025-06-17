using UnityEngine;

namespace DefaultNamespace.GrabAndHold
{
    public class TriggerAreaGah : MonoBehaviour
    {
        [SerializeField] private DoorObjGah _door;

        private void OnCollisionEnter(Collision other)
        {
            OpenDoor();
        }

        private void OnCollisionExit(Collision other)
        {
            CloseDoor();
        }

        private void OpenDoor()
        {
            _door.gameObject.SetActive(false);
        }

        private void CloseDoor()
        {
            _door.gameObject.SetActive(true);
        }
    }
}