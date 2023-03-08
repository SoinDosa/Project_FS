using PFS.GamePlay.ObjectPooling.playerPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Item.copyItem
{
    public class CopyItem : MonoBehaviour
    {
        [SerializeField] private int _copyCount;
        private PlayerPool _playerPool;
        private bool isUsed;

        private void OnEnable()
        {
            _playerPool = FindObjectOfType<PlayerPool>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && isUsed == false)
            {
                isUsed = true;

                for (int i = 0; i < _copyCount; ++i)
                {
                    var obj = _playerPool.GenerateObject();
                    obj.transform.position = this.transform.position;
                }

                gameObject.SetActive(false);
            }
        }
    }


}