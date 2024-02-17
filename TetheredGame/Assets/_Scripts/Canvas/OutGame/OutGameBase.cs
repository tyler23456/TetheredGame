using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Canvas
{
    public class OutGameBase : MonoBehaviour
    {
        protected ILobby lobby;
        protected OutGameBehavior outGame;

        protected void Awake()
        {
            lobby = GameObject.Find("/DontDestroyOnLoad").GetComponent<ILobby>();
            outGame = GameObject.Find("/DontDestroyOnLoad/CanvasWorld/OutGame").GetComponent<OutGameBehavior>();
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnPressEscape();
        }

        protected virtual void OnPressEscape()
        {
            outGame.OpenMain();
        }
    }
}