using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public enum GameMode
    {
        Private,
        Casual,
        Ranked
    }

    private List<Player> localTeam = new List<Player>();
    private List<Player> opposingTeam = new List<Player>();
    private GameMode currentGameMode;
    private int teamSize; // 4 or 8

    public void StartPrivateMatch(int vs)
    {
        currentGameMode = GameMode.Private;
        teamSize = vs;
        PhotonNetwork.CreateRoom($"private_{System.Guid.NewGuid()}");
    }

    public void StartCasualMatch(int vs)
    {
        currentGameMode = GameMode.Casual;
        teamSize = vs;
        PhotonNetwork.JoinRandomRoom();
    }

    public void StartRankedMatch(int vs)
    {
        currentGameMode = GameMode.Ranked;
        teamSize = vs;
        // Find matched opponent based on rating
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"Joined room. Players: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer.NickName} joined");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Player {otherPlayer.NickName} left");
    }
}
