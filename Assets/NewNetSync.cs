using Photon.Pun;
using UnityEngine;


/// <summary>
/// Das Skript dient dazu den eigenen Avatar unsichtbar zu machen und dessen Kollision zu deaktivieren.
/// </summary>
public class NewNetSync : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private bool isUser = default;
    [SerializeField] GameObject[] avatarParts;
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }

    private void Start()
    {
        if (photonView.IsMine && isUser)
        {
            BoxCollider script = GetComponent<BoxCollider>();
            script.enabled = false;
            foreach (GameObject avatarPart in avatarParts)
            {
                avatarPart.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (photonView.IsMine && isUser)
        {
            foreach (GameObject avatarPart in avatarParts)
            {
                avatarPart.SetActive(false);
            }
        }
    }

}
