using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using NUnit.Framework;

namespace AdventOfCode
{
    public class Aoc2015
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day_2_a()
        {
            List<Tuple<int, int, int>> presentData = new();
            presentData.Add(Tuple.Create(3, 11, 24));
            presentData.Add(Tuple.Create(13, 5, 19));
            presentData.Add(Tuple.Create(1, 9, 27));
            presentData.Add(Tuple.Create(24, 8, 21));
            presentData.Add(Tuple.Create(6, 8, 17));
            presentData.Add(Tuple.Create(19, 18, 22));
            presentData.Add(Tuple.Create(10, 9, 12));
            presentData.Add(Tuple.Create(12, 2, 5));
            presentData.Add(Tuple.Create(26, 6, 11));
            presentData.Add(Tuple.Create(9, 23, 15));
            presentData.Add(Tuple.Create(12, 8, 17));
            presentData.Add(Tuple.Create(13, 29, 10));
            presentData.Add(Tuple.Create(28, 18, 6));
            presentData.Add(Tuple.Create(22, 28, 26));
            presentData.Add(Tuple.Create(1, 5, 11));
            presentData.Add(Tuple.Create(29, 26, 12));
            presentData.Add(Tuple.Create(8, 28, 29));
            presentData.Add(Tuple.Create(27, 4, 21));
            presentData.Add(Tuple.Create(12, 7, 16));
            presentData.Add(Tuple.Create(7, 4, 23));
            presentData.Add(Tuple.Create(15, 24, 8));
            presentData.Add(Tuple.Create(15, 14, 2));
            presentData.Add(Tuple.Create(11, 6, 29));
            presentData.Add(Tuple.Create(28, 19, 9));
            presentData.Add(Tuple.Create(10, 3, 1));
            presentData.Add(Tuple.Create(5, 20, 13));
            presentData.Add(Tuple.Create(10, 25, 1));
            presentData.Add(Tuple.Create(22, 17, 7));
            presentData.Add(Tuple.Create(16, 29, 3));
            presentData.Add(Tuple.Create(18, 22, 8));
            presentData.Add(Tuple.Create(18, 11, 19));
            presentData.Add(Tuple.Create(21, 24, 20));
            presentData.Add(Tuple.Create(4, 7, 17));
            presentData.Add(Tuple.Create(22, 27, 12));
            presentData.Add(Tuple.Create(1, 26, 6));
            presentData.Add(Tuple.Create(5, 27, 24));
            presentData.Add(Tuple.Create(29, 21, 3));
            presentData.Add(Tuple.Create(25, 30, 2));
            presentData.Add(Tuple.Create(21, 26, 2));
            presentData.Add(Tuple.Create(10, 24, 27));
            presentData.Add(Tuple.Create(10, 16, 28));
            presentData.Add(Tuple.Create(18, 16, 23));
            presentData.Add(Tuple.Create(6, 5, 26));
            presentData.Add(Tuple.Create(19, 12, 20));
            presentData.Add(Tuple.Create(6, 24, 25));
            presentData.Add(Tuple.Create(11, 20, 7));
            presentData.Add(Tuple.Create(4, 8, 5));
            presentData.Add(Tuple.Create(2, 13, 11));
            presentData.Add(Tuple.Create(11, 17, 1));
            presentData.Add(Tuple.Create(13, 24, 6));
            presentData.Add(Tuple.Create(22, 29, 16));
            presentData.Add(Tuple.Create(4, 24, 20));
            presentData.Add(Tuple.Create(10, 25, 10));
            presentData.Add(Tuple.Create(12, 29, 23));
            presentData.Add(Tuple.Create(23, 27, 12));
            presentData.Add(Tuple.Create(11, 21, 9));
            presentData.Add(Tuple.Create(13, 2, 6));
            presentData.Add(Tuple.Create(15, 30, 2));
            presentData.Add(Tuple.Create(8, 26, 24));
            presentData.Add(Tuple.Create(24, 7, 30));
            presentData.Add(Tuple.Create(22, 22, 8));
            presentData.Add(Tuple.Create(29, 27, 8));
            presentData.Add(Tuple.Create(28, 23, 27));
            presentData.Add(Tuple.Create(13, 16, 14));
            presentData.Add(Tuple.Create(9, 28, 20));
            presentData.Add(Tuple.Create(21, 4, 30));
            presentData.Add(Tuple.Create(21, 20, 20));
            presentData.Add(Tuple.Create(11, 17, 30));
            presentData.Add(Tuple.Create(9, 14, 22));
            presentData.Add(Tuple.Create(20, 2, 6));
            presentData.Add(Tuple.Create(10, 11, 14));
            presentData.Add(Tuple.Create(1, 8, 23));
            presentData.Add(Tuple.Create(23, 19, 19));
            presentData.Add(Tuple.Create(26, 10, 13));
            presentData.Add(Tuple.Create(21, 12, 12));
            presentData.Add(Tuple.Create(25, 7, 24));
            presentData.Add(Tuple.Create(1, 28, 17));
            presentData.Add(Tuple.Create(20, 23, 9));
            presentData.Add(Tuple.Create(2, 24, 27));
            presentData.Add(Tuple.Create(20, 24, 29));
            presentData.Add(Tuple.Create(1, 3, 10));
            presentData.Add(Tuple.Create(5, 20, 14));
            presentData.Add(Tuple.Create(25, 21, 3));
            presentData.Add(Tuple.Create(15, 5, 22));
            presentData.Add(Tuple.Create(14, 17, 19));
            presentData.Add(Tuple.Create(27, 3, 18));
            presentData.Add(Tuple.Create(29, 23, 19));
            presentData.Add(Tuple.Create(14, 21, 19));
            presentData.Add(Tuple.Create(20, 8, 3));
            presentData.Add(Tuple.Create(22, 27, 12));
            presentData.Add(Tuple.Create(24, 15, 18));
            presentData.Add(Tuple.Create(9, 10, 19));
            presentData.Add(Tuple.Create(29, 25, 28));
            presentData.Add(Tuple.Create(14, 22, 6));
            presentData.Add(Tuple.Create(4, 19, 28));
            presentData.Add(Tuple.Create(4, 24, 14));
            presentData.Add(Tuple.Create(17, 19, 17));
            presentData.Add(Tuple.Create(7, 19, 29));
            presentData.Add(Tuple.Create(28, 8, 26));
            presentData.Add(Tuple.Create(7, 20, 16));
            presentData.Add(Tuple.Create(11, 26, 29));
            presentData.Add(Tuple.Create(2, 18, 3));
            presentData.Add(Tuple.Create(12, 7, 18));
            presentData.Add(Tuple.Create(11, 15, 21));
            presentData.Add(Tuple.Create(24, 7, 26));
            presentData.Add(Tuple.Create(2, 22, 23));
            presentData.Add(Tuple.Create(2, 30, 5));
            presentData.Add(Tuple.Create(1, 19, 8));
            presentData.Add(Tuple.Create(15, 29, 10));
            presentData.Add(Tuple.Create(15, 26, 22));
            presentData.Add(Tuple.Create(20, 16, 14));
            presentData.Add(Tuple.Create(25, 29, 22));
            presentData.Add(Tuple.Create(3, 13, 19));
            presentData.Add(Tuple.Create(1, 12, 30));
            presentData.Add(Tuple.Create(3, 15, 27));
            presentData.Add(Tuple.Create(19, 9, 11));
            presentData.Add(Tuple.Create(30, 8, 21));
            presentData.Add(Tuple.Create(26, 12, 20));
            presentData.Add(Tuple.Create(11, 17, 19));
            presentData.Add(Tuple.Create(17, 25, 1));
            presentData.Add(Tuple.Create(19, 24, 12));
            presentData.Add(Tuple.Create(30, 6, 20));
            presentData.Add(Tuple.Create(11, 19, 18));
            presentData.Add(Tuple.Create(18, 15, 29));
            presentData.Add(Tuple.Create(18, 8, 9));
            presentData.Add(Tuple.Create(25, 15, 5));
            presentData.Add(Tuple.Create(15, 6, 26));
            presentData.Add(Tuple.Create(13, 27, 19));
            presentData.Add(Tuple.Create(23, 24, 12));
            presentData.Add(Tuple.Create(3, 15, 28));
            presentData.Add(Tuple.Create(17, 10, 10));
            presentData.Add(Tuple.Create(15, 4, 7));
            presentData.Add(Tuple.Create(15, 27, 7));
            presentData.Add(Tuple.Create(21, 8, 11));
            presentData.Add(Tuple.Create(9, 18, 2));
            presentData.Add(Tuple.Create(7, 20, 20));
            presentData.Add(Tuple.Create(17, 23, 12));
            presentData.Add(Tuple.Create(2, 19, 1));
            presentData.Add(Tuple.Create(7, 26, 26));
            presentData.Add(Tuple.Create(13, 23, 8));
            presentData.Add(Tuple.Create(10, 3, 12));
            presentData.Add(Tuple.Create(11, 1, 9));
            presentData.Add(Tuple.Create(1, 11, 19));
            presentData.Add(Tuple.Create(25, 14, 26));
            presentData.Add(Tuple.Create(16, 10, 15));
            presentData.Add(Tuple.Create(7, 6, 11));
            presentData.Add(Tuple.Create(8, 1, 27));
            presentData.Add(Tuple.Create(20, 28, 17));
            presentData.Add(Tuple.Create(3, 25, 9));
            presentData.Add(Tuple.Create(30, 7, 5));
            presentData.Add(Tuple.Create(17, 17, 4));
            presentData.Add(Tuple.Create(23, 25, 27));
            presentData.Add(Tuple.Create(23, 8, 5));
            presentData.Add(Tuple.Create(13, 11, 1));
            presentData.Add(Tuple.Create(15, 10, 21));
            presentData.Add(Tuple.Create(22, 16, 1));
            presentData.Add(Tuple.Create(12, 15, 28));
            presentData.Add(Tuple.Create(27, 18, 26));
            presentData.Add(Tuple.Create(25, 18, 5));
            presentData.Add(Tuple.Create(21, 3, 27));
            presentData.Add(Tuple.Create(15, 25, 5));
            presentData.Add(Tuple.Create(29, 27, 19));
            presentData.Add(Tuple.Create(11, 10, 12));
            presentData.Add(Tuple.Create(22, 16, 21));
            presentData.Add(Tuple.Create(11, 8, 18));
            presentData.Add(Tuple.Create(6, 10, 23));
            presentData.Add(Tuple.Create(21, 21, 2));
            presentData.Add(Tuple.Create(13, 27, 28));
            presentData.Add(Tuple.Create(2, 5, 20));
            presentData.Add(Tuple.Create(23, 16, 20));
            presentData.Add(Tuple.Create(1, 21, 7));
            presentData.Add(Tuple.Create(22, 2, 13));
            presentData.Add(Tuple.Create(11, 10, 4));
            presentData.Add(Tuple.Create(7, 3, 4));
            presentData.Add(Tuple.Create(19, 2, 5));
            presentData.Add(Tuple.Create(21, 11, 1));
            presentData.Add(Tuple.Create(7, 27, 26));
            presentData.Add(Tuple.Create(12, 4, 23));
            presentData.Add(Tuple.Create(12, 3, 15));
            presentData.Add(Tuple.Create(25, 7, 4));
            presentData.Add(Tuple.Create(20, 7, 15));
            presentData.Add(Tuple.Create(16, 5, 11));
            presentData.Add(Tuple.Create(1, 18, 26));
            presentData.Add(Tuple.Create(11, 27, 10));
            presentData.Add(Tuple.Create(17, 6, 24));
            presentData.Add(Tuple.Create(19, 13, 16));
            presentData.Add(Tuple.Create(6, 3, 11));
            presentData.Add(Tuple.Create(4, 19, 18));
            presentData.Add(Tuple.Create(16, 15, 15));
            presentData.Add(Tuple.Create(1, 11, 17));
            presentData.Add(Tuple.Create(19, 11, 29));
            presentData.Add(Tuple.Create(18, 19, 1));
            presentData.Add(Tuple.Create(1, 25, 7));
            presentData.Add(Tuple.Create(8, 22, 14));
            presentData.Add(Tuple.Create(15, 6, 19));
            presentData.Add(Tuple.Create(5, 30, 18));
            presentData.Add(Tuple.Create(30, 24, 22));
            presentData.Add(Tuple.Create(11, 16, 2));
            presentData.Add(Tuple.Create(21, 29, 19));
            presentData.Add(Tuple.Create(20, 29, 11));
            presentData.Add(Tuple.Create(27, 1, 18));
            presentData.Add(Tuple.Create(20, 5, 30));
            presentData.Add(Tuple.Create(12, 4, 28));
            presentData.Add(Tuple.Create(3, 9, 30));
            presentData.Add(Tuple.Create(26, 20, 15));
            presentData.Add(Tuple.Create(18, 25, 18));
            presentData.Add(Tuple.Create(20, 28, 28));
            presentData.Add(Tuple.Create(21, 5, 3));
            presentData.Add(Tuple.Create(20, 21, 25));
            presentData.Add(Tuple.Create(19, 27, 22));
            presentData.Add(Tuple.Create(8, 27, 9));
            presentData.Add(Tuple.Create(1, 5, 15));
            presentData.Add(Tuple.Create(30, 6, 19));
            presentData.Add(Tuple.Create(16, 5, 15));
            presentData.Add(Tuple.Create(18, 30, 21));
            presentData.Add(Tuple.Create(4, 15, 8));
            presentData.Add(Tuple.Create(9, 3, 28));
            presentData.Add(Tuple.Create(18, 15, 27));
            presentData.Add(Tuple.Create(25, 11, 6));
            presentData.Add(Tuple.Create(17, 22, 15));
            presentData.Add(Tuple.Create(18, 12, 18));
            presentData.Add(Tuple.Create(14, 30, 30));
            presentData.Add(Tuple.Create(1, 7, 23));
            presentData.Add(Tuple.Create(27, 21, 12));
            presentData.Add(Tuple.Create(15, 7, 18));
            presentData.Add(Tuple.Create(16, 17, 24));
            presentData.Add(Tuple.Create(11, 12, 19));
            presentData.Add(Tuple.Create(18, 15, 21));
            presentData.Add(Tuple.Create(6, 18, 15));
            presentData.Add(Tuple.Create(2, 21, 4));
            presentData.Add(Tuple.Create(12, 9, 14));
            presentData.Add(Tuple.Create(19, 7, 25));
            presentData.Add(Tuple.Create(22, 3, 1));
            presentData.Add(Tuple.Create(29, 19, 7));
            presentData.Add(Tuple.Create(30, 25, 7));
            presentData.Add(Tuple.Create(6, 27, 27));
            presentData.Add(Tuple.Create(5, 13, 9));
            presentData.Add(Tuple.Create(21, 4, 18));
            presentData.Add(Tuple.Create(13, 1, 16));
            presentData.Add(Tuple.Create(11, 21, 25));
            presentData.Add(Tuple.Create(27, 20, 27));
            presentData.Add(Tuple.Create(14, 25, 9));
            presentData.Add(Tuple.Create(23, 11, 15));
            presentData.Add(Tuple.Create(22, 10, 26));
            presentData.Add(Tuple.Create(15, 16, 4));
            presentData.Add(Tuple.Create(14, 16, 21));
            presentData.Add(Tuple.Create(1, 1, 24));
            presentData.Add(Tuple.Create(17, 27, 3));
            presentData.Add(Tuple.Create(25, 28, 16));
            presentData.Add(Tuple.Create(12, 2, 29));
            presentData.Add(Tuple.Create(9, 19, 28));
            presentData.Add(Tuple.Create(12, 7, 17));
            presentData.Add(Tuple.Create(6, 9, 19));
            presentData.Add(Tuple.Create(15, 14, 24));
            presentData.Add(Tuple.Create(25, 21, 23));
            presentData.Add(Tuple.Create(26, 27, 25));
            presentData.Add(Tuple.Create(7, 18, 13));
            presentData.Add(Tuple.Create(15, 10, 6));
            presentData.Add(Tuple.Create(22, 28, 2));
            presentData.Add(Tuple.Create(15, 2, 14));
            presentData.Add(Tuple.Create(3, 24, 18));
            presentData.Add(Tuple.Create(30, 22, 7));
            presentData.Add(Tuple.Create(18, 27, 17));
            presentData.Add(Tuple.Create(29, 18, 7));
            presentData.Add(Tuple.Create(20, 2, 4));
            presentData.Add(Tuple.Create(4, 20, 26));
            presentData.Add(Tuple.Create(23, 30, 15));
            presentData.Add(Tuple.Create(5, 7, 3));
            presentData.Add(Tuple.Create(4, 24, 12));
            presentData.Add(Tuple.Create(24, 30, 20));
            presentData.Add(Tuple.Create(26, 18, 17));
            presentData.Add(Tuple.Create(6, 28, 3));
            presentData.Add(Tuple.Create(29, 19, 29));
            presentData.Add(Tuple.Create(14, 10, 4));
            presentData.Add(Tuple.Create(15, 5, 23));
            presentData.Add(Tuple.Create(12, 25, 4));
            presentData.Add(Tuple.Create(7, 15, 19));
            presentData.Add(Tuple.Create(26, 21, 19));
            presentData.Add(Tuple.Create(18, 2, 23));
            presentData.Add(Tuple.Create(19, 20, 3));
            presentData.Add(Tuple.Create(3, 13, 9));
            presentData.Add(Tuple.Create(29, 21, 24));
            presentData.Add(Tuple.Create(26, 13, 29));
            presentData.Add(Tuple.Create(30, 27, 4));
            presentData.Add(Tuple.Create(20, 10, 29));
            presentData.Add(Tuple.Create(21, 18, 8));
            presentData.Add(Tuple.Create(7, 26, 10));
            presentData.Add(Tuple.Create(29, 16, 21));
            presentData.Add(Tuple.Create(22, 5, 11));
            presentData.Add(Tuple.Create(17, 15, 2));
            presentData.Add(Tuple.Create(7, 29, 5));
            presentData.Add(Tuple.Create(6, 18, 15));
            presentData.Add(Tuple.Create(23, 6, 14));
            presentData.Add(Tuple.Create(10, 30, 14));
            presentData.Add(Tuple.Create(26, 6, 16));
            presentData.Add(Tuple.Create(24, 13, 25));
            presentData.Add(Tuple.Create(17, 29, 20));
            presentData.Add(Tuple.Create(4, 27, 19));
            presentData.Add(Tuple.Create(28, 12, 11));
            presentData.Add(Tuple.Create(23, 20, 3));
            presentData.Add(Tuple.Create(22, 6, 20));
            presentData.Add(Tuple.Create(29, 9, 19));
            presentData.Add(Tuple.Create(10, 16, 22));
            presentData.Add(Tuple.Create(30, 26, 4));
            presentData.Add(Tuple.Create(29, 26, 11));
            presentData.Add(Tuple.Create(2, 11, 15));
            presentData.Add(Tuple.Create(1, 3, 30));
            presentData.Add(Tuple.Create(30, 30, 29));
            presentData.Add(Tuple.Create(9, 1, 3));
            presentData.Add(Tuple.Create(30, 13, 16));
            presentData.Add(Tuple.Create(20, 4, 5));
            presentData.Add(Tuple.Create(23, 28, 11));
            presentData.Add(Tuple.Create(24, 27, 1));
            presentData.Add(Tuple.Create(4, 25, 10));
            presentData.Add(Tuple.Create(9, 3, 6));
            presentData.Add(Tuple.Create(14, 4, 15));
            presentData.Add(Tuple.Create(4, 5, 25));
            presentData.Add(Tuple.Create(27, 14, 13));
            presentData.Add(Tuple.Create(20, 30, 3));
            presentData.Add(Tuple.Create(28, 15, 25));
            presentData.Add(Tuple.Create(5, 19, 2));
            presentData.Add(Tuple.Create(10, 24, 29));
            presentData.Add(Tuple.Create(29, 30, 18));
            presentData.Add(Tuple.Create(30, 1, 25));
            presentData.Add(Tuple.Create(7, 7, 15));
            presentData.Add(Tuple.Create(1, 13, 16));
            presentData.Add(Tuple.Create(23, 18, 4));
            presentData.Add(Tuple.Create(1, 28, 8));
            presentData.Add(Tuple.Create(24, 11, 8));
            presentData.Add(Tuple.Create(22, 26, 19));
            presentData.Add(Tuple.Create(30, 30, 14));
            presentData.Add(Tuple.Create(2, 4, 13));
            presentData.Add(Tuple.Create(27, 20, 26));
            presentData.Add(Tuple.Create(16, 20, 17));
            presentData.Add(Tuple.Create(11, 12, 13));
            presentData.Add(Tuple.Create(28, 2, 17));
            presentData.Add(Tuple.Create(15, 26, 13));
            presentData.Add(Tuple.Create(29, 15, 25));
            presentData.Add(Tuple.Create(30, 27, 9));
            presentData.Add(Tuple.Create(2, 6, 25));
            presentData.Add(Tuple.Create(10, 26, 19));
            presentData.Add(Tuple.Create(16, 8, 23));
            presentData.Add(Tuple.Create(12, 17, 18));
            presentData.Add(Tuple.Create(26, 14, 22));
            presentData.Add(Tuple.Create(13, 17, 4));
            presentData.Add(Tuple.Create(27, 27, 29));
            presentData.Add(Tuple.Create(17, 13, 22));
            presentData.Add(Tuple.Create(9, 8, 3));
            presentData.Add(Tuple.Create(25, 15, 20));
            presentData.Add(Tuple.Create(14, 13, 16));
            presentData.Add(Tuple.Create(8, 7, 13));
            presentData.Add(Tuple.Create(12, 4, 21));
            presentData.Add(Tuple.Create(27, 16, 15));
            presentData.Add(Tuple.Create(6, 14, 5));
            presentData.Add(Tuple.Create(28, 29, 17));
            presentData.Add(Tuple.Create(23, 17, 25));
            presentData.Add(Tuple.Create(10, 27, 28));
            presentData.Add(Tuple.Create(1, 28, 21));
            presentData.Add(Tuple.Create(18, 2, 30));
            presentData.Add(Tuple.Create(25, 30, 16));
            presentData.Add(Tuple.Create(25, 21, 7));
            presentData.Add(Tuple.Create(2, 3, 4));
            presentData.Add(Tuple.Create(9, 6, 13));
            presentData.Add(Tuple.Create(19, 6, 10));
            presentData.Add(Tuple.Create(28, 17, 8));
            presentData.Add(Tuple.Create(13, 24, 28));
            presentData.Add(Tuple.Create(24, 12, 7));
            presentData.Add(Tuple.Create(5, 19, 5));
            presentData.Add(Tuple.Create(18, 10, 27));
            presentData.Add(Tuple.Create(16, 1, 6));
            presentData.Add(Tuple.Create(12, 14, 30));
            presentData.Add(Tuple.Create(1, 2, 28));
            presentData.Add(Tuple.Create(23, 21, 2));
            presentData.Add(Tuple.Create(13, 3, 23));
            presentData.Add(Tuple.Create(9, 22, 10));
            presentData.Add(Tuple.Create(10, 17, 2));
            presentData.Add(Tuple.Create(24, 20, 11));
            presentData.Add(Tuple.Create(30, 6, 14));
            presentData.Add(Tuple.Create(28, 1, 16));
            presentData.Add(Tuple.Create(24, 20, 1));
            presentData.Add(Tuple.Create(28, 7, 7));
            presentData.Add(Tuple.Create(1, 24, 21));
            presentData.Add(Tuple.Create(14, 9, 7));
            presentData.Add(Tuple.Create(22, 8, 15));
            presentData.Add(Tuple.Create(20, 1, 21));
            presentData.Add(Tuple.Create(6, 3, 7));
            presentData.Add(Tuple.Create(7, 26, 14));
            presentData.Add(Tuple.Create(5, 7, 28));
            presentData.Add(Tuple.Create(5, 4, 4));
            presentData.Add(Tuple.Create(15, 7, 28));
            presentData.Add(Tuple.Create(30, 16, 23));
            presentData.Add(Tuple.Create(7, 26, 2));
            presentData.Add(Tuple.Create(1, 2, 30));
            presentData.Add(Tuple.Create(24, 28, 20));
            presentData.Add(Tuple.Create(5, 17, 28));
            presentData.Add(Tuple.Create(4, 15, 20));
            presentData.Add(Tuple.Create(15, 26, 2));
            presentData.Add(Tuple.Create(1, 3, 23));
            presentData.Add(Tuple.Create(22, 30, 24));
            presentData.Add(Tuple.Create(9, 20, 16));
            presentData.Add(Tuple.Create(7, 15, 2));
            presentData.Add(Tuple.Create(6, 21, 18));
            presentData.Add(Tuple.Create(21, 21, 29));
            presentData.Add(Tuple.Create(29, 10, 10));
            presentData.Add(Tuple.Create(4, 3, 23));
            presentData.Add(Tuple.Create(23, 2, 18));
            presentData.Add(Tuple.Create(29, 24, 14));
            presentData.Add(Tuple.Create(29, 29, 16));
            presentData.Add(Tuple.Create(22, 28, 24));
            presentData.Add(Tuple.Create(21, 18, 24));
            presentData.Add(Tuple.Create(16, 21, 6));
            presentData.Add(Tuple.Create(3, 9, 22));
            presentData.Add(Tuple.Create(9, 18, 4));
            presentData.Add(Tuple.Create(22, 9, 9));
            presentData.Add(Tuple.Create(12, 9, 13));
            presentData.Add(Tuple.Create(18, 21, 14));
            presentData.Add(Tuple.Create(7, 8, 29));
            presentData.Add(Tuple.Create(28, 28, 14));
            presentData.Add(Tuple.Create(1, 6, 24));
            presentData.Add(Tuple.Create(11, 11, 3));
            presentData.Add(Tuple.Create(8, 28, 6));
            presentData.Add(Tuple.Create(11, 16, 10));
            presentData.Add(Tuple.Create(9, 16, 16));
            presentData.Add(Tuple.Create(6, 6, 19));
            presentData.Add(Tuple.Create(21, 5, 12));
            presentData.Add(Tuple.Create(15, 17, 12));
            presentData.Add(Tuple.Create(3, 6, 29));
            presentData.Add(Tuple.Create(19, 1, 26));
            presentData.Add(Tuple.Create(10, 30, 25));
            presentData.Add(Tuple.Create(24, 26, 21));
            presentData.Add(Tuple.Create(1, 10, 18));
            presentData.Add(Tuple.Create(6, 1, 16));
            presentData.Add(Tuple.Create(4, 17, 27));
            presentData.Add(Tuple.Create(17, 11, 27));
            presentData.Add(Tuple.Create(15, 15, 21));
            presentData.Add(Tuple.Create(14, 23, 1));
            presentData.Add(Tuple.Create(8, 9, 30));
            presentData.Add(Tuple.Create(22, 22, 25));
            presentData.Add(Tuple.Create(20, 27, 22));
            presentData.Add(Tuple.Create(12, 7, 9));
            presentData.Add(Tuple.Create(9, 26, 19));
            presentData.Add(Tuple.Create(26, 25, 12));
            presentData.Add(Tuple.Create(8, 8, 16));
            presentData.Add(Tuple.Create(28, 15, 10));
            presentData.Add(Tuple.Create(29, 18, 2));
            presentData.Add(Tuple.Create(25, 22, 6));
            presentData.Add(Tuple.Create(4, 6, 15));
            presentData.Add(Tuple.Create(12, 18, 4));
            presentData.Add(Tuple.Create(10, 3, 20));
            presentData.Add(Tuple.Create(17, 28, 17));
            presentData.Add(Tuple.Create(14, 25, 13));
            presentData.Add(Tuple.Create(14, 10, 3));
            presentData.Add(Tuple.Create(14, 5, 10));
            presentData.Add(Tuple.Create(7, 7, 22));
            presentData.Add(Tuple.Create(21, 2, 14));
            presentData.Add(Tuple.Create(1, 21, 5));
            presentData.Add(Tuple.Create(27, 29, 1));
            presentData.Add(Tuple.Create(6, 20, 4));
            presentData.Add(Tuple.Create(7, 19, 23));
            presentData.Add(Tuple.Create(28, 19, 27));
            presentData.Add(Tuple.Create(3, 9, 18));
            presentData.Add(Tuple.Create(13, 17, 17));
            presentData.Add(Tuple.Create(18, 8, 15));
            presentData.Add(Tuple.Create(26, 23, 17));
            presentData.Add(Tuple.Create(10, 10, 13));
            presentData.Add(Tuple.Create(11, 5, 21));
            presentData.Add(Tuple.Create(25, 15, 29));
            presentData.Add(Tuple.Create(6, 23, 24));
            presentData.Add(Tuple.Create(10, 7, 2));
            presentData.Add(Tuple.Create(19, 10, 30));
            presentData.Add(Tuple.Create(4, 3, 23));
            presentData.Add(Tuple.Create(22, 12, 6));
            presentData.Add(Tuple.Create(11, 17, 16));
            presentData.Add(Tuple.Create(6, 8, 12));
            presentData.Add(Tuple.Create(18, 20, 11));
            presentData.Add(Tuple.Create(6, 2, 2));
            presentData.Add(Tuple.Create(17, 4, 11));
            presentData.Add(Tuple.Create(20, 23, 22));
            presentData.Add(Tuple.Create(29, 23, 24));
            presentData.Add(Tuple.Create(25, 11, 21));
            presentData.Add(Tuple.Create(22, 11, 15));
            presentData.Add(Tuple.Create(29, 3, 9));
            presentData.Add(Tuple.Create(13, 30, 5));
            presentData.Add(Tuple.Create(17, 10, 12));
            presentData.Add(Tuple.Create(10, 30, 8));
            presentData.Add(Tuple.Create(21, 16, 17));
            presentData.Add(Tuple.Create(1, 5, 26));
            presentData.Add(Tuple.Create(22, 15, 16));
            presentData.Add(Tuple.Create(27, 7, 11));
            presentData.Add(Tuple.Create(16, 8, 18));
            presentData.Add(Tuple.Create(29, 9, 7));
            presentData.Add(Tuple.Create(25, 4, 17));
            presentData.Add(Tuple.Create(10, 21, 25));
            presentData.Add(Tuple.Create(2, 19, 21));
            presentData.Add(Tuple.Create(29, 11, 16));
            presentData.Add(Tuple.Create(18, 26, 21));
            presentData.Add(Tuple.Create(2, 8, 20));
            presentData.Add(Tuple.Create(17, 29, 27));
            presentData.Add(Tuple.Create(25, 27, 4));
            presentData.Add(Tuple.Create(14, 3, 14));
            presentData.Add(Tuple.Create(25, 29, 29));
            presentData.Add(Tuple.Create(26, 18, 11));
            presentData.Add(Tuple.Create(8, 24, 28));
            presentData.Add(Tuple.Create(7, 30, 24));
            presentData.Add(Tuple.Create(12, 30, 22));
            presentData.Add(Tuple.Create(29, 20, 6));
            presentData.Add(Tuple.Create(3, 17, 1));
            presentData.Add(Tuple.Create(6, 15, 14));
            presentData.Add(Tuple.Create(6, 22, 20));
            presentData.Add(Tuple.Create(13, 26, 26));
            presentData.Add(Tuple.Create(12, 2, 1));
            presentData.Add(Tuple.Create(7, 14, 12));
            presentData.Add(Tuple.Create(15, 16, 11));
            presentData.Add(Tuple.Create(3, 21, 4));
            presentData.Add(Tuple.Create(30, 17, 29));
            presentData.Add(Tuple.Create(9, 18, 27));
            presentData.Add(Tuple.Create(11, 28, 16));
            presentData.Add(Tuple.Create(22, 3, 25));
            presentData.Add(Tuple.Create(18, 15, 15));
            presentData.Add(Tuple.Create(2, 30, 12));
            presentData.Add(Tuple.Create(3, 27, 22));
            presentData.Add(Tuple.Create(10, 8, 8));
            presentData.Add(Tuple.Create(26, 16, 14));
            presentData.Add(Tuple.Create(15, 2, 29));
            presentData.Add(Tuple.Create(12, 10, 7));
            presentData.Add(Tuple.Create(21, 20, 15));
            presentData.Add(Tuple.Create(2, 15, 25));
            presentData.Add(Tuple.Create(4, 14, 13));
            presentData.Add(Tuple.Create(3, 15, 13));
            presentData.Add(Tuple.Create(29, 8, 3));
            presentData.Add(Tuple.Create(7, 7, 28));
            presentData.Add(Tuple.Create(15, 10, 24));
            presentData.Add(Tuple.Create(23, 15, 5));
            presentData.Add(Tuple.Create(5, 7, 14));
            presentData.Add(Tuple.Create(24, 1, 22));
            presentData.Add(Tuple.Create(1, 11, 13));
            presentData.Add(Tuple.Create(26, 4, 19));
            presentData.Add(Tuple.Create(19, 16, 26));
            presentData.Add(Tuple.Create(5, 25, 5));
            presentData.Add(Tuple.Create(17, 25, 14));
            presentData.Add(Tuple.Create(23, 7, 14));
            presentData.Add(Tuple.Create(24, 6, 17));
            presentData.Add(Tuple.Create(5, 13, 12));
            presentData.Add(Tuple.Create(20, 20, 5));
            presentData.Add(Tuple.Create(22, 29, 17));
            presentData.Add(Tuple.Create(11, 17, 29));
            presentData.Add(Tuple.Create(25, 6, 4));
            presentData.Add(Tuple.Create(29, 8, 16));
            presentData.Add(Tuple.Create(28, 22, 24));
            presentData.Add(Tuple.Create(24, 23, 17));
            presentData.Add(Tuple.Create(16, 17, 4));
            presentData.Add(Tuple.Create(17, 8, 25));
            presentData.Add(Tuple.Create(22, 9, 13));
            presentData.Add(Tuple.Create(24, 4, 8));
            presentData.Add(Tuple.Create(18, 10, 20));
            presentData.Add(Tuple.Create(21, 23, 21));
            presentData.Add(Tuple.Create(13, 14, 12));
            presentData.Add(Tuple.Create(23, 26, 4));
            presentData.Add(Tuple.Create(4, 10, 29));
            presentData.Add(Tuple.Create(2, 18, 18));
            presentData.Add(Tuple.Create(19, 5, 21));
            presentData.Add(Tuple.Create(2, 27, 23));
            presentData.Add(Tuple.Create(6, 29, 30));
            presentData.Add(Tuple.Create(21, 9, 20));
            presentData.Add(Tuple.Create(6, 5, 16));
            presentData.Add(Tuple.Create(25, 10, 27));
            presentData.Add(Tuple.Create(5, 29, 21));
            presentData.Add(Tuple.Create(24, 14, 19));
            presentData.Add(Tuple.Create(19, 11, 8));
            presentData.Add(Tuple.Create(2, 28, 6));
            presentData.Add(Tuple.Create(19, 25, 6));
            presentData.Add(Tuple.Create(27, 1, 11));
            presentData.Add(Tuple.Create(6, 8, 29));
            presentData.Add(Tuple.Create(18, 25, 30));
            presentData.Add(Tuple.Create(4, 27, 26));
            presentData.Add(Tuple.Create(8, 12, 1));
            presentData.Add(Tuple.Create(7, 17, 25));
            presentData.Add(Tuple.Create(7, 14, 27));
            presentData.Add(Tuple.Create(12, 9, 5));
            presentData.Add(Tuple.Create(14, 29, 13));
            presentData.Add(Tuple.Create(18, 17, 5));
            presentData.Add(Tuple.Create(23, 1, 3));
            presentData.Add(Tuple.Create(28, 5, 13));
            presentData.Add(Tuple.Create(3, 2, 26));
            presentData.Add(Tuple.Create(3, 7, 11));
            presentData.Add(Tuple.Create(1, 8, 7));
            presentData.Add(Tuple.Create(12, 5, 4));
            presentData.Add(Tuple.Create(2, 30, 21));
            presentData.Add(Tuple.Create(16, 30, 11));
            presentData.Add(Tuple.Create(3, 26, 4));
            presentData.Add(Tuple.Create(16, 9, 4));
            presentData.Add(Tuple.Create(11, 9, 22));
            presentData.Add(Tuple.Create(23, 5, 6));
            presentData.Add(Tuple.Create(13, 20, 3));
            presentData.Add(Tuple.Create(4, 3, 2));
            presentData.Add(Tuple.Create(14, 10, 29));
            presentData.Add(Tuple.Create(11, 8, 12));
            presentData.Add(Tuple.Create(26, 15, 16));
            presentData.Add(Tuple.Create(7, 17, 29));
            presentData.Add(Tuple.Create(18, 19, 18));
            presentData.Add(Tuple.Create(8, 28, 4));
            presentData.Add(Tuple.Create(22, 6, 13));
            presentData.Add(Tuple.Create(9, 23, 7));
            presentData.Add(Tuple.Create(11, 23, 20));
            presentData.Add(Tuple.Create(13, 11, 26));
            presentData.Add(Tuple.Create(15, 30, 13));
            presentData.Add(Tuple.Create(1, 5, 8));
            presentData.Add(Tuple.Create(5, 10, 24));
            presentData.Add(Tuple.Create(22, 25, 17));
            presentData.Add(Tuple.Create(27, 20, 25));
            presentData.Add(Tuple.Create(30, 10, 21));
            presentData.Add(Tuple.Create(16, 28, 24));
            presentData.Add(Tuple.Create(20, 12, 8));
            presentData.Add(Tuple.Create(17, 25, 1));
            presentData.Add(Tuple.Create(30, 14, 9));
            presentData.Add(Tuple.Create(14, 18, 6));
            presentData.Add(Tuple.Create(8, 28, 29));
            presentData.Add(Tuple.Create(12, 18, 29));
            presentData.Add(Tuple.Create(9, 7, 18));
            presentData.Add(Tuple.Create(6, 12, 25));
            presentData.Add(Tuple.Create(20, 13, 24));
            presentData.Add(Tuple.Create(22, 3, 12));
            presentData.Add(Tuple.Create(5, 23, 22));
            presentData.Add(Tuple.Create(8, 10, 17));
            presentData.Add(Tuple.Create(7, 23, 5));
            presentData.Add(Tuple.Create(10, 26, 27));
            presentData.Add(Tuple.Create(14, 26, 19));
            presentData.Add(Tuple.Create(10, 18, 24));
            presentData.Add(Tuple.Create(8, 4, 4));
            presentData.Add(Tuple.Create(16, 15, 11));
            presentData.Add(Tuple.Create(3, 14, 9));
            presentData.Add(Tuple.Create(18, 5, 30));
            presentData.Add(Tuple.Create(29, 12, 26));
            presentData.Add(Tuple.Create(16, 13, 12));
            presentData.Add(Tuple.Create(15, 10, 7));
            presentData.Add(Tuple.Create(18, 5, 26));
            presentData.Add(Tuple.Create(14, 1, 6));
            presentData.Add(Tuple.Create(10, 8, 29));
            presentData.Add(Tuple.Create(3, 4, 9));
            presentData.Add(Tuple.Create(19, 4, 23));
            presentData.Add(Tuple.Create(28, 17, 23));
            presentData.Add(Tuple.Create(30, 7, 17));
            presentData.Add(Tuple.Create(19, 5, 9));
            presentData.Add(Tuple.Create(26, 29, 28));
            presentData.Add(Tuple.Create(22, 13, 17));
            presentData.Add(Tuple.Create(28, 2, 1));
            presentData.Add(Tuple.Create(20, 30, 8));
            presentData.Add(Tuple.Create(15, 13, 21));
            presentData.Add(Tuple.Create(25, 23, 19));
            presentData.Add(Tuple.Create(27, 23, 1));
            presentData.Add(Tuple.Create(4, 6, 23));
            presentData.Add(Tuple.Create(29, 29, 24));
            presentData.Add(Tuple.Create(5, 18, 7));
            presentData.Add(Tuple.Create(4, 6, 30));
            presentData.Add(Tuple.Create(17, 15, 2));
            presentData.Add(Tuple.Create(27, 4, 2));
            presentData.Add(Tuple.Create(25, 24, 14));
            presentData.Add(Tuple.Create(28, 8, 30));
            presentData.Add(Tuple.Create(24, 29, 5));
            presentData.Add(Tuple.Create(14, 30, 14));
            presentData.Add(Tuple.Create(10, 18, 19));
            presentData.Add(Tuple.Create(15, 26, 22));
            presentData.Add(Tuple.Create(24, 19, 21));
            presentData.Add(Tuple.Create(29, 23, 27));
            presentData.Add(Tuple.Create(21, 10, 16));
            presentData.Add(Tuple.Create(7, 4, 29));
            presentData.Add(Tuple.Create(14, 21, 3));
            presentData.Add(Tuple.Create(21, 4, 28));
            presentData.Add(Tuple.Create(17, 16, 15));
            presentData.Add(Tuple.Create(24, 7, 13));
            presentData.Add(Tuple.Create(21, 24, 15));
            presentData.Add(Tuple.Create(25, 11, 16));
            presentData.Add(Tuple.Create(10, 26, 13));
            presentData.Add(Tuple.Create(23, 20, 14));
            presentData.Add(Tuple.Create(20, 29, 27));
            presentData.Add(Tuple.Create(14, 24, 14));
            presentData.Add(Tuple.Create(14, 23, 12));
            presentData.Add(Tuple.Create(18, 6, 5));
            presentData.Add(Tuple.Create(3, 18, 9));
            presentData.Add(Tuple.Create(8, 18, 19));
            presentData.Add(Tuple.Create(20, 26, 15));
            presentData.Add(Tuple.Create(16, 14, 13));
            presentData.Add(Tuple.Create(30, 16, 3));
            presentData.Add(Tuple.Create(17, 13, 4));
            presentData.Add(Tuple.Create(15, 19, 30));
            presentData.Add(Tuple.Create(20, 3, 8));
            presentData.Add(Tuple.Create(13, 4, 5));
            presentData.Add(Tuple.Create(12, 10, 15));
            presentData.Add(Tuple.Create(8, 23, 26));
            presentData.Add(Tuple.Create(16, 8, 15));
            presentData.Add(Tuple.Create(22, 8, 11));
            presentData.Add(Tuple.Create(12, 11, 18));
            presentData.Add(Tuple.Create(28, 3, 30));
            presentData.Add(Tuple.Create(15, 8, 4));
            presentData.Add(Tuple.Create(13, 22, 13));
            presentData.Add(Tuple.Create(21, 26, 21));
            presentData.Add(Tuple.Create(29, 1, 15));
            presentData.Add(Tuple.Create(28, 9, 5));
            presentData.Add(Tuple.Create(27, 3, 26));
            presentData.Add(Tuple.Create(22, 19, 30));
            presentData.Add(Tuple.Create(4, 11, 22));
            presentData.Add(Tuple.Create(21, 27, 20));
            presentData.Add(Tuple.Create(22, 26, 7));
            presentData.Add(Tuple.Create(19, 28, 20));
            presentData.Add(Tuple.Create(24, 23, 16));
            presentData.Add(Tuple.Create(26, 12, 9));
            presentData.Add(Tuple.Create(13, 22, 9));
            presentData.Add(Tuple.Create(5, 6, 23));
            presentData.Add(Tuple.Create(20, 7, 2));
            presentData.Add(Tuple.Create(18, 26, 30));
            presentData.Add(Tuple.Create(3, 6, 28));
            presentData.Add(Tuple.Create(24, 18, 13));
            presentData.Add(Tuple.Create(28, 19, 16));
            presentData.Add(Tuple.Create(25, 21, 25));
            presentData.Add(Tuple.Create(25, 19, 23));
            presentData.Add(Tuple.Create(22, 29, 10));
            presentData.Add(Tuple.Create(29, 19, 30));
            presentData.Add(Tuple.Create(4, 7, 27));
            presentData.Add(Tuple.Create(5, 12, 28));
            presentData.Add(Tuple.Create(8, 26, 6));
            presentData.Add(Tuple.Create(14, 14, 25));
            presentData.Add(Tuple.Create(17, 17, 2));
            presentData.Add(Tuple.Create(5, 27, 11));
            presentData.Add(Tuple.Create(8, 2, 2));
            presentData.Add(Tuple.Create(3, 20, 24));
            presentData.Add(Tuple.Create(26, 10, 9));
            presentData.Add(Tuple.Create(22, 28, 27));
            presentData.Add(Tuple.Create(18, 15, 20));
            presentData.Add(Tuple.Create(12, 11, 1));
            presentData.Add(Tuple.Create(5, 14, 30));
            presentData.Add(Tuple.Create(7, 3, 16));
            presentData.Add(Tuple.Create(2, 16, 16));
            presentData.Add(Tuple.Create(18, 20, 15));
            presentData.Add(Tuple.Create(13, 14, 29));
            presentData.Add(Tuple.Create(1, 17, 12));
            presentData.Add(Tuple.Create(13, 5, 23));
            presentData.Add(Tuple.Create(19, 4, 10));
            presentData.Add(Tuple.Create(25, 19, 11));
            presentData.Add(Tuple.Create(15, 17, 14));
            presentData.Add(Tuple.Create(1, 28, 27));
            presentData.Add(Tuple.Create(11, 9, 28));
            presentData.Add(Tuple.Create(9, 10, 18));
            presentData.Add(Tuple.Create(30, 11, 22));
            presentData.Add(Tuple.Create(21, 21, 20));
            presentData.Add(Tuple.Create(2, 1, 5));
            presentData.Add(Tuple.Create(2, 25, 1));
            presentData.Add(Tuple.Create(7, 3, 4));
            presentData.Add(Tuple.Create(22, 15, 29));
            presentData.Add(Tuple.Create(21, 28, 15));
            presentData.Add(Tuple.Create(12, 12, 4));
            presentData.Add(Tuple.Create(21, 30, 6));
            presentData.Add(Tuple.Create(15, 10, 7));
            presentData.Add(Tuple.Create(10, 14, 6));
            presentData.Add(Tuple.Create(21, 26, 18));
            presentData.Add(Tuple.Create(14, 25, 6));
            presentData.Add(Tuple.Create(9, 7, 11));
            presentData.Add(Tuple.Create(22, 3, 1));
            presentData.Add(Tuple.Create(1, 16, 27));
            presentData.Add(Tuple.Create(1, 14, 23));
            presentData.Add(Tuple.Create(2, 13, 8));
            presentData.Add(Tuple.Create(14, 19, 11));
            presentData.Add(Tuple.Create(21, 26, 1));
            presentData.Add(Tuple.Create(4, 28, 13));
            presentData.Add(Tuple.Create(12, 16, 20));
            presentData.Add(Tuple.Create(21, 13, 9));
            presentData.Add(Tuple.Create(3, 4, 13));
            presentData.Add(Tuple.Create(14, 9, 8));
            presentData.Add(Tuple.Create(21, 21, 12));
            presentData.Add(Tuple.Create(27, 10, 17));
            presentData.Add(Tuple.Create(6, 20, 6));
            presentData.Add(Tuple.Create(28, 23, 23));
            presentData.Add(Tuple.Create(2, 28, 12));
            presentData.Add(Tuple.Create(8, 10, 10));
            presentData.Add(Tuple.Create(3, 9, 2));
            presentData.Add(Tuple.Create(20, 3, 29));
            presentData.Add(Tuple.Create(19, 4, 16));
            presentData.Add(Tuple.Create(29, 24, 9));
            presentData.Add(Tuple.Create(26, 20, 8));
            presentData.Add(Tuple.Create(15, 28, 26));
            presentData.Add(Tuple.Create(18, 17, 10));
            presentData.Add(Tuple.Create(7, 22, 10));
            presentData.Add(Tuple.Create(20, 15, 9));
            presentData.Add(Tuple.Create(6, 10, 8));
            presentData.Add(Tuple.Create(7, 26, 21));
            presentData.Add(Tuple.Create(8, 8, 16));
            presentData.Add(Tuple.Create(15, 6, 29));
            presentData.Add(Tuple.Create(22, 30, 11));
            presentData.Add(Tuple.Create(18, 25, 8));
            presentData.Add(Tuple.Create(6, 21, 20));
            presentData.Add(Tuple.Create(7, 23, 25));
            presentData.Add(Tuple.Create(8, 25, 26));
            presentData.Add(Tuple.Create(11, 25, 27));
            presentData.Add(Tuple.Create(22, 18, 23));
            presentData.Add(Tuple.Create(3, 2, 14));
            presentData.Add(Tuple.Create(16, 16, 1));
            presentData.Add(Tuple.Create(15, 13, 11));
            presentData.Add(Tuple.Create(3, 9, 25));
            presentData.Add(Tuple.Create(29, 25, 24));
            presentData.Add(Tuple.Create(9, 15, 1));
            presentData.Add(Tuple.Create(12, 4, 1));
            presentData.Add(Tuple.Create(23, 30, 20));
            presentData.Add(Tuple.Create(3, 1, 23));
            presentData.Add(Tuple.Create(6, 10, 29));
            presentData.Add(Tuple.Create(28, 13, 24));
            presentData.Add(Tuple.Create(4, 19, 17));
            presentData.Add(Tuple.Create(6, 6, 25));
            presentData.Add(Tuple.Create(27, 29, 17));
            presentData.Add(Tuple.Create(12, 13, 2));
            presentData.Add(Tuple.Create(10, 7, 13));
            presentData.Add(Tuple.Create(14, 15, 8));
            presentData.Add(Tuple.Create(22, 2, 3));
            presentData.Add(Tuple.Create(27, 17, 19));
            presentData.Add(Tuple.Create(23, 10, 16));
            presentData.Add(Tuple.Create(5, 9, 25));
            presentData.Add(Tuple.Create(9, 25, 14));
            presentData.Add(Tuple.Create(11, 18, 6));
            presentData.Add(Tuple.Create(18, 10, 12));
            presentData.Add(Tuple.Create(9, 4, 15));
            presentData.Add(Tuple.Create(7, 16, 14));
            presentData.Add(Tuple.Create(17, 24, 10));
            presentData.Add(Tuple.Create(11, 4, 6));
            presentData.Add(Tuple.Create(12, 9, 17));
            presentData.Add(Tuple.Create(22, 18, 12));
            presentData.Add(Tuple.Create(6, 24, 24));
            presentData.Add(Tuple.Create(6, 22, 23));
            presentData.Add(Tuple.Create(5, 17, 30));
            presentData.Add(Tuple.Create(6, 9, 5));
            presentData.Add(Tuple.Create(17, 20, 10));
            presentData.Add(Tuple.Create(6, 8, 12));
            presentData.Add(Tuple.Create(14, 17, 13));
            presentData.Add(Tuple.Create(29, 10, 17));
            presentData.Add(Tuple.Create(22, 4, 5));
            presentData.Add(Tuple.Create(10, 19, 30));
            presentData.Add(Tuple.Create(22, 29, 11));
            presentData.Add(Tuple.Create(10, 12, 29));
            presentData.Add(Tuple.Create(21, 22, 26));
            presentData.Add(Tuple.Create(16, 6, 25));
            presentData.Add(Tuple.Create(1, 26, 24));
            presentData.Add(Tuple.Create(30, 17, 16));
            presentData.Add(Tuple.Create(27, 28, 5));
            presentData.Add(Tuple.Create(30, 13, 22));
            presentData.Add(Tuple.Create(7, 26, 12));
            presentData.Add(Tuple.Create(11, 24, 30));
            presentData.Add(Tuple.Create(1, 17, 25));
            presentData.Add(Tuple.Create(22, 1, 3));
            presentData.Add(Tuple.Create(29, 24, 6));
            presentData.Add(Tuple.Create(4, 8, 24));
            presentData.Add(Tuple.Create(13, 9, 20));
            presentData.Add(Tuple.Create(8, 12, 9));
            presentData.Add(Tuple.Create(21, 25, 4));
            presentData.Add(Tuple.Create(23, 23, 28));
            presentData.Add(Tuple.Create(5, 2, 19));
            presentData.Add(Tuple.Create(29, 3, 15));
            presentData.Add(Tuple.Create(22, 1, 14));
            presentData.Add(Tuple.Create(3, 23, 30));
            presentData.Add(Tuple.Create(8, 25, 3));
            presentData.Add(Tuple.Create(15, 8, 14));
            presentData.Add(Tuple.Create(30, 14, 6));
            presentData.Add(Tuple.Create(23, 27, 24));
            presentData.Add(Tuple.Create(19, 1, 2));
            presentData.Add(Tuple.Create(10, 9, 13));
            presentData.Add(Tuple.Create(13, 8, 7));
            presentData.Add(Tuple.Create(8, 13, 22));
            presentData.Add(Tuple.Create(5, 15, 20));
            presentData.Add(Tuple.Create(17, 14, 8));
            presentData.Add(Tuple.Create(5, 11, 20));
            presentData.Add(Tuple.Create(5, 10, 27));
            presentData.Add(Tuple.Create(24, 17, 19));
            presentData.Add(Tuple.Create(21, 2, 3));
            presentData.Add(Tuple.Create(15, 30, 26));
            presentData.Add(Tuple.Create(21, 19, 15));
            presentData.Add(Tuple.Create(2, 7, 23));
            presentData.Add(Tuple.Create(13, 17, 25));
            presentData.Add(Tuple.Create(30, 15, 19));
            presentData.Add(Tuple.Create(26, 4, 10));
            presentData.Add(Tuple.Create(2, 25, 8));
            presentData.Add(Tuple.Create(9, 9, 10));
            presentData.Add(Tuple.Create(2, 25, 8));
            presentData.Add(Tuple.Create(19, 21, 30));
            presentData.Add(Tuple.Create(17, 26, 12));
            presentData.Add(Tuple.Create(7, 5, 10));
            presentData.Add(Tuple.Create(2, 22, 14));
            presentData.Add(Tuple.Create(10, 17, 30));
            presentData.Add(Tuple.Create(1, 8, 5));
            presentData.Add(Tuple.Create(23, 2, 25));
            presentData.Add(Tuple.Create(22, 29, 8));
            presentData.Add(Tuple.Create(13, 26, 1));
            presentData.Add(Tuple.Create(26, 3, 30));
            presentData.Add(Tuple.Create(25, 17, 8));
            presentData.Add(Tuple.Create(25, 18, 26));
            presentData.Add(Tuple.Create(26, 19, 15));
            presentData.Add(Tuple.Create(8, 28, 10));
            presentData.Add(Tuple.Create(12, 16, 29));
            presentData.Add(Tuple.Create(30, 6, 29));
            presentData.Add(Tuple.Create(28, 19, 4));
            presentData.Add(Tuple.Create(27, 26, 18));
            presentData.Add(Tuple.Create(15, 23, 17));
            presentData.Add(Tuple.Create(5, 21, 30));
            presentData.Add(Tuple.Create(8, 11, 13));
            presentData.Add(Tuple.Create(2, 26, 7));
            presentData.Add(Tuple.Create(19, 9, 24));
            presentData.Add(Tuple.Create(3, 22, 23));
            presentData.Add(Tuple.Create(6, 7, 18));
            presentData.Add(Tuple.Create(4, 26, 30));
            presentData.Add(Tuple.Create(13, 25, 20));
            presentData.Add(Tuple.Create(17, 3, 15));
            presentData.Add(Tuple.Create(8, 20, 18));
            presentData.Add(Tuple.Create(23, 18, 23));
            presentData.Add(Tuple.Create(28, 23, 9));
            presentData.Add(Tuple.Create(16, 3, 4));
            presentData.Add(Tuple.Create(1, 29, 14));
            presentData.Add(Tuple.Create(20, 26, 22));
            presentData.Add(Tuple.Create(3, 2, 22));
            presentData.Add(Tuple.Create(23, 8, 17));
            presentData.Add(Tuple.Create(19, 5, 17));
            presentData.Add(Tuple.Create(21, 18, 20));
            presentData.Add(Tuple.Create(17, 21, 8));
            presentData.Add(Tuple.Create(30, 28, 1));
            presentData.Add(Tuple.Create(29, 19, 23));
            presentData.Add(Tuple.Create(12, 12, 11));
            presentData.Add(Tuple.Create(24, 18, 7));
            presentData.Add(Tuple.Create(21, 18, 14));
            presentData.Add(Tuple.Create(14, 26, 25));
            presentData.Add(Tuple.Create(9, 11, 3));
            presentData.Add(Tuple.Create(10, 7, 15));
            presentData.Add(Tuple.Create(27, 6, 28));
            presentData.Add(Tuple.Create(14, 26, 4));
            presentData.Add(Tuple.Create(28, 4, 1));
            presentData.Add(Tuple.Create(22, 25, 29));
            presentData.Add(Tuple.Create(6, 26, 6));
            presentData.Add(Tuple.Create(1, 3, 13));
            presentData.Add(Tuple.Create(26, 22, 12));
            presentData.Add(Tuple.Create(6, 21, 26));
            presentData.Add(Tuple.Create(23, 4, 27));
            presentData.Add(Tuple.Create(26, 13, 24));
            presentData.Add(Tuple.Create(5, 24, 28));
            presentData.Add(Tuple.Create(22, 16, 7));
            presentData.Add(Tuple.Create(3, 27, 24));
            presentData.Add(Tuple.Create(19, 28, 2));
            presentData.Add(Tuple.Create(11, 13, 9));
            presentData.Add(Tuple.Create(29, 16, 22));
            presentData.Add(Tuple.Create(30, 10, 24));
            presentData.Add(Tuple.Create(14, 14, 22));
            presentData.Add(Tuple.Create(22, 23, 16));
            presentData.Add(Tuple.Create(14, 8, 3));
            presentData.Add(Tuple.Create(20, 5, 14));
            presentData.Add(Tuple.Create(28, 6, 13));
            presentData.Add(Tuple.Create(3, 15, 25));
            presentData.Add(Tuple.Create(4, 12, 22));
            presentData.Add(Tuple.Create(15, 12, 25));
            presentData.Add(Tuple.Create(10, 11, 24));
            presentData.Add(Tuple.Create(7, 7, 6));
            presentData.Add(Tuple.Create(8, 11, 9));
            presentData.Add(Tuple.Create(21, 10, 29));
            presentData.Add(Tuple.Create(23, 28, 30));
            presentData.Add(Tuple.Create(8, 29, 26));
            presentData.Add(Tuple.Create(16, 27, 11));
            presentData.Add(Tuple.Create(1, 10, 2));
            presentData.Add(Tuple.Create(24, 20, 16));
            presentData.Add(Tuple.Create(7, 12, 28));
            presentData.Add(Tuple.Create(28, 8, 20));
            presentData.Add(Tuple.Create(14, 10, 30));
            presentData.Add(Tuple.Create(1, 19, 6));
            presentData.Add(Tuple.Create(4, 12, 20));
            presentData.Add(Tuple.Create(18, 2, 7));
            presentData.Add(Tuple.Create(24, 18, 17));
            presentData.Add(Tuple.Create(16, 11, 10));
            presentData.Add(Tuple.Create(1, 12, 22));
            presentData.Add(Tuple.Create(30, 16, 28));
            presentData.Add(Tuple.Create(18, 12, 11));
            presentData.Add(Tuple.Create(28, 9, 8));
            presentData.Add(Tuple.Create(23, 6, 17));
            presentData.Add(Tuple.Create(10, 3, 11));
            presentData.Add(Tuple.Create(5, 12, 8));
            presentData.Add(Tuple.Create(22, 2, 23));
            presentData.Add(Tuple.Create(9, 19, 14));
            presentData.Add(Tuple.Create(15, 28, 13));
            presentData.Add(Tuple.Create(27, 20, 23));
            presentData.Add(Tuple.Create(19, 16, 12));
            presentData.Add(Tuple.Create(19, 30, 15));
            presentData.Add(Tuple.Create(8, 17, 4));
            presentData.Add(Tuple.Create(10, 22, 18));
            presentData.Add(Tuple.Create(13, 22, 4));
            presentData.Add(Tuple.Create(3, 12, 19));
            presentData.Add(Tuple.Create(22, 16, 23));
            presentData.Add(Tuple.Create(11, 8, 19));
            presentData.Add(Tuple.Create(8, 11, 6));
            presentData.Add(Tuple.Create(7, 14, 7));
            presentData.Add(Tuple.Create(29, 17, 29));
            presentData.Add(Tuple.Create(21, 8, 12));
            presentData.Add(Tuple.Create(21, 9, 11));
            presentData.Add(Tuple.Create(20, 1, 27));
            presentData.Add(Tuple.Create(1, 22, 11));
            presentData.Add(Tuple.Create(5, 28, 4));
            presentData.Add(Tuple.Create(26, 7, 26));
            presentData.Add(Tuple.Create(30, 12, 18));
            presentData.Add(Tuple.Create(29, 11, 20));
            presentData.Add(Tuple.Create(3, 12, 15));
            presentData.Add(Tuple.Create(24, 25, 17));
            presentData.Add(Tuple.Create(14, 6, 11));
            var paperExpected = 1588178;
            int paperRequired = 0;

            foreach (var presentDatum in presentData)
            {
                var present = new Present(presentDatum.Item1, presentDatum.Item2, presentDatum.Item3);
                paperRequired += GetPaperRequiredInSquareFeet(present);
                //TestContext.WriteLine($"Side 1: {present.Length}, Side 2: {present.Width}, Side 3: {present.Height}");
            }
            TestContext.WriteLine($"Expected: {paperExpected}, Actual: {paperRequired}");

            //Assert.AreEqual(instructionSet.Item2, travelDataPosition);
        }

