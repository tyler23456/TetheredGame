using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TG.Canvas
{
    public class OutGameSingleplayer : OutGameBase
    {
        [SerializeField] Button start;

        protected void Start()
        {
            start.onClick.AddListener(() => { });
        }
    }
}