using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using RD = System.Random;

namespace CellPractice {


    public class Main : MonoBehaviour {

        RD rd;

        int[] cells;//产出

        public int seed = 0;
        public int width = 10;

        public int height = 20;

        Dictionary<int, Color> colorMap = new Dictionary<int, Color>(){
                {1, Color.white},
                {2, Color.red},
                {3, Color.blue},
                {4, Color.yellow},
                {5, Color.cyan},
                {6, Color.magenta},
                {7, Color.gray},
            };

        void Start() {
            rd = new RD();
            cells = new int[width * height];

            // 填充
            CellAlgorithm.Fill(cells, 1);

        }

        int fromIndex;

        void Update() {

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
