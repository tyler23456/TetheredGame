using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TG.Canvas
{
    public class OutGamePlayer : OutGameBase
    {
        [SerializeField] TMP_InputField playerName;
        [SerializeField] TMP_Text characterName;
        [SerializeField] Button scrollLeft;
        [SerializeField] Button scrollRight;

        int index = 0;

        protected new void Awake()
        {
            base.Awake();

            index = 0;
            characterName.text = ICharacter.names[index];
            
            scrollLeft.onClick.AddListener(() => index = Mod(index - 1, ICharacter.names.Count));
            scrollLeft.onClick.AddListener(() => characterName.text = ICharacter.names[index]);

            scrollRight.onClick.AddListener(() => index = Mod(index + 1, ICharacter.names.Count));
            scrollRight.onClick.AddListener(() => characterName.text = ICharacter.names[index]);
        }

        int Mod(int value, int count)
        {
            return (value % count + count) % count;
        }
    }
}