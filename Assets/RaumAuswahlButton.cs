using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
// Das Skript dient dazu das Erstellen und Beitreten eines Photon Network Raumes durch Buttons und Textfeldern zu ermöglichen.
public class RaumAuswahlButton : MonoBehaviour
{
    [SerializeField] private InputField roomCreateInputField;
    [SerializeField] private InputField roomJoinInputField;
    [SerializeField] private GameObject buttons;
    private List<string> roomNames;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }
    // Beim Klicken auf den Raumerstellungsbutton wird ein Raum mit dem im Textfeld eingegebenen Namen erstellt
    public void OnClickCreate()
    {
        if (roomCreateInputField.text.Length >= 1)
        {
            // Einschränkung der Anzahl der Räume, weil die Anzahl der Leute auf dem zugewiesenen Server eingeschränkt sind
            if (roomNames.Count < 5)
            {
                roomNames.Add(roomCreateInputField.text);
                PhotonNetwork.CreateRoom(roomCreateInputField.text);
                // Raum muss auch noch wieder entfernt werden aus der Liste in der OnLeftRoom Methode
            }
        }
    }
    // Beim Klicken auf den Raumbeitrittsbutton wird ein Raum mit dem im Textfeld eingegebenen Namen beigetreten
    public void OnClickJoin()  {
        if (roomJoinInputField.text.Length >= 1)
        {
            bool roomExists = false;
            foreach (string roomName in roomNames) {
                if (roomJoinInputField.text.Equals(roomName)) {
                    roomExists = true;
                }
            }
            if (roomExists)
            {
                PhotonNetwork.CreateRoom(roomJoinInputField.text);
            }
        }   
    }

}
