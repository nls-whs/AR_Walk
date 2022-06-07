using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Skript um zu dem Server über einen Button zu connecten.
/// Wird aber momentan nicht genutzt.
/// </summary>
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;

    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();        
        }
    
    }

    public override void OnConnectedToMaster() {

        SceneManager.LoadScene("Lobby");
    
    
    }
}
