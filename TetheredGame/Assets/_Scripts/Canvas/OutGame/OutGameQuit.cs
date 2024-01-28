using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TG.Canvas
{
    public class OutGameQuit : OutGameBase
    {
        [SerializeField] Button Yes;
        [SerializeField] Button no;

        protected void Start()
        {
            Yes.onClick.AddListener(() => Application.Quit());

            no.onClick.AddListener(() => outGame.OpenMain());
        }
    }
}