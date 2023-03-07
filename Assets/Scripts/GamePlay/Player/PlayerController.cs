using PFS.GamePlay.Player.playerEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Player.playerController
{
    public class PlayerController : MonoBehaviour
    {
        public List<PlayerEntity> playerEntities;

        private void Update()
        {
            EntitiesMove(Input.GetAxisRaw("Horizontal"));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                EntitiesJump();
            }
        }

        private void EntitiesMove(float power)
        {
            foreach(var entity in playerEntities)
            {
                entity.Run(power);
            }
        }

        private void EntitiesJump()
        {
            foreach (var entity in playerEntities)
            {
                entity.Jump();
            }
        }
    }
}
