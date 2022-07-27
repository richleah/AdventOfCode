using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

[TestFixture]
public class Day_01_CodeKata
{

    [Test]
    public void Load_The_Data()
    {
        var data = Aoc2021Data.Day01SampleA;
        List<int> depths = DepthLoader.Load(data);
        Assert.AreEqual(10, depths.Count);
    }


    [Test]
    public void Depth_Measurements_SampleData()
    {
        var data = Aoc2021Data.Day01SampleA;
        var depths = DepthLoader.Load(data);

        var processor = new SonarProcessor(depths);

        int depthIncreases = processor.GetCountOfDepthIncreases();

        Assert.AreEqual(7, depthIncreases);
    }

    [Test]
    public void Depth_Measurements_RealData()
    {
        var data = Aoc2021Data.Day01A;
        var depths = DepthLoader.Load(data);

        var processor = new SonarProcessor(depths);

        int depthIncreases = processor.GetCountOfDepthIncreases();

        Assert.AreEqual(1195, depthIncreases);
    }

    [Test]
    public void Depth_Measurements_Sliding_Window_SampleData()
    {
        var data = Aoc2021Data.Day01SampleA;
        var depths = DepthLoader.Load(data);

        var processor = new SonarProcessor(depths);

        int depthIncreases = processor.GetCountOfDepthWindowIncreases();

        Assert.AreEqual(5, depthIncreases);
    }

    [Test]
    public void Depth_Measurements_Sliding_Window_RealData()
    {
        var data = Aoc2021Data.Day01A;
        var depths = DepthLoader.Load(data);

        var processor = new SonarProcessor(depths);

        int depthIncreases = processor.GetCountOfDepthWindowIncreases();

        Assert.AreEqual(1235, depthIncreases);
    }



    public class SonarProcessor
    {
        private readonly List<int> _depths;

        public SonarProcessor(List<int> depths)
        {
            _depths = depths;
        }

        public int GetCountOfDepthIncreases()
        {
            int count = 0;

            //int previousDepth = _depths[0];
            //foreach (int depth in _depths)
            //{
            //    if (depth > previousDepth)
            //    {
            //        count++;
            //    }
            //    previousDepth = depth;
            //}

            for (int i = 1; i < _depths.Count; i++)
            {
                if (_depths[i] > _depths[i - 1])
                {
                    count++;
                }
            }

            return count;
        }

        public int GetCountOfDepthWindowIncreases()
        {
            int count = 0;

            for (int i = 1; i < _depths.Count - 2; i++)
            {
                int prevDepth = _depths[i - 1] + _depths[i] + _depths[i + 1];
                int currentDepth = _depths[i] + _depths[i + 1] + _depths[ i + 2];
                if (currentDepth > prevDepth)
                {
                    count++;
                }
            }

            //while (_depths.Count >= 4)
            //{
            //    int firstDepth = _depths[0] + _depths[1] + _depths[2];
            //    int secondDepth = _depths[1] + _depths[2] + _depths[3];

            //    if (secondDepth > firstDepth)
            //    {
            //        count++;
            //    }

            //    _depths.RemoveAt(0);
            //}

            return count;
        }
    }

    public class DepthLoader
    {
        public static List<int> Load(string data)
        {
            return data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Select(s => int.Parse(s))
                .ToList();
        }
    }
}
