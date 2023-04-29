using PFS.GamePlay.Enemy.staticEnemy;
using PFS.GamePlay.ObjectPooling.objectPool;
using System.Collections;
using UnityEngine;

namespace PFS.GamePlay.Enemy.enemyArchor
{
    public class EnemyArchor : StaticEnemy
    {
        [SerializeField] private Vector3 _shotPower;
        private bool _isAttackable;
        private WaitForSeconds _wait;
        private ObjectPool _arrowPool;

        private void Start()
        {
            _hp = INIT_HP;

            _wait = new WaitForSeconds(ATTACK_DELAY);
            _arrowPool = GameObject.Find("ArrowPool").GetComponent<ObjectPool>();
            _isAttackable = true;
        }

        private void Update()
        {
            Attack();
        }

        public override void Attack()
        {
            StartCoroutine(AttackCoroutine());
        }

        public override void Move() { }

        IEnumerator AttackCoroutine()
        {
            if (_isAttackable)
            {
                _isAttackable = false;

                var obj = _arrowPool.PullObject();
                obj.transform.position = this.transform.position + new Vector3(-2, 0, 0);
                obj.GetComponent<Rigidbody2D>().AddForce(_shotPower);

                yield return _wait;
                _isAttackable = true;
            }
        }
    }
}
