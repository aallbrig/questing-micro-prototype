using Interfaces;
using ScriptableObjects.SelectableCharacter;
using ScriptableObjects.Vars;
using UnityEngine;
using UnityEngine.Playables;

namespace MonoBehaviours.Spawners
{
    public class SelectableCharacterSpawner : MonoBehaviour, ISpawner
    {
        public Transform parentTransform;
        public PlayableDirector director;

        [Tooltip("Name of timeline track to bind cutscene character to")]
        public string trackName;

        public SelectableCharacterVar selectedCharacter;
        public SelectableCharacter defaultSelectableCharacter;
        public RuntimeAnimatorController animator;
        private GameObject _instance;

        private SelectableCharacter Character =>
            selectedCharacter.value != null ? selectedCharacter.value : defaultSelectableCharacter;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            DestroyInstance();

            _instance = Instantiate(Character.prefab.Value, parentTransform);
            var animatorController = GetComponent<IAnimatorController>();
            if (animatorController != null)
            {
                animatorController.AnimatorSource = _instance;
                animatorController.UpdateAnimator(animator);
            }

            if (director != null)
            {
                var playableAssetOutput = director.playableAsset.outputs;
                foreach (var playableBinding in playableAssetOutput)
                    if (playableBinding.streamName == trackName)
                        director.SetGenericBinding(playableBinding.sourceObject, _instance.GetComponent<Animator>());
            }
        }

        [ContextMenu("De-spawn")]
        public void DestroyInstance()
        {
            if (_instance != null) Destroy(_instance);
        }
    }
}