using Photon.Pun;
using UnityEngine;

public class BallThrower : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    private Rigidbody _rb;
    private Vector3 _initialForce;
    private bool _applyForce;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        Debug.Log("OnPhotonInstantiate CALLED!");
        object[] data = info.photonView.InstantiationData;

        if (data != null && data.Length == 3)
        {
            Vector3 force = new Vector3(
                (float)data[0],
                (float)data[1],
                (float)data[2]
            );

            Debug.Log($"OnPhotonInstantiate applying force {force}");
            _rb.velocity = force;
        }
    }
}
