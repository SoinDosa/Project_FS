using PFS.GamePlay.Enemy.enemyBase;
using UnityEngine;

namespace PFS.GamePlay.Enemy.dynamicEnemy
{
    public class DynamicEnemy : EnemyBase
    {
        [SerializeField] private float _moveSpeed;

        private Rigidbody2D _rigidBody;
        private SpriteRenderer _spriteRenderer;
        private float _direction;

        private void Awake()
        {
            _hp = INIT_HP;

            _rigidBody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _direction = -1.0f;
        }

        private void Update()
        {
            Move();
        }

        public override void Attack() { }
        public override void Move()
        {
            _rigidBody.velocity = new Vector2(_direction * _moveSpeed, _rigidBody.velocity.y);
        }

        public void SwapSpriteX()
        {
            _direction = -_direction;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
