using Gene.Define;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gene.Core
{
    /// <summary>
    /// パッドからの入力を受け取るクラス
    /// </summary>
    public class GamepadInput : IInput
    {
        /// <summary>
        /// この値以上左スティックが倒されていたら、十字キーと同等の入力があったとみなす
        /// </summary>
        private const float STICK_AS_ARROW_THRESHOLD = .8f;

        /// <summary>
        /// 十字キー（左スティック）が押されているかを取得する
        /// </summary>
        /// <param name="buttonAxis">入力があったかチェックする方向</param>
        /// <returns>入力があるならtrue</returns>
        public bool GetArrowKeyInput(ArrowKeyAxis buttonAxis)
        {
            var pad = Gamepad.current;
            if (pad == null)
            {
                return false;
            }

            var inputVec = pad.leftStick.ReadValue();
            switch (buttonAxis)
            {
                case ArrowKeyAxis.Left:
                    if (inputVec.x > STICK_AS_ARROW_THRESHOLD)
                    {
                        return true;
                    }
                    break;
                case ArrowKeyAxis.Right:
                    if (inputVec.x < -STICK_AS_ARROW_THRESHOLD)
                    {
                        return true;
                    }
                    break;
                case ArrowKeyAxis.Up:
                    if (inputVec.y > STICK_AS_ARROW_THRESHOLD)
                    {
                        return true;
                    }
                    break;
                case ArrowKeyAxis.Down:
                    if (inputVec.y < -STICK_AS_ARROW_THRESHOLD)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        /// 決定ボタンが押下されたか
        /// </summary>
        /// <returns>押されたならTrue</returns>
        public bool GetDecideKeyDown()
        {
            var pad = Gamepad.current;
            if (pad == null)
            {
                return false;
            }

            return pad.buttonEast.wasPressedThisFrame;
        }

        /// <summary>
        /// 決定ボタンが押下されたか
        /// </summary>
        /// <returns>押されたならTrue</returns>
        public bool GetCancelKeyDown()
        {
            var pad = Gamepad.current;
            if (pad == null)
            {
                return false;
            }

            return pad.buttonSouth.wasPressedThisFrame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMoveVector()
        {
            var pad = Gamepad.current;
            if (pad == null)
            {
                return Vector2.zero;
            }

            return pad.leftStick.ReadValue();
        }
    }
}