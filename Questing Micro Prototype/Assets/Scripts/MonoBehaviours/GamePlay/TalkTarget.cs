using System;
using Interfaces;
using UnityEngine;

namespace MonoBehaviours.GamePlay
{
    [RequireComponent(typeof(BoxCollider))]
    public class TalkTarget : MonoBehaviour, IInteractable
    {
        public Action onTalk;

        public void Interaction() => onTalk?.Invoke();
    }
}