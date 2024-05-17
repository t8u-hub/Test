using Gene.Define;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gene.CommonUI
{
    public class SelectButtonItem : SelectItemBase
    {
        /// <summary>�{�^���ɕ\������Ă���e�L�X�g</summary>
        [SerializeField]
        private TextMeshProUGUI _text;

        private Action _onDecide;

        /// <summary>
        /// ���g�ɃJ�[�\�������킹��
        /// </summary>
        public override void PlaceCursor()
        {
            _text.color = GameDefine.SELECTED_COLOR;
        }

        /// <summary>
        /// ���g����J�[�\�����O��
        /// </summary>
        public override void RemoveCursor()
        {
            _text.color = GameDefine.DEFAULT_COLOR;
        }

        /// <summary>
        /// ���肷��
        /// </summary>
        public override void Decide()
        {
            _onDecide?.Invoke();
        }

        public void SetOnDecide(Action onDecide)
        {
            _onDecide = onDecide;
        }
    }
}