using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TG.Canvas
{
    public class OutGameBehavior : NetworkBehaviour
    {
        [SerializeField] GameObject background;
        [SerializeField] GameObject main;
        [SerializeField] GameObject singleplayer;
        [SerializeField] GameObject multiplayer;
        [SerializeField] GameObject host;
        [SerializeField] GameObject client;
        [SerializeField] GameObject quit;
        [SerializeField] GameObject player;
        [SerializeField] GameObject serverCode;

        void Awake()
        {
            DeactivateAll();

            background.SetActive(true);
            main.SetActive(true);
        }

        public void DeactivateAll()
        {
            background.SetActive(false);
            main.SetActive(false);
            singleplayer.SetActive(false);
            multiplayer.SetActive(false);
            host.SetActive(false);
            client.SetActive(false);
            quit.SetActive(false);
            player.SetActive(false);
            serverCode.SetActive(false);
        }

        public void OpenMain()
        {
            DeactivateAll();

            background.SetActive(true);
            main.SetActive(true);
        }

        public void OpenSingleplayer()
        {
            DeactivateAll();

            background.SetActive(true);
            player.SetActive(true);
            singleplayer.SetActive(true);
        }

        public void OpenMultiplayer()
        {
            DeactivateAll();

            background.SetActive(true);
            multiplayer.SetActive(true);
        }

        public void OpenLobby()
        {
            DeactivateAll();

            background.SetActive(true);
            if (IsHost)
                host.SetActive(true);
            client.SetActive(true);
            player.SetActive(true);
            serverCode.SetActive(true);

        }

        public void OpenQuit()
        {
            DeactivateAll();

            background.SetActive(true);
            quit.SetActive(true);
        }

        public void Close()
        {
            DeactivateAll();
        }
    }
}