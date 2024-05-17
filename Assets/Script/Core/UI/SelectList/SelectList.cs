using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gene.Core;

namespace Gene.CommonUI
{
    /// <summary>
    /// 複数項目から選択できるリスト
    /// </summary>
    public class SelectList : SelectItemBase
    {
        private const float INTERVAL_TIME = .2f;

        private enum PrevInput
        {
            None, 
            Next,
            Prev,
        }

        /// <summary>
        /// 選択肢の項目の配列
        /// </summary>
        [SerializeField]
        SelectItemBase[] _itemArray;

        /// <summary>
        /// 選択中の項目のIndex
        /// </summary>
        private int _selectedIndex = -1;

        /// <summary>
        /// リストがフォーカスされているか（選択項目を変更する操作ができるか）
        /// </summary>
        private bool _isFocused = false;

        /// <summary>
        /// 自身にカーソルを合わせる
        /// </summary>
        public override void PlaceCursor()
        {
            _isFocused = true;
        }

        /// <summary>
        /// 自身からカーソルを外す
        /// </summary>
        public override void RemoveCursor()
        {
            _isFocused = false;
        }

        /// <summary>
        /// 決定する
        /// </summary>
        public override void Decide()
        {
            if (_selectedIndex < 0 || _selectedIndex >= _itemArray.Length)
            {
                Debug.LogWarning("存在しないリスト内アイテムが選択されています");
                return;
            }

            _itemArray[_selectedIndex].Decide();
        }

        /// <summary>
        /// 引数で指定したインデックスのアイテムを選ぶ
        /// </summary>
        /// <param name="index">選択するアイテムのインデックス</param>
        public void SelectItem(int index)
        {
            for (int i = 0; i < _itemArray.Length; i++)
            {
                if (i == index)
                {
                    _itemArray[i].PlaceCursor();
                }
                else
                {
                    _itemArray[i].RemoveCursor();
                }
            }

            _selectedIndex = index;
        }

        /// <summary>
        /// 次のアイテムを選ぶ
        /// </summary>
        public void SelectNext()
        {
            // 次に選択するアイテムのインデックス計算
            var prevIndex = _selectedIndex;
            var maxIndex = _itemArray.Length - 1;
            _selectedIndex = _selectedIndex < maxIndex ? _selectedIndex + 1 : maxIndex;
            if (prevIndex == _selectedIndex)
            {
                // 選択が変わってなければ何もしない
                return;
            }

            // アイテムの選択変更
            _itemArray[prevIndex].RemoveCursor();
            _itemArray[_selectedIndex].PlaceCursor();
        }

        /// <summary>
        /// 前のアイテムを選ぶ
        /// </summary>
        public void SelectPrev()
        {
            // 次に選択するアイテムのインデックス計算
            var prevIndex = _selectedIndex;
            var minIndex = 0;
            _selectedIndex = _selectedIndex > minIndex ? _selectedIndex - 1 : minIndex;
            if (prevIndex == _selectedIndex)
            {
                // 選択が変わってなければ何もしない
                return;
            }


            // アイテムの選択変更
            _itemArray[prevIndex].RemoveCursor();
            _itemArray[_selectedIndex].PlaceCursor();
        }
    }

}