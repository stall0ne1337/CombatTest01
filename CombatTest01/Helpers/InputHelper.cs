using CombatTest01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CombatTest01.Helpers
{
    public static class InputHelper
    {
        public static EntityOrientation GetTankMoveInput(Player player)
        {
            if (player == Player.PlayerA)
            {
                if (Keyboard.IsKeyDown(Key.A) && Keyboard.IsKeyDown(Key.W))
                {
                    return EntityOrientation.UpLeft;
                }

                if (Keyboard.IsKeyDown(Key.A) && Keyboard.IsKeyDown(Key.S))
                {
                    return EntityOrientation.DownLeft;
                }

                if (Keyboard.IsKeyDown(Key.D) && Keyboard.IsKeyDown(Key.W))
                {
                    return EntityOrientation.UpRight;
                }

                if (Keyboard.IsKeyDown(Key.D) && Keyboard.IsKeyDown(Key.S))
                {
                    return EntityOrientation.DownRight;
                }

                if (Keyboard.IsKeyDown(Key.A))
                {
                    return EntityOrientation.Left;
                }

                if (Keyboard.IsKeyDown(Key.D))
                {
                    return EntityOrientation.Right;
                }

                if (Keyboard.IsKeyDown(Key.W))
                {
                    return EntityOrientation.Up;
                }

                if (Keyboard.IsKeyDown(Key.S))
                {
                    return EntityOrientation.Down;
                }
            }

            if (player == Player.PlayerB)
            {
                if (Keyboard.IsKeyDown(Key.Left) && Keyboard.IsKeyDown(Key.Up))
                {
                    return EntityOrientation.UpLeft;
                }

                if (Keyboard.IsKeyDown(Key.Left) && Keyboard.IsKeyDown(Key.Down))
                {
                    return EntityOrientation.DownLeft;
                }

                if (Keyboard.IsKeyDown(Key.Right) && Keyboard.IsKeyDown(Key.Up))
                {
                    return EntityOrientation.UpRight;
                }

                if (Keyboard.IsKeyDown(Key.Right) && Keyboard.IsKeyDown(Key.Down))
                {
                    return EntityOrientation.DownRight;
                }

                if (Keyboard.IsKeyDown(Key.Left))
                {
                    return EntityOrientation.Left;
                }

                if (Keyboard.IsKeyDown(Key.Right))
                {
                    return EntityOrientation.Right;
                }

                if (Keyboard.IsKeyDown(Key.Up))
                {
                    return EntityOrientation.Up;
                }

                if (Keyboard.IsKeyDown(Key.Down))
                {
                    return EntityOrientation.Down;
                }
            }

            return EntityOrientation.None;
        }

        public static bool GetTankShootInput(Player player)
        {
            if (player == Player.PlayerA)
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    return true;
                }
            }

            if (player == Player.PlayerB)
            {
                if (Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
