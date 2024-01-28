using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TG.Canvas
{
    public class OutGameMain : OutGameBase
    {
        [SerializeField] Button singleplayer;
        [SerializeField] Button multiplayer;
        [SerializeField] Button quit;

        protected void Start()
        {
            singleplayer.onClick.AddListener(() => outGame.OpenSingleplayer());

            multiplayer.onClick.AddListener(() => outGame.OpenMultiplayer());

            quit.onClick.AddListener(() => outGame.OpenQuit());
        }
    }
}
