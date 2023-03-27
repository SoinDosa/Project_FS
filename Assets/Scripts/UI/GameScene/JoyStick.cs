using PFS.GamePlay.Player.playerController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PFS.UI.GameScene.joyStick
{
    public class JoyStick : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private float LEVER_RANGE;
        private PlayerController _playerController;
        private RectTransform _rectTransform;
        private RectTransform _lever;
        private Vector2 _initialPos;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _rectTransform = GetComponent<RectTransform>();
            _lever = transform.GetChild(0).GetComponent<RectTransform>();
            _initialPos = _rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos = Vector2.ClampMagnitude(eventData.position - _rectTransform.anchoredPosition, LEVER_RANGE);
            float dir = pos.x < 0 ? -1.0f : 1.0f;

            _lever.anchoredPosition = pos;
            _playerController.MoveEntities(dir);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _lever.anchoredPosition = Vector2.zero;
            _playerController.MoveEntities(0.0f);
        }
    }
}

