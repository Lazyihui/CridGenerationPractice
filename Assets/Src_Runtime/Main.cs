using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using RD = System.Random;

namespace CellPractice {

    public enum ColorMap {
        White = 1,
        Red = 2,
        Black = 3,
        Yellow = 4,
        Cyan = 5,
        Magenta = 6,
        Gray = 7,
    }

    public class Main : MonoBehaviour {

        RD rd;

        int[] cells;//产出

        public int seed = 0;
        public int width = 15;

        public int height = 20;

        Dictionary<int, Color> colorMap = new Dictionary<int, Color>(){
                {1, Color.white},
                {2, Color.red},
                {3, Color.black},
                {4, Color.yellow},
                {5, Color.cyan},
                {6, Color.magenta},
                {7, Color.gray},
            };

        void Start() {

            rd = new RD(seed);
            cells = new int[width * height];

            // 填充
            CellAlgorithm.Fill(cells, ((int)ColorMap.Black));

            // 随机数种子 找到一个点 找到一红点
            CellAlgorithm.Replace_OneCell(rd, cells, (int)ColorMap.Black, (int)ColorMap.Red);
            // CellAlgorithm.Replace_OneCell(rd, cells, (int)ColorMap.Black, (int)ColorMap.Red);


        }

        int fromIndex;

        void Update() {
            // if (Input.GetKeyDown(KeyCode.Space)) {
            //     // 随机数种子 找到一个点
            //     CellAlgorithm.WB_To_BB_Loop_Once(cells, width, height, new int[] { 1, 2 }, new int[] { 2, 2 });
            // }

            // if (Input.GetKeyDown(KeyCode.R)) {
            //     // 重新开始
            //     CellAlgorithm.Fill(cells, 1);
            //     CellAlgorithm.Replace_OneCell(rd, cells, 1, 2);
            // }

            // if (Input.GetKeyDown(KeyCode.G)) {
            //     // 直线
            //     int dir = CellFunctions.GetDir(Direction.Right);
            //     CellAlgorithm.Line_Loop_Once(cells, width, height, ref fromIndex, dir, 3);
            // }

            if (Input.GetKeyDown(KeyCode.Space)) {
                // 随机数种子 找到一个点
                CellAlgorithm.RBB_To_WWR_Once(cells, width, height, new int[] { (int)ColorMap.Red, (int)ColorMap.Black }, new int[] { (int)ColorMap.White, (int)ColorMap.Red });
            }

        }

        void OnDrawGizmos() {
            if (cells == null) {
                return;
            }

            for (int i = 0; i < cells.Length; i++) {
                // 计算坐标
                int x = i % width;
                int y = i / width;
                int value = cells[i];

                colorMap.TryGetValue(value, out Color color);
                Gizmos.color = color;

                // 画
                Vector3 size = new Vector3(1, 1, 0);
                Gizmos.DrawCube(new Vector3(x, y), size);


            }

        }
    }
}
