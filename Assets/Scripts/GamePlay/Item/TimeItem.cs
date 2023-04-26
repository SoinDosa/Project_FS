using PFS.GamePlay.Rule.timer;
using UnityEngine;

namespace PFS.GamePlay.Item
{
    public class TimeItem : MonoBehaviour
    {
        [SerializeField] private float _addTime;
        private bool isUsed;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && isUsed == false)
            {
                isUsed = true;
                Timer.remainTime += _addTime;
                gameObject.SetActive(false);
            }
        }
    }

}