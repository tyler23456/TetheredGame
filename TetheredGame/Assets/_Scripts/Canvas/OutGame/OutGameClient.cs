using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TG.Canvas
{
    public class OutGameClient : OutGameBase
    {
        [SerializeField] Button ready;
        [SerializeField] TMP_Text text;

        protected void Start()
        {
            //ready.onClick.AddListener(() => lobby.CreateLobby());
            ready.onClick.AddListener(() => text.text = text.text == "Ready" ? "Not Ready" : "Ready");
        }

        protected override void OnPressEscape()
        {
            outGame.OpenMultiplayer();
        }
    }
}