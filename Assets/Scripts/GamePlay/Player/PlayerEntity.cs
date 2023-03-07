using PFS.GamePlay.Player.playerController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Player.playerEntity
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _jumpPower;
        private PlayerController _playerController;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _footCollider;
        public bool isGround;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _playerController.playerEntities.Add(this);

            _rigidbody2D = GetComponent<Rigidbody2D>();

        }

        private void OnDisable()
        {
            _playerController.playerEntities.Remove(this);
        }

        public void Run(float power)
        {
            _rigidbody2D.velocity = new Vector2(power * _playerSpeed * Time.deltaTime, _rigidbody2D.velocity.y);
        }

        public void Jump()
        {
            if(isGround)
            {
                _rigidbody2D.AddForce(new Vector2(0, _jumpPower));
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("DestroyZone"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}
