using Interfaces;
using ScriptableObjects.Events;
using ScriptableObjects.SelectableCharacter;
using ScriptableObjects.Vars;
using UnityEngine;

namespace MonoBehaviours.Spawners
{
    public class SelectableCharacterSpawner : MonoBehaviour, ISpawnable<GameObject>, ISpawner
    {
        public GameObjectEvent onSpawn;
        public Transform parentTransform;

        public GameObject Spawnable =>
            selectedCharacter != null && selectedCharacter.value != null
                ? selectedCharacter.value.prefab.Value
                : defaultSelectableCharacter.prefab.Value;

        public SelectableCharacterVar selectedCharacter;
        public SelectableCharacter defaultSelectableCharacter;
        public GameObject instance;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            DestroyInstance();

            instance = Instantiate(Spawnable, parentTransform);
            if (onSpawn != null) onSpawn.Broadcast(instance);
        }

        [ContextMenu("De-spawn")]
        public void DestroyInstance()
        {
            if (instance != null) Destroy(instance);
        }
    }
}