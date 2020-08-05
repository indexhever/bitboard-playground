using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BitPlayground;

namespace Tests
{
    public class BitboardOperationsTests
    {
        [Test]
        public void SetStateAtARowAndColumn()
        {
            int rowAmount = 2;
            int columnAmount = 2;
            BitBoard bitboard = CreateBitBoard(rowAmount, columnAmount);
            long bitMask = 0;
            int row = 0;
            int column = 1;
            long expectedBitMask = 1L << (row * columnAmount + column);

            bitMask = bitboard.SetState(bitMask, row, column);

            Assert.AreEqual(expectedBitMask, bitMask);
        }

        [Test]
        public void GetCellState()
        {
            int rowAmount = 2;
            int columnAmount = 2;
            BitBoard bitboard = CreateBitBoard(rowAmount, columnAmount);
            long bitMask = 1L << 1;
            int row = 0;
            int column = 1;

            bool hasValueBitValueOfOneInSearchedPosition = bitboard.GetCellState(bitMask, row, column);

            Assert.IsTrue(hasValueBitValueOfOneInSearchedPosition);
        }

        [Test]
        public void ShiftLeft()
        {
            int rowAmount = 3;
            int columnAmount = 3;
            BitBoard bitboard = CreateBitBoard(rowAmount, columnAmount);
            long bitMask = 0;
            bitMask = bitboard.SetState(bitMask, 0, 0);
            bitMask = bitboard.SetState(bitMask, 0, 1);
            bitMask = bitboard.SetState(bitMask, 1, 1);
            bitMask = bitboard.SetState(bitMask, 1, 2);
            string bitMaskString = Convert.ToString(bitMask, 2).PadLeft(9, '0');

            long shiftedBitMask = bitboard.ShiftLeft(bitMask, 1);
            string shiftedBitMaskString = Convert.ToString(shiftedBitMask, 2).PadLeft(9, '0');

            Debug.Log(shiftedBitMaskString);

            Assert.AreEqual("000110011", bitMaskString);
            Assert.AreEqual("000011001", shiftedBitMaskString);
        }

        private BitBoard CreateBitBoard(int rowAmount, int columnAmount)
        {
            return new BitBoard(rowAmount, columnAmount);
        }
    }
}
