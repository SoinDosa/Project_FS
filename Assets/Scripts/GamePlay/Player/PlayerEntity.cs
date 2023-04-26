using Cinemachine;
using PFS.GamePlay.Enemy.enemyBase;
using PFS.GamePlay.ObjectPooling.objectPool;
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

        private CinemachineTargetGroup _cinemachineTargetGroup;
        private PlayerController _playerController;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _footCollider;
        private ObjectPool _objectPool;
        [SerializeField] private GameObject _parentObject;
        public bool isRemoved;
        public bool isGround;

        private void Awake()
        {
            _cinemachineTargetGroup = FindObjectOfType<CinemachineTargetGroup>();
            _playerController = FindObjectOfType<PlayerController>();
            _objectPool = GameObject.Find("PlayerPool").GetComponent<ObjectPool>();
        }

        public void OnEnable()
        {
            isRemoved = false;
            _cinemachineTargetGroup.AddMember(this.transform, 1.0f, 5.0f);
            _playerController.playerEntities.Add(this);
            _playerController.MoveEntities += Run;
            _playerController.JumpEntities += Jump;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            //_playerPool = FindObjectOfType<PlayerPool>();
            Debug.Log("OnEnble Player!");
        }

        public void OnDisable()
        {
            _cinemachineTargetGroup.RemoveMember(this.transform);
            _playerController.MoveEntities -= Run;
            _playerController.JumpEntities -= Jump;
            isRemoved = true;
            _playerController.playerEntities.Remove(this);
            Debug.Log("OnDisable Player!");
        }

        //public void OnSpawned()
        //{
        //    isRemoved = false;
        //    _cinemachineTargetGroup.AddMember(this.transform, 1.0f, 5.0f);
        //    _playerController.playerEntities.Add(this);
        //    _playerController.MoveEntities += Run;
        //    _playerController.JumpEntities += Jump;
        //    _rigidbody2D = GetComponent<Rigidbody2D>();
        //    //_playerPool = FindObjectOfType<PlayerPool>();
        //}

        //public void OnRemoved()
        //{
        //    _cinemachineTargetGroup.RemoveMember(this.transform);
        //    _playerController.MoveEntities -= Run;
        //    _playerController.JumpEntities -= Jump;
        //    isRemoved = true;
        //    _playerController.playerEntities.Remove(this);
        //}

        public void Run(float dir)
        {
            _rigidbody2D.velocity = new Vector2(dir * _playerSpeed * Time.deltaTime, _rigidbody2D.velocity.y);
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
            if (collision.CompareTag("DestroyZone") && isRemoved == false)
            {
                //OnRemoved();
                //_playerPool.DestoryObject(this.gameObject);
                _objectPool.PushObject(this.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && isRemoved == false)
            {
                collision.gameObject.GetComponent<EnemyBase>().OnDamaged();
                //OnRemoved();
                //_playerPool.DestoryObject(this.gameObject);
                _objectPool.PushObject(this.gameObject);
            }

            if (collision.gameObject.CompareTag("Arrow") && isRemoved == false)
            {
                _objectPool.PushObject(this.gameObject);
            }
        }
    }

}
