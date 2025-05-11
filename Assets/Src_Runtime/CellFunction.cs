using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace CellPractice {

    public enum Direction {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    }

    public static class CellFunction {
        public static int GetDir(Direction dir) {
            switch (dir) {
                case Direction.Up:
                    return 0;
                case Direction.Right:
                    return 1;
                case Direction.Down:
                    return 2;
                case Direction.Left:
                    return 3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }

            // or 一句话概括
            // return (int)dir;
        }

    }

}