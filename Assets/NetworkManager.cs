using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
/// <summary>
///  Dieses Skript dient dazu den Nutzer zu dem Server initial zu verbinden und die Buttons zur Avatarauswahl erscheinen zu lassen,
///  sobald dies geschehen ist.
/// </summary>
public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server...");
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();
        buttons.SetActive(true);
    }




    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new Player has joined");
        base.OnPlayerEnteredRoom(newPlayer);
    }

}
