using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Playables;
using System.Linq;

namespace TG.DontDestroyOnLoad
{
    public class Factory : MonoBehaviour, IFactory
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject mainCamera;
        [SerializeField] Transform screenDisplay;
        [SerializeField] AudioSource audioSource;

        [SerializeField] AssetLabelReference concreteSprintReference;
        [SerializeField] AssetLabelReference concreteWalkReference;
        [SerializeField] AssetLabelReference dirtSprintReference;
        [SerializeField] AssetLabelReference dirtWalkReference;
        [SerializeField] AssetLabelReference emptySprintReference;
        [SerializeField] AssetLabelReference emptyWalkReference;
        [SerializeField] AssetLabelReference grassSprintReference;
        [SerializeField] AssetLabelReference grassWalkReference;
        [SerializeField] AssetLabelReference gravelSprintReference;
        [SerializeField] AssetLabelReference gravelWalkReference;
        [SerializeField] AssetLabelReference metalSprintReference;
        [SerializeField] AssetLabelReference metalWalkReference;
        [SerializeField] AssetLabelReference woodSprintReference;
        [SerializeField] AssetLabelReference woodWalkReference;
        [SerializeField] AssetLabelReference audioReference;
        [SerializeField] AssetLabelReference effectsReference;
        [SerializeField] AssetLabelReference canvasReference;
        [SerializeField] AssetLabelReference notesReference;
        [SerializeField] AssetLabelReference cursedItemsReference;


        public Dictionary<string, List<AudioClip>> StepSFX { get; private set; } = new Dictionary<string, List<AudioClip>>();
        public Dictionary<string, AudioClip> userAudio { get; private set; } = new Dictionary<string, AudioClip>();
        public Dictionary<string, GameObject> canvas { get; private set; } = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> effects { get; private set; } = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> notes { get; private set; } = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> cursedItems { get; private set; } = new Dictionary<string, GameObject>();

        public GameObject getPlayer => player;
        public GameObject getMainCamera => mainCamera;
        public Transform getScreenDisplay => screenDisplay;
        public AudioSource getAudioSource => audioSource;
        
        public void Awake()
        {
            audioSource.ignoreListenerPause = true;

            List<AssetLabelReference> stepSFXLabelReferences = new List<AssetLabelReference>
            {
            concreteSprintReference, concreteWalkReference,
            dirtSprintReference, dirtWalkReference,
            emptySprintReference, emptyWalkReference,
            grassSprintReference, grassWalkReference,
            gravelSprintReference, gravelWalkReference,
            metalSprintReference, metalWalkReference,
            woodSprintReference, woodWalkReference
            };

            List<AudioClip> stepSFXType = null;
            foreach (AssetLabelReference label in stepSFXLabelReferences)
            {
                stepSFXType = new List<AudioClip>();
                Addressables.LoadAssetsAsync<AudioClip>(label, (clip) =>
                {
                    stepSFXType.Add(clip);
                }).WaitForCompletion();
                StepSFX.Add(label.labelString, stepSFXType);
            }


            userAudio = new Dictionary<string, AudioClip>();
            Addressables.LoadAssetsAsync<AudioClip>(audioReference, (clip) =>
            {
                userAudio.Add(clip.name, clip);
            }).WaitForCompletion();

            effects = new Dictionary<string, GameObject>();
            Addressables.LoadAssetsAsync<GameObject>(effectsReference, (clip) =>
            {
                effects.Add(clip.name, clip);
            }).WaitForCompletion();

            canvas = new Dictionary<string, GameObject>();
            Addressables.LoadAssetsAsync<GameObject>(canvasReference, (clip) =>
            {
                canvas.Add(clip.name, clip);
            }).WaitForCompletion();

            notes = new Dictionary<string, GameObject>();
            Addressables.LoadAssetsAsync<GameObject>(notesReference, (clip) =>
            {
                notes.Add(clip.name, clip);
            }).WaitForCompletion();

            cursedItems = new Dictionary<string, GameObject>();
            Addressables.LoadAssetsAsync<GameObject>(cursedItemsReference, (clip) =>
            {
                cursedItems.Add(clip.name, clip);
            }).WaitForCompletion();


            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");

            GameObject obj = null;
            //--------------------------------------------------------------------
            for (int i = 0; i < 50; i++)
            {
                obj = Instantiate(notes["RegularNote"]);
                obj.transform.parent = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
            }


            //--------------------------------------------------------------------
        }

        public void MovePlayerTo(Vector3 position, Vector3 forward)
        {
            //Vector3 damping = follow.Damping;
            //follow.Damping = Vector3.zero;
            player.SetActive(false);
            player.transform.position = position;
            player.transform.forward = forward;
            player.SetActive(true);
            //camVirtual.UpdateCameraState(Vector3.up, -1);
            //follow.Damping = damping;
        }

        public RaycastHit RaycastFromCamera(float distance)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(screenCenterPoint);
            Physics.Raycast(ray, out RaycastHit hit, distance, LayerMask.NameToLayer("Player"));
            return hit;
        }

        public GameObject GetWeightedRandomEffect()
        {


            return effects.ElementAt(Random.Range(0, effects.Count)).Value;
        }
    }
}