        [Test]
        public void Day_2_a_Tests()
        {
            List<Tuple<int, int, int>> presentData = new();
            presentData.Add(Tuple.Create(2, 3, 4));
            var paperExpected = 58;
            int paperRequired = 0;
            foreach (var presentDatum in presentData)
            {
                var present = new Present(presentDatum.Item1, presentDatum.Item2, presentDatum.Item3);
                paperRequired += GetPaperRequiredInSquareFeet(present);
                TestContext.WriteLine($"Side 1: {present.Length}, Side 2: {present.Width}, Side 3: {present.Height}");
            }
            TestContext.WriteLine($"Expected: {paperExpected}, Actual: {paperRequired}");
        }

        public static int GetPaperRequiredInSquareFeet(Present present)
        {
            var requiredPaperInSquareFeet = 0;
            requiredPaperInSquareFeet = present.SurfaceArea() + present.SmallestSurfaceArea();
            return requiredPaperInSquareFeet;
        }

        public class Present
        {
            private List<int> _surfaceAreaPerSide = new();
            public Present(int length, int width, int height)
            {
                if (length <= 0 || width <= 0 || height <= 0)
                {
                    throw new ArgumentOutOfRangeException("Length, Width and Height must all be greater than 0(zero).");
                }
                Length = length;
                Width = width;
                Height = height;
                _surfaceAreaPerSide.Add(length * width);
                _surfaceAreaPerSide.Add(length * height);
                _surfaceAreaPerSide.Add(height * width);
            }

