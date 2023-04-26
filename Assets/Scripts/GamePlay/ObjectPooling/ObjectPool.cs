using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.ObjectPooling.objectPool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _object;
        private Queue<GameObject> _objectQueue = new();

        private void InstantiateObject()
        {
            var obj = Instantiate(_object);
            obj.SetActive(true);
            obj.transform.SetParent(this.transform);
            _objectQueue.Enqueue(obj);
        }

        public GameObject PullObject()
        {
            if (_objectQueue.Count <= 0)
            {
                InstantiateObject();
            }

            _objectQueue.Peek().SetActive(true);
            _objectQueue.Peek().transform.SetParent(null);

            return _objectQueue.Dequeue();
        }

        public void PushObject(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            _objectQueue.Enqueue(obj);
        }
    }
}
