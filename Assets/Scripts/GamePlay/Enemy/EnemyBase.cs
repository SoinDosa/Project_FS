using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Enemy.enemyBase
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected int _hp;
        public int HP { get { return _hp; } set { _hp = value; } }
        [SerializeField] protected bool isAttackable;
        [SerializeField] protected float ATTACK_DELAY;

        abstract public void Attack();
        abstract public void Move();
    }
}
