using UnityEngine;
using UniRx;

namespace Manager
{
    public class InputManager : AutoMonobehaviour
    {
        private static InputManager instance;
        public static InputManager GetInstance()
        {
            if (instance == null) instance = new InputManager();
            return instance;
        }

        private bool escapePress = false;
        private bool enterPress = false;
        private bool spacePress = false;
        private bool fPress = false;

        private bool rightMousePress = false;
        private bool leftMousePress = false;

        public static event System.Action LeftMousePressEvent;

        protected override void LoadComponentInAwakeBefore()
        {
            base.LoadComponentInAwakeBefore();
            InputManager.instance = this;
            Observable.EveryUpdate().Subscribe(_ => OnPress()).AddTo(this);
        }

        public Vector3 GetMousePosition() => Camera.main.ScreenToWorldPoint(Input.mousePosition);
        public float GetAxisHorizontal() => Input.GetAxis("Horizontal");
        public float GetAxisVertical() => Input.GetAxis("Vertical");

        private void OnPress()
        {
            if (!CanPress()) return;

            escapePress = Input.GetKeyDown(KeyCode.Escape);
            enterPress = Input.GetKeyDown(KeyCode.Return);
            fPress = Input.GetKeyDown(KeyCode.F);
            spacePress = Input.GetKeyDown(KeyCode.Space);

            rightMousePress = Input.GetMouseButtonDown(1);
            leftMousePress = Input.GetMouseButtonDown(0);

            if (leftMousePress) LeftMousePressEvent?.Invoke();
        }

        private bool CanPress() => true;

        public bool IsEscapePress() => escapePress;
        public bool IsEnterPress() => enterPress;
        public bool IsRightMousePress() => rightMousePress;
        public bool IsLeftMousePress() => leftMousePress;
        public bool IsSpacePress() => spacePress;
        public bool IsFPress() => fPress;
    }
}