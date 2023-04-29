using PFS.GamePlay.ObjectPooling.objectPool;
using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace PFS.GamePlay.Enemy.arrow
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float WAIT_TIME;
        private Rigidbody2D _rigidBody;
        private ObjectPool _arrowPool;
        private WaitForSeconds _sleep;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _arrowPool = GameObject.Find("ArrowPool").GetComponent<ObjectPool>();
            _sleep = new WaitForSeconds(WAIT_TIME);
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0, 0, Vector3.Angle(transform.up, _rigidBody.velocity.normalized)));
            Debug.Log(_rigidBody.velocity);
        }

        private void OnEnable()
        {
            StartCoroutine(ReturnToPool());
        }

        IEnumerator ReturnToPool()
        {
            yield return _sleep;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _arrowPool.PushObject(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Tilemap") == true || collision.transform.CompareTag("Player") == true)
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                _arrowPool.PushObject(this.gameObject);
            }
        }
    }
}
