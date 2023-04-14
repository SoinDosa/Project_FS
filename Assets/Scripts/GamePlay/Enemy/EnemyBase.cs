using System.Collections;
using System.Collections.Generic;
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
        abstract public void OnDamaged();
    }
}
