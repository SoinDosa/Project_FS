using PFS.GamePlay.ObjectPooling.objectPool;
using UnityEngine;

namespace PFS.GamePlay.Rule.gameManager
{
    public class GameManager : MonoBehaviour
    {
        private ObjectPool _playerPool;
        public static bool isGameOver = false;
        public static ulong totalScore = 0;

        private void Awake()
        {
            totalScore = 0;
            _playerPool = GameObject.Find("PlayerPool").GetComponent<ObjectPool>();
            var obj = _playerPool.PullObject();
            obj.transform.position = new Vector3(-11.0f, 5.0f, 0);
        }
    }
}

