using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class NoteActivator : ActivatorBase, IActivator
    {
        GameObject noteDisplay = null;

        public override void LeftHandInteract()
        {
            if (user.getEquipped.isLeftHandOccupied && noteDisplay != null)
                UseNote();
            else if (user.getEquipped.isLeftHandOccupied && noteDisplay == null)
                DisplayNote();
            else
                user.getEquipped.GrabLeftHandEquipment(transform);      
        }

        public override void RightHandInteract()
        {
            if (user.getEquipped.isRightHandOccupied && noteDisplay != null)
                UseNote();
            else if (user.getEquipped.isRightHandOccupied && noteDisplay == null)
                DisplayNote();
            else
                user.getEquipped.GrabRightHandEquipment(transform);          
        }

        public void DisplayNote()
        {
            factory.getAudioSource.PlayOneShot(factory.userAudio["TurnPage"]);
            noteDisplay = GameObject.Instantiate(factory.canvas["NoteDisplay"], factory.getScreenDisplay);
        }

        public void UseNote()
        {
            Destroy(noteDisplay);
            factory.equipment["SpawnStuff"].Use(user.getGameObject);
            Destroy(gameObject);
        }
    }
}