            public int Length { get; private set; }
            public int Width { get; private set; }
            public int Height { get; private set; }

            public int Area()
            {
                return Length * Width * Height;
            }

            public int SurfaceArea()
            {
                return (2 * Length * Width) + (2 * Width * Height) + (2 * Length * Height);
            }

            public int SmallestSurfaceArea()
            {
                return _surfaceAreaPerSide.Min();
            }
        }

        [Test]
        public void Day_1_b()
        {
            var travelData = "((((()(()(((((((()))(((()((((()())(())()(((()((((((()((()(()(((()(()((())))()((()()())))))))))()((((((())((()))(((((()(((((((((()()))((()(())()((())((()(()))((()))()))()(((((()(((()()))()())((()((((())()())()((((())()(()(()(((()(())(()(())(((((((())()()(((())(()(()(()(())))(()((((())((()))(((()(()()(((((()()(()(((()(((((())()))()((()(()))()((()((((())((((())(()(((())()()(()()()()()(())((((())((())(()()))()((((())))((((()())()((((())((()())((())(())(((((()((((()(((()((((())(()(((()()))()))((((((()((())()())))(((()(()))(()()(()(((()(()))((()()()())((()()()(((())())()())())())((()))(()(()))(((((()(()(())((()(())(())()((((()())()))((((())(())((())())((((()(((())(())((()()((((()((((((()(())()()(()(()()((((()))(())()())()))(())))(())))())()()(())(()))()((()(()(())()()))(()())))))(()))(()()))(())(((((()(()(()()((())()())))))((())())((())(()(())((()))(())(((()((((((((()()()(()))()()(((()))()((()()(())(())())()(()(())))(((((()(())(())(()))))())()))(()))()(()(((((((()((((())))())())())())()((((((((((((((()()((((((()()()())())()())())())(())(())))())((()())((()(()))))))()))))))))))))))))())((())((())()()))))))(((()((()(()()))((())(()()))()()())))(())))))))(()(((())))())()())))()()(())()))()(()))())((()()))))(()))))()))(()()(())))))))()(((()))))()(()))(())())))))()))((()))((()))())(())))))))))((((())()))()))()))())(())()()(())))())))(()())()))((()()(())))(())((((((()(())((()(((()(()()(())))()))))))()))()(()((()))()(()))(()(((())((((())())(())(()))))))))())))))))())())))))())))))()()(((())()(()))))))))())))))(())()()()))()))()))(()(())()()())())))))))())()(()(()))))()()()))))())(()))))()()))))()())))))(((())()()))(()))))))))))()()))))()()()))))(()())())()()())()(()))))()(()))(())))))))(((((())(())())()()))()()))(())))))()(()))))(())(()()))()())()))()))()))()))))())()()))())())))(()))(()))))))())()(((())()))))))))()))()())))())))())))()))))))))))()()))(()()))))))(())()(()))))())(()))))(()))))(()())))))())())()()))))())()))))))))(()))))()))))))()(()())))))))()))())))())))())))())))))))())(()()))))))(()())())))()())()))))))))))))))())))()(())))()))())()()(())(()()))(())))())()())(()(()(()))))())))))))))))())(()))()))()))))(())()())()())))))))))))()()))))))))))))())())))))(()())))))))))))())(())))()))))))))())())(()))()))(())))()))()()(())()))))))()((((())()))())())))))()))()))))((()())()))))())))(())))))))))))))))))()))))()()())()))()()))))())()))((()())))())))(()))(()())))))))()))()))))(())))))))(())))))())()()(()))())()))()()))))())()()))))())()))())))))))(()))))()())()))))))))(()))())))(()))()))))(())()))())())(())())())))))))((((())))))()))()))()())()(())))()))()))()())(()())()()(()())()))))())())))))(()))()))))())(()()(())))))(())()()((())())))))(())(())))))))())))))))))()(())))))))()())())())()(()))))))))(()))))))))())()()))()(()))))))()))))))())))))))(())))()()(())()())))))(((())))()((())()))())))(()()))())(())())))()(((()())))))()(()()())))()()(()()(()()))())()(()()()))())()()))()())(()))))())))))())))(())()()))))(()))))(())(()))(())))))()()))()))))())()))()()(())())))((()))())()))))))()()))))((()(()))))()()))))))())))))())(()((()())))))))))))()())())))()))(()))))))(()))(())()())))(()))))))))())()()()()))))(()())))))))((())))()))(()))(())(())()())()))))))))(())))())))(()))()()))(()()))(()))())))()(())))())((()((()(())))((())))()))))((((())())()())))(())))()))))))())(()()((())))())()(()())))))(()())()))())))))))((())())))))))(()(()))())()()(()()(((()(((()())))))()))))))()(())(()()((()()(())()()))())()())()))()())())())))))))(((())))))))()()))))))(((())()))(()()))(()()))))(()(()()((((())()())((()()))))(()(())))))()((()()()())()()((()((()()))(()))(((()()()))(((())))()(((())()))))))((()(())())))(()())(((((()(()))(()((()))(()())()))))(()(()))()(()))(())(((())(()()))))()()))(((()))))(()()()()))())))((()()()(())()))()))))()()))()))))))((((((()()()))))())((()()(((()))))(()(())(()()())())())))()(((()()))(())((())))(()))(()()()())((())())())(()))))()))()((()(())()(()()(())(()))(())()))(())(()))))(())(())())(()()(()((()()((())))((()))()((())))(((()()()()((((()))(()()))()()()(((())((())())(()()(()()()))()((())(())()))())(((()()(())))()((()()())()())(()(())())(((())(())())((())(())()(((()()))(())))((())(()())())(())((()()()((((((())))((()(((((())()))()))(())(()()))()))(())()()))(())((()()())()()(()))())()((())))()((()()())((((()())((())())())((()((()))()))((())((()()(()((()()(((())(()()))))((()((())()(((())(()((())())((())(()((((((())())()(()())()(())(((())((((((()(())(()((()()()((()()(()()()())))()()(((((()()))()((((((()))()(()(()(()(((()())((()))())()((()))(())))()))()()))())()()))())((((())(()(()))(((((((())(((()(((((()(((()()((((())(((())())))(()()()(()(()))()))((((((()))((()(((()(())((()((((()((((((())(((((())))(((()(()))))(((()(((())()((())(()((()))(((()()(((())((((()(()(((((()))(((()(((((((()(()()()(()(()(()()())(())(((((()(())())()())(()(()(()))()(()()()())(()()(()((()))()((())())()(()))((())(()))()(()))()(((()(()(()((((((()()()()())()(((((()()(((()()()((()(((((()))((((((((()()()(((((()))))))(()()()(())(()))(()()))))(())()))(((((()(((((()()(()(()())(((()))((((()((()(()(()((()(()((())))()(((()((()))((()))(((((((((()((()((()(())))()((((()((()()))((())(((()(((((()()(()(()()((()(()()()(((((((())())()())))))((((()()(()))()))(()((())()(()(((((((((()()(((()(()())(()((()())((())())((((()(((()(((()((((()((()((((()(()((((((())((((((((((((()()(()()((((((((((((((()((()()))()((((((((((((())((((()(()())((()(()(()))()(((((()()(((()()))()())(())((()(((((()((())(((((()((()(((((()))()()((((())()((((())(((((((((()(())(()(())))())(()((())(((())(())(())())(()(()(())()()((()((())()(((()(((((()(())))()(((()((())))((()()()(((()(((()((()(()(())(()((()())(()(()(((()(((((((((())(()((((()()))(()((((()()()()(((()((((((((()(()()((((((()(()()(()((()((((((((((()()(((((((()())(())))(((()()))(((((()((()()())(()()((((())((()((((()))))(())((()(()()(((()(()(((()((((()(((((()))())())(()((())()))(((()())((())((())((((()((()((((((())(()((((()()))((((((())()(()))((()(((())((((((((((()()(((((()(((((()((()()()((((())))(()))()((()(())()()((()((((((((((()((())(())(((((()(()(()()))((((()((((()()((()(((()(((((((((()(()((()((()))((((((()(((())()()((()(((((((()())))()()(()((()((()()(((()(()()()()((((()((())((((()(((((((((()(((()()(((()(()(((()(((()((())()(()((()(()(()(()))()(((()))(()((((()((())((((())((((((())(()))(()((((())((()(()((((((((()()((((((()(()(()()()(())((()((()()(((()(((((((()()((()(((((((()))(((((()(((()(()()()(()(((()((()()((())(()(((((((((()(()((()((((((()()((())()))(((((()((())()())()(((((((((((()))((((()()()()())(()()(()(()()))()))(()))(()(((()()))())(()(()))()()((())(()())()())()(()))()))(()()(()((((((())((()(((((((((((()(())()((()(()((()((()(()((()((((((((((()()())((())()(())))((())()())()(((((()(()())((((()((()(())(()))(((())()((()))(((((())(()))()()(()))(((())((((()((((()(())))(((((((()))))())()())(())((())()(()()((()(()))()(()()(()()((()())((())((()()))((((()))()()))(()()(())()()(((((()(())((()((((()))()))(()())())(((()()(()()))(())))))(()))((())(((((()((((()))()((((()))()((())(((())))(((()())))((()(()()((";
            var floor = GetTravelDataPositionWhenBasementEncountered(travelData);
            var expectedTravelDataPosition = 1795;
            TestContext.WriteLine($"Expected: {0}, Actual: {floor}");
            Assert.AreEqual(expectedTravelDataPosition, floor);
        }

