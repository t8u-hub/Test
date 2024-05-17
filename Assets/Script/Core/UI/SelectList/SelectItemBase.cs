using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gene.CommonUI
{
    public abstract class SelectItemBase : MonoBehaviour
    {
        /// <summary>
        /// 自身にカーソルを合わせる
        /// </summary>

        public abstract void PlaceCursor();

        /// <summary>
        /// 自身からカーソルを外す
        /// </summary>
        public abstract void RemoveCursor();

        /// <summary>
        /// 決定する
        /// </summary>
        public abstract void Decide();
    }
}