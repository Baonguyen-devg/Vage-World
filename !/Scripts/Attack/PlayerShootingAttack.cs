using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class PlayerShootingAttack : ShootingAttack
    {
        [SerializeField] protected List<Transform> supporters;
        [SerializeField] private float timeShootePrevious;
        [SerializeField] private float mana = 100f;

        public static event System.Action ShootePlayerEvent;
        private string bulletName;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            if (supporters.Count != 0) return;
            foreach (Transform supporter in transform)
                supporters.Add(supporter.Find("Point")?.transform);
        }

        public virtual void SetActiveTeamSupporter(bool status)
        {
            foreach (Transform supporter in supporters)
            {
                supporter.parent.gameObject.SetActive(status);
                supporter.parent.parent.Find("Model").gameObject.SetActive(status);
            }
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
            if (Time.time - timeShootePrevious < attackDelay) return false;
            timeShootePrevious = Time.time;

            //bool isSkill3 = SkillManager.GetInstance().GetPrefabByName("Skill_3").IsCanUse();
            bulletName = BulletSpawner.BULLET_PLAYER;
            //bulletName = (isSkill3) ? BulletSpawner.torandoBullet : BulletSpawner.playerBullet;
            
            foreach (Transform point in supporters)
            {
                if (!point.gameObject.activeInHierarchy) continue;
                Shoote(bulletName, point);
            }
            InvokeShootePlayerEvent();
            return true;
        }

        protected override void CustomizeBullet(Transform bullet, Transform point)
        {
            base.CustomizeBullet(bullet, point);
            bullet.position = point.position;
  
          /*  bool isSkill2 = SkillManager.GetInstance().GetPrefabByName("Skill_2").IsCanUse();
            if (isSkill2) ZoomBullet(bullet);*/
            bullet.gameObject.SetActive(true);
        }

        protected virtual void ZoomBullet(Transform bullet)
        {
            bullet.transform.localScale += new Vector3(1, 1, 0);
            bullet.GetComponent<PlayerBulletController>().DamageSender.IncreaseDame(20);
        }

        public float GetMana() => mana;
        private void InvokeShootePlayerEvent() => ShootePlayerEvent?.Invoke();
        public List<Transform> GetPointShootes() => supporters;
    }
}