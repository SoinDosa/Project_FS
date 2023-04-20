using PFS.GamePlay.Player.playerEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.ObjectPooling.playerPool
{
    public class PlayerPool : MonoBehaviour
    {
        //[SerializeField] private GameObject _playerPrefab;
        //private Queue<GameObject> _playerList = new();

        //private void Awake()
        //{
        //    var obj = GenerateObject();
        //    obj.transform.position = new Vector3(0, 0, 0);
        //}

        //private void InstantiateNewObject()
        //{
        //    var obj = Instantiate(_playerPrefab);
        //    obj.SetActive(false);
        //    obj.transform.SetParent(this.transform);
        //    _playerList.Enqueue(obj);
        //}

        //public GameObject GenerateObject()
        //{
        //    if (_playerList.Count <= 0)
        //    {
        //        InstantiateNewObject();
        //    }

        //    _playerList.Peek().SetActive(true);
        //    _playerList.Peek().transform.SetParent(null);
        //    _playerList.Peek().GetComponent<PlayerEntity>().OnSpawned();

        //     return _playerList.Dequeue();
        //}

        //public void DestoryObject(GameObject obj)
        //{
        //    obj.SetActive(false);
        //    obj.transform.SetParent(this.transform);
        //    _playerList.Enqueue(obj);
        //}
    }
}