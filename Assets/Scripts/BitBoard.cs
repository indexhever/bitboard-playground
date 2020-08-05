using UnityEngine;
using System.Collections;
using System;

namespace BitPlayground
{
    public class BitBoard
    {
        private int height;
        private int width;

        public BitBoard(int rowAmount, int columnAmount)
        {
            this.height = rowAmount;
            this.width = columnAmount;
        }

        public long SetState(long bitMask, int row, int column)
        {
            int cellPosition = GetCellPositionByRowAndColumn(row, column);
            long newBit = 1L << cellPosition;
            return (bitMask |= newBit);
        }

        public bool GetCellState(long bitMask, int row, int column)
        {
            int cellPosition = GetCellPositionByRowAndColumn(row, column);
            long searchMask = 1L << cellPosition;

            return IsSearchedMaskInBitMask(searchMask, bitMask);
        }

        private bool IsSearchedMaskInBitMask(long searchMask, long bitMask)
        {
            return ((bitMask & searchMask) != 0);
        }

        private int GetCellPositionByRowAndColumn(int row, int column)
        {
            return (row * width + column);
        }

        public long ShiftLeft(long bitMask, int offset)
        {
            return bitMask >> 1;
        }
    }
}