using UnityEngine;

namespace PFS.GamePlay.Enemy.enemyBase
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected int INIT_HP;
        [SerializeField] protected float ATTACK_DELAY;
        [SerializeField] protected Transform _hpBar;
        protected int _hp;
        public int HP { get { return _hp; } set { _hp = value; } }

        abstract public void Attack();
        abstract public void Move();
        virtual public void OnDamaged()
        {
            _hp--;
            Debug.Log($"Enemy HP = {_hp}");
            if (_hp <= 0)
            {
                Destroy(this.gameObject);

                return;
            }

            float ratio = (float)_hp / INIT_HP;
            _hpBar.transform.localScale = new Vector3(ratio, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
        }
    }
}
