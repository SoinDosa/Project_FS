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
        public Action<float> MoveEntities;
        public Action JumpEntities;

        public void PlayerMove(float dir)
        {
            if(MoveEntities != null)
            {
                MoveEntities(dir);
            }
        }

        public void JumpPlayer()
        {
            if (JumpEntities != null)
            {
                JumpEntities();
            }
        }
    }
}
