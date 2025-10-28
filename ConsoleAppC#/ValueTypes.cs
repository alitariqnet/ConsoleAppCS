﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class ValueTypes
    {
        public struct MutablePoint
        {
            public int X;
            public int Y;

            public MutablePoint(int x, int y) => (X, Y) = (x, y);

            public override string ToString() => $"({X}, {Y})";
        }

        public static void Maine()
        {
            var p1 = new MutablePoint(1, 2);
            var p2 = p1;
            p2.Y = 200;
            Console.WriteLine($"{nameof(p1)} after {nameof(p2)} is modified: {p1}");
            Console.WriteLine($"{nameof(p2)}: {p2}");

            MutateAndDisplay(p2);
            Console.WriteLine($"{nameof(p2)} after passing to a method: {p2}");
        }

        private static void MutateAndDisplay(MutablePoint p)
        {
            p.X = 100;
            Console.WriteLine($"Point mutated in a method: {p}");
        }
    }
}
