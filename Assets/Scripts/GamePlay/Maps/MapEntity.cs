using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Maps.mapEntity
{
    public class MapEntity : MonoBehaviour
    {
        [SerializeField] private List<Transform> _itemPos = new List<Transform>();
        [SerializeField] private List<Transform> _enemyPos = new List<Transform>();
        private MapGenerator _mapGenerator;
        private bool _isGenerateNextMap;

        private void Awake()
        {
            _mapGenerator = FindObjectOfType<MapGenerator>();
        }

        private void Start()
        {
            GenerateMap();
        }

        public void GenerateMap()
        {
            GenerateItem();
            GenerateEnemy();
        }

        private void GenerateItem()
        {
            foreach(var item in _itemPos)
            {
                Instantiate(_mapGenerator._itemList[Random.Range(0, _mapGenerator._itemList.Count)], item.position, Quaternion.identity);
            }
            // itemPos�� ��ȸ�ϸ� �������� ������ �������� ����
        }

        private void GenerateEnemy()
        {
            foreach (var enemy in _enemyPos)
            {
                Instantiate(_mapGenerator._enemyList[Random.Range(0, _mapGenerator._enemyList.Count)], enemy.position, Quaternion.identity);
            }
            // enemyPos�� ��ȸ�ϸ� �������� ���� �������� ����
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isGenerateNextMap && collision.CompareTag("Player") == true)
            {
                _isGenerateNextMap = true;
                _mapGenerator.GenerateMap();
            }
        }
    }
}
