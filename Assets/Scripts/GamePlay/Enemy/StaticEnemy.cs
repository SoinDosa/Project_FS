using PFS.GamePlay.Enemy.enemyBase;

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
