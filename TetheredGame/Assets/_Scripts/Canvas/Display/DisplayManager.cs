using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] Slider sanityBar;
    [SerializeField] Slider thrillBar;
    [SerializeField] TMP_Text livesText;

    void Start()
    {
        ICharacter player = GameObject.Find("/DontDestroyOnLoad").GetComponent<IFactory>().getPlayer.GetComponent<ICharacter>();

        player.getStats.AddOnValueChangedTo("Sanity", (value) => sanityBar.value = value);
        player.getStats.AddOnValueChangedTo("Thrill", (value) => thrillBar.value = value);
        player.getStats.AddOnValueChangedTo("Lives", (value) => livesText.text = value.ToString() + " lives");
    }
}
