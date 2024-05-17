using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gene.CommonUI
{
    public abstract class SelectItemBase : MonoBehaviour
    {
        /// <summary>
        /// ���g�ɃJ�[�\�������킹��
        /// </summary>

        public abstract void PlaceCursor();

        /// <summary>
        /// ���g����J�[�\�����O��
        /// </summary>
        public abstract void RemoveCursor();

        /// <summary>
        /// ���肷��
        /// </summary>
        public abstract void Decide();
    }
}