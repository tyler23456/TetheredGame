using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

namespace TG.Canvas
{
    public class LobbyMultiplayer : MonoBehaviour
    {
        [SerializeField] TMP_InputField input;
        [SerializeField] Button createServer;
        [SerializeField] Button joinServer;

        private void Awake()
        {
            createServer.onClick.AddListener(CreateServer);
            joinServer.onClick.AddListener(JoinServer);
        }

        void CreateServer()
        {
            NetworkManager.Singleton.StartHost();
            gameObject.SetActive(false);

        }

        void JoinServer()
        {
            NetworkManager.Singleton.StartClient();
            gameObject.SetActive(false);
        }

    }
}