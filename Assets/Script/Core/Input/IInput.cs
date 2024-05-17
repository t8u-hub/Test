using Gene.Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gene.Core
{
    /// <summary>
    /// 入力のインターフェース
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// 十字キー（左スティック）が押されているかを取得する
        /// </summary>
        /// <param name="buttonAxis">入力があったかチェックする方向</param>
        /// <returns>入力があるならtrue</returns>
        public bool GetArrowKeyInput(ArrowKeyAxis buttonAxis);


    }
}