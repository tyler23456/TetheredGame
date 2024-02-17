using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILobby
{
    static List<string> lobbiesInfo { get; private set; } = new List<string>();
    static List<string> playersInfo { get; private set; } = new List<string>();

    void CreateLobby();
    void ListLobbies();
    void JoinLobbyByCode();
    void QuickJoinLobby();
    void UpdateLobbyGameMode(string gameMode);
    void UpdatePlayerName(string newPlayerName);
    void LeaveLobby();
    void KickPlayer(string playerID);

    int GetAverageAttribute(string attributeName);
}
