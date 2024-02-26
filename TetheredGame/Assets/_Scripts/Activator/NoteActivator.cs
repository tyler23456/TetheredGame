using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class NoteActivator : ActivatorBase, IActivator
    {
        GameObject noteDisplay = null;
        bool isActive = false;

        public override void LeftHandInteract()
        {
            if (user.getEquipped.isLeftHandOccupied && noteDisplay != null)
                UseNote();
            else if (user.getEquipped.isLeftHandOccupied && noteDisplay == null)
                DisplayNote();
            else if (!isActive)
                GrabNoteWithLeftHand();
        }

        public override void RightHandInteract()
        {
            if (user.getEquipped.isRightHandOccupied && noteDisplay != null)
                UseNote();
            else if (user.getEquipped.isRightHandOccupied && noteDisplay == null)
                DisplayNote();
            else if (!isActive)
                GrabNoteWithRightHand();
        }

        public void GrabNoteWithLeftHand()
        {
            isActive = true;
            factory.getAudioSource.PlayOneShot(factory.userAudio["TurnPage"]);
            user.getEquipped.GrabLeftHandEquipment(transform);
        }

        public void GrabNoteWithRightHand()
        {
            isActive = true;
            factory.getAudioSource.PlayOneShot(factory.userAudio["TurnPage"]);
            user.getEquipped.GrabRightHandEquipment(transform);
        }

        public void DisplayNote()
        {

            noteDisplay = gameObject;  
            factory.getAudioSource.PlayOneShot(factory.userAudio["TurnPage"]);
        }

        public void UseNote()
        {
            GameObject obj = factory.GetWeightedRandomEffect();
            obj = Instantiate(obj);
            if (obj.tag == "CharacterEffect")
            {
                user.getStatEffects.Add(obj.transform);
            }
            else if (obj.tag == "SceneEffect")
            {
                obj.transform.parent = global.getSceneEffects;
            }
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            Destroy(gameObject);
        }

        public void Update()
        {
            if (noteDisplay == null)
                return;

            noteDisplay.transform.position = Vector3.Lerp(noteDisplay.transform.position, global.getNoteDisplay.position, 0.2f);
            noteDisplay.transform.rotation = Quaternion.Slerp(noteDisplay.transform.rotation, global.getNoteDisplay.rotation, 0.2f);
        }
    }
}