using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zehreken.i_cheat
{
    public static class GridSquareUtils
    {
        static GridSquareUtils()
        {
            
        }

        public static int[,] CreateGrid(int rowCount, int columnCount)
        {
            return new int[rowCount, columnCount];
        }
    }
}