using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gene.Core;

namespace Gene.CommonUI
{
    /// <summary>
    /// �������ڂ���I���ł��郊�X�g
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
        /// �I�����̍��ڂ̔z��
        /// </summary>
        [SerializeField]
        SelectItemBase[] _itemArray;

        /// <summary>
        /// �I�𒆂̍��ڂ�Index
        /// </summary>
        private int _selectedIndex = -1;

        /// <summary>
        /// ���X�g���t�H�[�J�X����Ă��邩�i�I�����ڂ�ύX���鑀�삪�ł��邩�j
        /// </summary>
        private bool _isFocused = false;

        /// <summary>
        /// ���g�ɃJ�[�\�������킹��
        /// </summary>
        public override void PlaceCursor()
        {
            _isFocused = true;
        }

        /// <summary>
        /// ���g����J�[�\�����O��
        /// </summary>
        public override void RemoveCursor()
        {
            _isFocused = false;
        }

        /// <summary>
        /// ���肷��
        /// </summary>
        public override void Decide()
        {
            if (_selectedIndex < 0 || _selectedIndex >= _itemArray.Length)
            {
                Debug.LogWarning("���݂��Ȃ����X�g���A�C�e�����I������Ă��܂�");
                return;
            }

            _itemArray[_selectedIndex].Decide();
        }

        /// <summary>
        /// �����Ŏw�肵���C���f�b�N�X�̃A�C�e����I��
        /// </summary>
        /// <param name="index">�I������A�C�e���̃C���f�b�N�X</param>
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
        /// ���̃A�C�e����I��
        /// </summary>
        public void SelectNext()
        {
            // ���ɑI������A�C�e���̃C���f�b�N�X�v�Z
            var prevIndex = _selectedIndex;
            var maxIndex = _itemArray.Length - 1;
            _selectedIndex = _selectedIndex < maxIndex ? _selectedIndex + 1 : maxIndex;
            if (prevIndex == _selectedIndex)
            {
                // �I�����ς���ĂȂ���Ή������Ȃ�
                return;
            }

            // �A�C�e���̑I��ύX
            _itemArray[prevIndex].RemoveCursor();
            _itemArray[_selectedIndex].PlaceCursor();
        }

        /// <summary>
        /// �O�̃A�C�e����I��
        /// </summary>
        public void SelectPrev()
        {
            // ���ɑI������A�C�e���̃C���f�b�N�X�v�Z
            var prevIndex = _selectedIndex;
            var minIndex = 0;
            _selectedIndex = _selectedIndex > minIndex ? _selectedIndex - 1 : minIndex;
            if (prevIndex == _selectedIndex)
            {
                // �I�����ς���ĂȂ���Ή������Ȃ�
                return;
            }


            // �A�C�e���̑I��ύX
            _itemArray[prevIndex].RemoveCursor();
            _itemArray[_selectedIndex].PlaceCursor();
        }
    }

}