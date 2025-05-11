using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using RD = System.Random;

namespace CellPractice {

    public static class CellAlgorithm {

        public static void Fill(int[] cells, int value) {
            for (int i = 0; i < cells.Length; i++) {
                cells[i] = value;
            }
        }

        // 找到一个点
        public static void Replace_OneCell(RD random, int[] cells, int fromValue, int toValue) {
            int failedTimes = cells.Length;

            int index;

            do {
                index = random.Next(0, cells.Length);//从数组中取一个随机的index
                if (cells[index] == fromValue) {
                    cells[index] = toValue;
                    break;
                } else {
                    failedTimes--;
                }

            } while (failedTimes > 0);
        }
        #region 白黑=>黑黑
        public static void WB_To_BB_Loop_Once(int[] cells, int width, int height, int[] fromValue, int[] toValue) {

            Span<int> direction = stackalloc int[4] {
               -width, // down
                width,//up 
                -1,//left 
                 1,//right
            };

            bool isSuccess = false;

            for (int currentIndex = 0; currentIndex < cells.Length; currentIndex++) {
                int currentValue = cells[currentIndex];

                if (currentValue != fromValue[0]) {
                    // 不是白色
                    continue;
                }

                int nextIndex;
                int nextValue;

                // 运算
                for (int j = 0; j < direction.Length; j++) {
                    int dirOffset = direction[j];
                    nextIndex = currentIndex + dirOffset;
                    nextIndex = Math.Clamp(nextIndex, 0, cells.Length - 1);
                    nextValue = cells[nextIndex];
                    if (nextValue != fromValue[1]) {
                        // 不是黑色
                        continue;
                    }

                    // 是黑色
                    cells[currentIndex] = toValue[0];
                    cells[nextIndex] = toValue[1];
                    isSuccess = true;
                    break;

                }

                if (isSuccess) {
                    break;
                }


            }

        }

        public static void WB_To_BB_Loop_ToEnd(int[] cells, int width, int height, int[] fromValue, int[] toValue, int count) {
            // 循环
            for (int i = 0; i < count; i++) {
                WB_To_BB_Loop_Once(cells, width, height, fromValue, toValue);
            }
        }

        #endregion

        #region Line
        // 记录状态: 上次的点, 移动方向
        public static void Line_Loop_Once(int[] cells, int width, int height, ref int fromIndex, int dir, int toValue) {
            // fromIndex: 上次最后的点
            // dir: 上次的移动方向

            Span<int> directions = stackalloc int[4] {
                width,  // up
                1,      // right
                -width, // down
                -1,     // left
            }; // 上下左右

            int nextIndex = fromIndex + directions[dir];
            // BUG: 确保直线
            nextIndex = Math.Clamp(nextIndex, 0, cells.Length - 1); // 上下左右
            cells[nextIndex] = toValue;

            fromIndex = nextIndex; // 记录上次的点
        }

        public static void Line_Loop_ToEnd(int[] cells, int width, int height, ref int fromIndex, int dir, int toValue, int count) {
            // 3. 循环
            for (int i = 0; i < count; i++) {
                Line_Loop_Once(cells, width, height, ref fromIndex, dir, toValue);
            }
        }
        #endregion
    }
}