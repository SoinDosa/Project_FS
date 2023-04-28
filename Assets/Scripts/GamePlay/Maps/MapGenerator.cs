using PFS.GamePlay.Maps.mapEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Maps
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _mapsContainer = new List<GameObject>();
        [SerializeField] private float _gapBetweenMaps;
        public List<GameObject> _itemList = new List<GameObject>();
        public List<GameObject> _enemyList = new List<GameObject>();
        private List<GameObject> _genertatedMaps = new List<GameObject>();

        private void Awake()
        {
            _genertatedMaps.Add(GameObject.Find("InitialMap"));
        }

        public void GenerateMap()
        {
            var obj = Instantiate(_mapsContainer[Random.Range(0, _mapsContainer.Count)], new Vector3(_gapBetweenMaps * _genertatedMaps.Count, 0, 0), Quaternion.identity);
            _genertatedMaps.Add(obj);
        }
    }
}

