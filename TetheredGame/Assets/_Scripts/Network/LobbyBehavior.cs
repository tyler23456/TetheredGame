using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace TG.Network
{
    public class LobbyBehavior : MonoBehaviour
    {
        private string playerName = "Foo";
        private Lobby lobby;
        private float heartbeatTimer = Time.time;
        private float heartbeatDuration = 15;

        private float lobbyPollTimer = Time.time;
        private float lobbyPollDuration = 1.1f;

        private async void Start()
        {
            await UnityServices.InitializeAsync();

            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
            };
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        }

        private void Update()
        {
            HandleLobbyHearbeat();
            HandleLobbyPollForUpdates();
        }

        private async void HandleLobbyHearbeat()
        {
            if (lobby != null || Time.time < heartbeatTimer + heartbeatDuration)
                return;

            heartbeatTimer = Time.time;
            await LobbyService.Instance.SendHeartbeatPingAsync(lobby.Id);
        }


        private async void CreateLobby()
        {
            string lobbyName = "Test Lobby";
            int maxPlayers = 4;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions();
            createLobbyOptions.IsPrivate = false;
            createLobbyOptions.Player = GetPlayer();
            createLobbyOptions.Data = new Dictionary<string, DataObject>
        {
            { "GameMode", new DataObject(DataObject.VisibilityOptions.Member, "Survival")}
        };

            try
            {
                lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

                Debug.Log("Created Lobby! " + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Id + " " + lobby.LobbyCode);
                PrintPlayers(lobby);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }

        }

        private async void ListLobbies()
        {
            try
            {
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

                Debug.Log("Lobbies found: " + queryResponse.Results.Count);
                foreach (Lobby lobby in queryResponse.Results)
                {
                    Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
                }
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        private async void JoinLobbyByCode()
        {
            try
            {
                JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
                {
                    Player = GetPlayer()
                };
                //hostlobby.lobbycode needs to be the input of the code a person has entered
                lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(lobby.LobbyCode, joinLobbyByCodeOptions);

                Debug.Log("Joined lobby with code " + lobby.LobbyCode);

                PrintPlayers(lobby);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }

        }

        private async void QuickJoinLobby()
        {
            try
            {
                await LobbyService.Instance.QuickJoinLobbyAsync();
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        private void PrintPlayers(Lobby lobby)
        {
            Debug.Log("Players in lobby " + lobby.Name);
            foreach (Player player in lobby.Players)
            {
                Debug.Log(player.Id + " " + player.Data["PlayerName"].Value);
            }
        }

        private Player GetPlayer()
        {
            return new Player
            {
                Data = new Dictionary<string, PlayerDataObject>
            {
                { "PlayerName",  new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
            }
            };
        }

        private async void UpdateLobbyGameMode(string gameMode)
        {
            try
            {
                lobby = await Lobbies.Instance.UpdateLobbyAsync(lobby.Id, new UpdateLobbyOptions
                {
                    Data = new Dictionary<string, DataObject>
                    {
                        { "GameMode", new DataObject(DataObject.VisibilityOptions.Member, gameMode) }
                    }
                });
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        private async void HandleLobbyPollForUpdates()
        {
            if (lobby == null || Time.time < lobbyPollTimer + lobbyPollDuration)
                return;

            lobbyPollTimer = Time.time;

            lobby = await LobbyService.Instance.GetLobbyAsync(lobby.Id);
        }

        private async void UpdatePlayerName(string newPlayerName)
        {
            try
            {
                playerName = newPlayerName;
                lobby = await LobbyService.Instance.UpdatePlayerAsync(lobby.Id, AuthenticationService.Instance.PlayerId, new UpdatePlayerOptions
                {
                    Data = new Dictionary<string, PlayerDataObject>
                {
                    { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName)}
                }
                });
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        private async void LeaveLobby()
        {
            try
            {
                await LobbyService.Instance.RemovePlayerAsync(lobby.Id, AuthenticationService.Instance.PlayerId);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        private async void KickPlayer(string playerID)
        {
            try
            {
                await LobbyService.Instance.RemovePlayerAsync(lobby.Id, playerID);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }
    }
}
