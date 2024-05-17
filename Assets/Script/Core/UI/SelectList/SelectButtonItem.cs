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
        /// <summary>ボタンに表示されているテキスト</summary>
        [SerializeField]
        private TextMeshProUGUI _text;

        private Action _onDecide;

        /// <summary>
        /// 自身にカーソルを合わせる
        /// </summary>
        public override void PlaceCursor()
        {
            _text.color = GameDefine.SELECTED_COLOR;
        }

        /// <summary>
        /// 自身からカーソルを外す
        /// </summary>
        public override void RemoveCursor()
        {
            _text.color = GameDefine.DEFAULT_COLOR;
        }

        /// <summary>
        /// 決定する
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