using PFS.GamePlay.ObjectPooling.objectPool;
using System.Collections;
using UnityEngine;

namespace PFS.GamePlay.Enemy.arrow
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float WAIT_TIME;
        private ObjectPool _arrowPool;
        private WaitForSeconds _sleep;

        private void Awake()
        {
            _arrowPool = GameObject.Find("ArrowPool").GetComponent<ObjectPool>();
            _sleep = new WaitForSeconds(WAIT_TIME);
        }

        private void OnEnable()
        {
            StartCoroutine(ReturnToPool());
        }

        IEnumerator ReturnToPool()
        {
            yield return _sleep;
            _arrowPool.PushObject(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Tilemap") == true || collision.transform.CompareTag("Player") == true)
            {
                _arrowPool.PushObject(this.gameObject);
            }
        }
    }
}
