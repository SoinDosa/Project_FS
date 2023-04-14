using PFS.GamePlay.Enemy.enemyBase;
using PFS.GamePlay.Player.playerEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Enemy.bomb
{
    public class Bomb : EnemyBase
    {
        private void Start()
        {
            _hp = INIT_HP;
        }

        public override void Attack() { }

        public override void Move() { }

        public override void OnDamaged()
        {
            _hp--;

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