        [Test]
        public void Day_1_b_Tests()
        {
            var travelDataPlusExpectedBasementPosition = new List<Tuple<string, int>>()
            {
                Tuple.Create("((((", 0),
                Tuple.Create(")", 1),
                Tuple.Create("()())", 5)
            };
            foreach (var instructionSet in travelDataPlusExpectedBasementPosition)
            {
                var travelDataPosition = GetTravelDataPositionWhenBasementEncountered(instructionSet.Item1);
                Assert.AreEqual(instructionSet.Item2, travelDataPosition);
                TestContext.WriteLine($"Expected: {instructionSet.Item2}, Actual: {travelDataPosition}");
            }
        }

        public static int GetTravelDataPositionWhenBasementEncountered(string travelData)
        {
            var floor = 0;
            for (var travelDataPosition = 0; travelDataPosition < travelData.Length; travelDataPosition++)
            {
                var instruction = travelData[travelDataPosition];
                switch (instruction)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                    default:
                        Assert.Fail();
                        break;
                }

                if (floor <= -1)
                {
                    return travelDataPosition + 1;
                }
            }

            return 0;
        }

        [Test]
        public void Day_1_a()
        {
            var travelData = "((((()(()(((((((()))(((()((((()())(())()(((()((((((()((()(()(((()(()((())))()((()()())))))))))()((((((())((()))(((((()(((((((((()()))((()(())()((())((()(()))((()))()))()(((((()(((()()))()())((()((((())()())()((((())()(()(()(((()(())(()(())(((((((())()()(((())(()(()(()(())))(()((((())((()))(((()(()()(((((()()(()(((()(((((())()))()((()(()))()((()((((())((((())(()(((())()()(()()()()()(())((((())((())(()()))()((((())))((((()())()((((())((()())((())(())(((((()((((()(((()((((())(()(((()()))()))((((((()((())()())))(((()(()))(()()(()(((()(()))((()()()())((()()()(((())())()())())())((()))(()(()))(((((()(()(())((()(())(())()((((()())()))((((())(())((())())((((()(((())(())((()()((((()((((((()(())()()(()(()()((((()))(())()())()))(())))(())))())()()(())(()))()((()(()(())()()))(()())))))(()))(()()))(())(((((()(()(()()((())()())))))((())())((())(()(())((()))(())(((()((((((((()()()(()))()()(((()))()((()()(())(())())()(()(())))(((((()(())(())(()))))())()))(()))()(()(((((((()((((())))())())())())()((((((((((((((()()((((((()()()())())()())())())(())(())))())((()())((()(()))))))()))))))))))))))))())((())((())()()))))))(((()((()(()()))((())(()()))()()())))(())))))))(()(((())))())()())))()()(())()))()(()))())((()()))))(()))))()))(()()(())))))))()(((()))))()(()))(())())))))()))((()))((()))())(())))))))))((((())()))()))()))())(())()()(())))())))(()())()))((()()(())))(())((((((()(())((()(((()(()()(())))()))))))()))()(()((()))()(()))(()(((())((((())())(())(()))))))))())))))))())())))))())))))()()(((())()(()))))))))())))))(())()()()))()))()))(()(())()()())())))))))())()(()(()))))()()()))))())(()))))()()))))()())))))(((())()()))(()))))))))))()()))))()()()))))(()())())()()())()(()))))()(()))(())))))))(((((())(())())()()))()()))(())))))()(()))))(())(()()))()())()))()))()))()))))())()()))())())))(()))(()))))))())()(((())()))))))))()))()())))())))())))()))))))))))()()))(()()))))))(())()(()))))())(()))))(()))))(()())))))())())()()))))())()))))))))(()))))()))))))()(()())))))))()))())))())))())))())))))))())(()()))))))(()())())))()())()))))))))))))))())))()(())))()))())()()(())(()()))(())))())()())(()(()(()))))())))))))))))())(()))()))()))))(())()())()())))))))))))()()))))))))))))())())))))(()())))))))))))())(())))()))))))))())())(()))()))(())))()))()()(())()))))))()((((())()))())())))))()))()))))((()())()))))())))(())))))))))))))))))()))))()()())()))()()))))())()))((()())))())))(()))(()())))))))()))()))))(())))))))(())))))())()()(()))())()))()()))))())()()))))())()))())))))))(()))))()())()))))))))(()))())))(()))()))))(())()))())())(())())())))))))((((())))))()))()))()())()(())))()))()))()())(()())()()(()())()))))())())))))(()))()))))())(()()(())))))(())()()((())())))))(())(())))))))())))))))))()(())))))))()())())())()(()))))))))(()))))))))())()()))()(()))))))()))))))())))))))(())))()()(())()())))))(((())))()((())()))())))(()()))())(())())))()(((()())))))()(()()())))()()(()()(()()))())()(()()()))())()()))()())(()))))())))))())))(())()()))))(()))))(())(()))(())))))()()))()))))())()))()()(())())))((()))())()))))))()()))))((()(()))))()()))))))())))))())(()((()())))))))))))()())())))()))(()))))))(()))(())()())))(()))))))))())()()()()))))(()())))))))((())))()))(()))(())(())()())()))))))))(())))())))(()))()()))(()()))(()))())))()(())))())((()((()(())))((())))()))))((((())())()())))(())))()))))))())(()()((())))())()(()())))))(()())()))())))))))((())())))))))(()(()))())()()(()()(((()(((()())))))()))))))()(())(()()((()()(())()()))())()())()))()())())())))))))(((())))))))()()))))))(((())()))(()()))(()()))))(()(()()((((())()())((()()))))(()(())))))()((()()()())()()((()((()()))(()))(((()()()))(((())))()(((())()))))))((()(())())))(()())(((((()(()))(()((()))(()())()))))(()(()))()(()))(())(((())(()()))))()()))(((()))))(()()()()))())))((()()()(())()))()))))()()))()))))))((((((()()()))))())((()()(((()))))(()(())(()()())())())))()(((()()))(())((())))(()))(()()()())((())())())(()))))()))()((()(())()(()()(())(()))(())()))(())(()))))(())(())())(()()(()((()()((())))((()))()((())))(((()()()()((((()))(()()))()()()(((())((())())(()()(()()()))()((())(())()))())(((()()(())))()((()()())()())(()(())())(((())(())())((())(())()(((()()))(())))((())(()())())(())((()()()((((((())))((()(((((())()))()))(())(()()))()))(())()()))(())((()()())()()(()))())()((())))()((()()())((((()())((())())())((()((()))()))((())((()()(()((()()(((())(()()))))((()((())()(((())(()((())())((())(()((((((())())()(()())()(())(((())((((((()(())(()((()()()((()()(()()()())))()()(((((()()))()((((((()))()(()(()(()(((()())((()))())()((()))(())))()))()()))())()()))())((((())(()(()))(((((((())(((()(((((()(((()()((((())(((())())))(()()()(()(()))()))((((((()))((()(((()(())((()((((()((((((())(((((())))(((()(()))))(((()(((())()((())(()((()))(((()()(((())((((()(()(((((()))(((()(((((((()(()()()(()(()(()()())(())(((((()(())())()())(()(()(()))()(()()()())(()()(()((()))()((())())()(()))((())(()))()(()))()(((()(()(()((((((()()()()())()(((((()()(((()()()((()(((((()))((((((((()()()(((((()))))))(()()()(())(()))(()()))))(())()))(((((()(((((()()(()(()())(((()))((((()((()(()(()((()(()((())))()(((()((()))((()))(((((((((()((()((()(())))()((((()((()()))((())(((()(((((()()(()(()()((()(()()()(((((((())())()())))))((((()()(()))()))(()((())()(()(((((((((()()(((()(()())(()((()())((())())((((()(((()(((()((((()((()((((()(()((((((())((((((((((((()()(()()((((((((((((((()((()()))()((((((((((((())((((()(()())((()(()(()))()(((((()()(((()()))()())(())((()(((((()((())(((((()((()(((((()))()()((((())()((((())(((((((((()(())(()(())))())(()((())(((())(())(())())(()(()(())()()((()((())()(((()(((((()(())))()(((()((())))((()()()(((()(((()((()(()(())(()((()())(()(()(((()(((((((((())(()((((()()))(()((((()()()()(((()((((((((()(()()((((((()(()()(()((()((((((((((()()(((((((()())(())))(((()()))(((((()((()()())(()()((((())((()((((()))))(())((()(()()(((()(()(((()((((()(((((()))())())(()((())()))(((()())((())((())((((()((()((((((())(()((((()()))((((((())()(()))((()(((())((((((((((()()(((((()(((((()((()()()((((())))(()))()((()(())()()((()((((((((((()((())(())(((((()(()(()()))((((()((((()()((()(((()(((((((((()(()((()((()))((((((()(((())()()((()(((((((()())))()()(()((()((()()(((()(()()()()((((()((())((((()(((((((((()(((()()(((()(()(((()(((()((())()(()((()(()(()(()))()(((()))(()((((()((())((((())((((((())(()))(()((((())((()(()((((((((()()((((((()(()(()()()(())((()((()()(((()(((((((()()((()(((((((()))(((((()(((()(()()()(()(((()((()()((())(()(((((((((()(()((()((((((()()((())()))(((((()((())()())()(((((((((((()))((((()()()()())(()()(()(()()))()))(()))(()(((()()))())(()(()))()()((())(()())()())()(()))()))(()()(()((((((())((()(((((((((((()(())()((()(()((()((()(()((()((((((((((()()())((())()(())))((())()())()(((((()(()())((((()((()(())(()))(((())()((()))(((((())(()))()()(()))(((())((((()((((()(())))(((((((()))))())()())(())((())()(()()((()(()))()(()()(()()((()())((())((()()))((((()))()()))(()()(())()()(((((()(())((()((((()))()))(()())())(((()()(()()))(())))))(()))((())(((((()((((()))()((((()))()((())(((())))(((()())))((()(()()((";
            var floor = GetFloorPosition(travelData);
            var expectedFloor = 74;
            TestContext.WriteLine($"Expected: {0}, Actual: {floor}");
            Assert.AreEqual(expectedFloor, floor);
        }

        [Test]
        public void Day_1_a_Tests()
        {
            List<Tuple<string, int>> travelDataPlusExpectedFloor = new List<Tuple<string, int>>()
            {
                Tuple.Create("(())", 0),
                Tuple.Create("()()", 0),
                Tuple.Create("(((", 3),
                Tuple.Create("(()(()(", 3),
                Tuple.Create("))(((((", 3),
                Tuple.Create("())", -1),
                Tuple.Create("))(", -1),
                Tuple.Create(")))", -3),
                Tuple.Create(")())())", -3)
            };
            foreach (var instructionSet in travelDataPlusExpectedFloor)
            {
                var floor = GetFloorPosition(instructionSet.Item1);
                Assert.AreEqual(instructionSet.Item2, floor);
                TestContext.WriteLine($"Expected: {instructionSet.Item2}, Actual: {floor}");
            }
        }

        public static int GetFloorPosition(string travelData)
        {
            var floor = 0;
            foreach (char instruction in travelData)
            {
                switch (instruction)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
            return floor;
        }
    }
}