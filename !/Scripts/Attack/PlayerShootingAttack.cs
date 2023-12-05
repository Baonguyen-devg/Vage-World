using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class PlayerShootingAttack : ShootingAttack
    {
        [SerializeField] protected List<Transform> supporters;
        [SerializeField] private float mana = 100f;
        [SerializeField] private EventSO EventPlayerShoote;

        private float _timeShootePrevious;
        private string _bulletName;

        #region Load Component Methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            if (supporters.Count != 0) return;
            foreach (Transform supporter in transform)
                supporters.Add(supporter.Find("Point")?.transform);
        }
        #endregion

        public virtual void SetActiveTeamSupporter(bool status)
        {
            foreach (Transform supporter in supporters)
            {
                supporter.parent.Find("Model").gameObject.SetActive(status);
                supporter.gameObject.SetActive(status);
            }

            supporters[0].parent.Find("Model").gameObject.SetActive(true);
            supporters[0].gameObject.SetActive(true);
        }

        public virtual int GetIndexSupporter(Transform suppoterGet)
        {
            foreach (Transform supporter in supporters)
                if (suppoterGet.GetInstanceID().Equals(supporter.GetInstanceID()))
                    return supporters.IndexOf(supporter);
            return 0;
        }

        public virtual bool SupportShoote()
        {
            if (!GameManager.Instance.IsGamePlaying()) return false;
            //sua lai
            if (Time.time - _timeShootePrevious < attackDelay) return false;
            _timeShootePrevious = Time.time;

            SetBulletToShoote();
            foreach (Transform point in supporters)
            {
                if (!point.gameObject.activeInHierarchy) continue;
                Shoote(_bulletName, point);
            }
            InvokeShootePlayerEvent();
            return true;
        }

        private void SetBulletToShoote()
        {
            bool isSkill3 = SkillManager.Instance.CanUseSkill_3();
            _bulletName = (isSkill3) ? BulletSpawner.BULLET_TORNADO : BulletSpawner.BULLET_PLAYER;
        }

        protected override void CustomizeBullet(Transform bullet, Transform point)
        {
            base.CustomizeBullet(bullet, point);
            bullet.position = point.position;

            bullet.gameObject.SetActive(true);
            bool isSkill2 = SkillManager.Instance.CanUseSkill_2();
            if (isSkill2) ZoomBullet(bullet);
        }

        protected virtual void ZoomBullet(Transform bullet)
        {
            bullet.transform.localScale += new Vector3(2, 2, 0);
            bullet.GetComponent<PlayerBulletController>().DamageSender.IncreaseDame(100);
        }

        public float GetMana() => mana;
        private void InvokeShootePlayerEvent() => EventPlayerShoote.Raise();
        public List<Transform> GetPointShootes() => supporters;
    }
}