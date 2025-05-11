using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace CellPractice {

    public static class CellAlgorithm {

        public static void Fill(int[] cells,int value) {
            for(int i = 0; i < cells.Length; i++) {
                cells[i] = value;
            }
        }
        
    }
}