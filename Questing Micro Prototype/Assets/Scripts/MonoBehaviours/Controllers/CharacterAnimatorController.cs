using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class CharacterAnimatorController : MonoBehaviour, IAnimatorController
    {
        public GameObject animatorSource;
        public Animator animator;
        public RuntimeAnimatorController overrideAnimatorController;
        public GameObject moveableSource;
        public IMoveable moveable;

        private void Update()
        {
            if (animator != null && moveable != null) SetFloat("speed", moveable.Velocity);
        }

        private void OnEnable()
        {
            CacheAnimator();
            CacheMoveable();
        }

        public GameObject AnimatorSource
        {
            get => animatorSource != null ? animatorSource : gameObject;
            set
            {
                animatorSource = value;
                CacheAnimator();
            }
        }

        public void OverrideAnimatorController() => animator.runtimeAnimatorController = overrideAnimatorController;
        public void SetTrigger(string triggerName) => animator.SetTrigger(triggerName);
        public void SetFloat(string floatKey, float floatValue) => animator.SetFloat(floatKey, floatValue);

        private void CacheAnimator() => animator = AnimatorSource.GetComponent<Animator>();
        private void CacheMoveable() =>
            moveable = (moveableSource != null ? moveableSource : gameObject).GetComponent<IMoveable>();
    }
}