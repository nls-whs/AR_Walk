using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// Dieses Skipt dient dazu, dass beim Buttondruck der entsprechede Avatar initalisiert wird und richtig positionert wird.
/// </summary>
public class AvatarChoiceButton : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject buttons;
    private RoomOptions roomOptions;
    private GameObject avatarHead;
    [SerializeField] private GameObject[] spawnPositions;
    private int avatarchoice;
    private int spawnpoint;
    Player player;
    GameObject playerToSpawn;
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private GameObject[] avatare;
    public void Start()
    {

        roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
    }
    public void SetPlayerInfo(Player _player)
    {
        avatarchoice = (int)player.CustomProperties["avatar"];
        spawnpoint = (int)player.CustomProperties["spawn"];
        player = _player;
    }

    public void OnClickWeiblich()
    {
        playerProperties["avatar"] = 2;
        PhotonNetwork.LocalPlayer.CustomProperties = playerProperties;
        PhotonNetwork.JoinOrCreateRoom("Room 2", roomOptions, TypedLobby.Default);
        buttons.SetActive(false);
    }
    public void OnClickMannlich()

    {
        playerProperties["avatar"] = 1;
        PhotonNetwork.LocalPlayer.CustomProperties = playerProperties;
        PhotonNetwork.JoinOrCreateRoom("Room 2", roomOptions, TypedLobby.Default);
        buttons.SetActive(false);

    }

    public void OnClickNeutral()
    {
        playerProperties["avatar"] = 0;
        PhotonNetwork.LocalPlayer.CustomProperties = playerProperties;
        PhotonNetwork.JoinOrCreateRoom("Room 2", roomOptions, TypedLobby.Default);
        buttons.SetActive(false);

    }
    /// <summary>
    /// Plaziert den Avatar an einer der angegebenen Spawnpositionen je nach Anzahl der Leute im Raum.
    /// </summary>
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        playerProperties["spawn"] = PhotonNetwork.CurrentRoom.Players.Count - 1;
        Debug.Log(PhotonNetwork.CurrentRoom.Players.Count + "");
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        GameObject playerToSpawn = avatare[(int)PhotonNetwork.LocalPlayer.CustomProperties["avatar"]];
        GameObject locationToSpawn = spawnPositions[(int)PhotonNetwork.LocalPlayer.CustomProperties["spawn"]];
        avatarHead = PhotonNetwork.Instantiate(playerToSpawn.name, locationToSpawn.transform.position, locationToSpawn.transform.rotation);
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(avatarHead);
    }
    /// <summary>
    /// Neupositionierung aller verbleibenden Avatare, wenn jemand den Raum verlässt um überlappende Postionen zu vermeiden.
    /// </summary>
    /// <param name="otherPlayer"></param> Jede Person die nicht der Nutzer ist
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        int i = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            PhotonNetwork.Destroy(avatarHead);
            playerProperties["spawn"] = i;
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
            GameObject playerToSpawn = avatare[(int)PhotonNetwork.LocalPlayer.CustomProperties["avatar"]];
            GameObject locationToSpawn = spawnPositions[(int)PhotonNetwork.LocalPlayer.CustomProperties["spawn"]];
            avatarHead = PhotonNetwork.Instantiate(playerToSpawn.name, locationToSpawn.transform.position, locationToSpawn.transform.rotation);
            i++;

        }
    }
}
