using PFS.GamePlay.Player.playerEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Player.footColllider
{
    public class FootCollider : MonoBehaviour
    {
        private PlayerEntity _playerEntity;

        private void Awake()
        {
            _playerEntity = transform.GetComponentInParent<PlayerEntity>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.CompareTag("TileMap") || collision.CompareTag("Player"))
            {
                _playerEntity.isGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("TileMap") || collision.CompareTag("Player"))
            {
                _playerEntity.isGround = false;
            }
        }
    }
}

