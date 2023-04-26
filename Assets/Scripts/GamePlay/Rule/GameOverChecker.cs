using PFS.GamePlay.ObjectPooling.objectPool;
using UnityEngine;

namespace PFS.GamePlay.Rule.gameOverChecker
{
    public class GameOverChecker : MonoBehaviour
    {
        private ObjectPool _playerPool;
        public static bool isGameOver = false;

        private void Awake()
        {
            _playerPool = GameObject.Find("PlayerPool").GetComponent<ObjectPool>();
            var obj = _playerPool.PullObject();
            obj.transform.position = new Vector3(-11.0f, 5.0f, 0);
        }
    }
}

