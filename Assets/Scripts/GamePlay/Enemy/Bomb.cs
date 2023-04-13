using PFS.GamePlay.Enemy.enemyBase;
using PFS.GamePlay.Player.playerEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Enemy.bomb
{
    public class Bomb : EnemyBase
    {
        public override void Attack() { }

        public override void Move() { }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
