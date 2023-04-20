using PFS.GamePlay.ObjectPooling.objectPool;
using PFS.GamePlay.ObjectPooling.playerPool;
using PFS.UI.Common.popupBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.UI.GameScene.gameScene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private PopupBase _pausePopup;
        [SerializeField] private PopupBase _gameOverPopup;
        private ObjectPool _playerPool;

        private void Awake()
        {
            _playerPool = GameObject.Find("PlayerPool").GetComponent<ObjectPool>();
            _playerPool.PullObject();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pausePopup.OnOpenPopup();
            }
        }

        public void OpenGameOverPopup(int msg)
        {
            _gameOverPopup.OnOpenPopup(msg);
        }
    }

}
