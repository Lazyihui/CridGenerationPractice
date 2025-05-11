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
                Debug.Log($"index: {index}");
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

            

        }


        #endregion
    }
}