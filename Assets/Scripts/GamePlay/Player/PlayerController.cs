using PFS.GamePlay.Player.playerEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace PFS.GamePlay.Player.playerController
{
    public class PlayerController : MonoBehaviour
    {
        public List<PlayerEntity> playerEntities;
        public Action MoveEntities;
        public Action JumpEntities;

        private void Update()
        {
            MoveEntities();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpEntities();
            }
        }
    }
}
