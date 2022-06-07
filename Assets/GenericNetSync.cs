using Photon.Pun;
using UnityEngine;


/// <summary>
/// Dient dazu die Kopfrotation zu übertragen.
/// </summary>
public class GenericNetSync : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private bool isUser = default;
    [SerializeField] private GameObject moveDir;
    private Camera mainCamera;
    private Quaternion networkLocalRotation;
    private Quaternion startingLocalRotation;
    private Quaternion newRotation;
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(transform.localRotation);
        }
        else
        {

            networkLocalRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    private void Start()
    {
        mainCamera = Camera.main;
        moveDir = GameObject.Find("MoveDirection");
        var trans = transform;
        startingLocalRotation = trans.localRotation;
        networkLocalRotation = startingLocalRotation;
    }
    private void LateUpdate()
    {
        if (!photonView.IsMine)
        {
            var trans = transform;
            trans.localRotation = networkLocalRotation;
        }

        if (photonView.IsMine && isUser)
        {
            var trans = transform;
            var mainCameraTransform = mainCamera.transform;

            trans.rotation = mainCameraTransform.rotation;
        }
    }
    //Sollte dazu dienen zu verhindern das der Avatar seinen Kopf mehr als 90* zu jeder Seite drehen kann. Ist aber noch fehlerhaft.    
    private Quaternion limitRotation(Quaternion localRot)
    {

        //localRot = Quaternion.Slerp(localRot, moveDir.transform.rotation, 0.5f);

        return localRot;

    }
}



