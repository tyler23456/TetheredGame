using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TG.Canvas
{
    public class OutGameMultiplayer : OutGameBase
    {
        [SerializeField] Button create;
        [SerializeField] Button join;

        protected void Start()
        {
            create.onClick.AddListener(() => lobby.CreateLobby());
            create.onClick.AddListener(() => outGame.OpenLobby());

            join.onClick.AddListener(() => lobby.CreateLobby());
            join.onClick.AddListener(() => outGame.OpenLobby());
        }
    }
}