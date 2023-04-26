using PFS.GamePlay.ObjectPooling.objectPool;
using UnityEngine;

namespace PFS.GamePlay.Item.copyItem
{
    public class CopyItem : MonoBehaviour
    {
        [SerializeField] private int _copyCount;
        private ObjectPool _objectPool;
        private bool isUsed;

        private void Awake()
        {
            _objectPool = GameObject.Find("PlayerPool").GetComponent<ObjectPool>();   
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && isUsed == false)
            {
                isUsed = true;

                for (int i = 0; i < _copyCount; ++i)
                {
                    var obj = _objectPool.PullObject();
                    obj.transform.position = this.transform.position;
                }

                gameObject.SetActive(false);
            }
        }
    }


}