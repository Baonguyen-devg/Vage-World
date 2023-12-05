using System.Collections;
using UnityEngine;

namespace Movement
{
    internal class PlayerMovement : Movement
    {
        private readonly int HORIZONTAL = Animator.StringToHash("Horizontal");
        private readonly int VERTICAL = Animator.StringToHash("Vertical");
        private readonly int SPEED = Animator.StringToHash("Speed");
        private readonly string PATH = "Characters/Player";

        [Header("[ Player Scriptable Object ]"), Space(10)]
        [SerializeField] private CharacterSO _playerSO;
   
        [Header("Player Movement"), Space(10)]
        [SerializeField] private Rigidbody2D _rigid2D;
        [SerializeField] private LootMaterial _lootMaterial;

        [Header("Player Controller"), Space(10)]
        [SerializeField] private PlayerController _controller;
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector2 _movement;

        #region Load Component Methods
        private void LoadLevelManagerSO() => _playerSO = Resources.Load<CharacterSO>(PATH);
        private void LoadRigidbody2D()
        {
            _rigid2D = transform.parent.GetComponent<Rigidbody2D>();
            (_rigid2D.gravityScale, _rigid2D.freezeRotation) = (0, true);
        }

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            LoadRigidbody2D();

            _controller = transform.parent.GetComponent<PlayerController>();
            _animator = _controller.Model.GetComponent<Animator>();
            _lootMaterial = transform.parent.Find("Loot Material").GetComponent<LootMaterial>();

            LoadLevelManagerSO();
            speed = _playerSO.GetSpeed();
        }
        #endregion

        protected override IEnumerator LoadWaitForLongTime()
        {
            yield return StartCoroutine(base.LoadWaitForLongTime());
            SetPlayerPosition();
        }

        private void SetPlayerPosition()
        {
            MapController controller = GameObject.Find("Map").GetComponent<MapController>();
            Transform land = controller.CreateMap.GetRandomLand();
            transform.parent.position = land.position;
        }

        public virtual void UpdateGetInputAxis(float axisX, float axisY) =>
            (_movement.x, _movement.y) = (axisX, axisY);

        protected override void Update()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            base.Update();

            float x = Manager.InputManager.GetInstance().GetAxisHorizontal();
            float y = Manager.InputManager.GetInstance().GetAxisVertical();
            if (x != 0 || y != 0 )
            {
                _lootMaterial.SetItemToPickup(null);
                UpdateGetInputAxis(x, y);
            }
            else if (_lootMaterial.GetItemToPickup() == null)
                    UpdateGetInputAxis(x, y);

            FlipLeft();
            SetAnimatorFLoats();
        }

        private void FlipLeft() =>
            _controller.Model.transform.rotation =
                (_movement.x < 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

        private void SetAnimatorFLoats()
        {
            _animator.SetFloat(HORIZONTAL, _movement.x);
            _animator.SetFloat(VERTICAL, _movement.y);
            _animator.SetFloat(SPEED, _movement.magnitude);
        }

        protected override void Move() =>
             _rigid2D.MovePosition(_rigid2D.position + _movement * speed * Time.fixedDeltaTime);
    }
}