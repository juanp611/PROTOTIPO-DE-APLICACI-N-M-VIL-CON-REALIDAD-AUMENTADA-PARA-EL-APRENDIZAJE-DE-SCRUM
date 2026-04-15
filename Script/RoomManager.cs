using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RoomManager : MonoBehaviourPunCallbacks
{
    public Button[] roomButtons; 
    public TMP_Text feedbackText; 
    private int maxPlayersPerRoom = 5;

 private void Start()
    {
        foreach (Button btn in roomButtons)
        {
            btn.onClick.AddListener(() => JoinRoom(btn.name));
            btn.interactable = false; 
        }

        PhotonNetwork.ConnectUsingSettings(); 
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); 
    }

    public override void OnJoinedLobby()
    {
        feedbackText.text = "Conectado al lobby. Listo para unirse a una sala.";
        
        foreach (Button btn in roomButtons)
        {
            btn.interactable = true;
        }
    }

    private void JoinRoom(string roomName)
    {
        feedbackText.text = $"Intentando unirse a la sala: {roomName}...";

        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = (byte)maxPlayersPerRoom
        };

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        feedbackText.text = $"Te uniste a la sala {PhotonNetwork.CurrentRoom.Name}";

        // Verificar si el jugador es el primero en la sala
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            feedbackText.text += "\nEres el Scrum Master de esta sala.";
            // Cargar la escena "crearHU" para el Scrum Master
            SceneManager.LoadScene("Historia Usuario");
        }
        else
        {
            feedbackText.text += "\nEres desarrollador del equipo.";
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        feedbackText.text = "La sala está llena o ocurrió un error al intentar unirse.";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= maxPlayersPerRoom)
        {
            feedbackText.text = "La sala ha alcanzado el número máximo de miembros.";
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        feedbackText.text = "Saliendo de la sala...";
    }

    public override void OnLeftRoom()
    {
        feedbackText.text = "Has salido de la sala.";
    }
}