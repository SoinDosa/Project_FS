using PFS.GamePlay.Enemy.enemyBase;
using PFS.GamePlay.Player.playerEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Enemy.staticEnemy
{
    public class StaticEnemy : EnemyBase
    {
        private void Start()
        {
            _hp = INIT_HP;
        }

        public override void Attack() { }

        public override void Move() { }

    }

}
