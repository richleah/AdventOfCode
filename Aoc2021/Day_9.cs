using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

[TestFixture]
public class Day_9
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string? inputData = Aoc2021Data.Day9Sample;

        CaveSpot[,] caveGrid = CaveGridLoader.Load(inputData);

        // Act

        //Assert
        Assert.IsNotNull(caveGrid);

        //Assert.IsNotEmpty(inputData);
    }

    [Test]
    public void When_Sample_Data_Risk_Level_Should_Be_15()
    {
        // Arrange
        string? inputData = Aoc2021Data.Day9Sample;
        CaveSpot[,] caveGrid = CaveGridLoader.Load(inputData);

        // Act
        var finder = new LowSpotFinder(caveGrid);
        double riskLevel = finder.CalculateRiskLevel();

        //Assert
        Assert.AreEqual(15, riskLevel);
    }

    [Test]
    public void When_Real_Data_Risk_Level_Should_Be_585()
    {
        // Arrange
        string? inputData = Aoc2021Data.Day9;
        CaveSpot[,] caveGrid = CaveGridLoader.Load(inputData);

        // Act
        var finder = new LowSpotFinder(caveGrid);
        double riskLevel = finder.CalculateRiskLevel();

        //Assert
        Assert.AreEqual(585, riskLevel);
    }

    [Test]
    public void When_Sample_Data_Three_Largest_Basins_Multiplied_Should_Be_1134()
    {
        // Arrange
        string? inputData = Aoc2021Data.Day9Sample;
        CaveSpot[,] caveGrid = CaveGridLoader.Load(inputData);

        // Act
        var finder = new LowSpotFinder(caveGrid);
        double basinsMultiplied = finder.CalculateThreeLargestBasinsMultiplied();

        //Assert
        Assert.AreEqual(1134, basinsMultiplied);
    }
    
    [Test]
    public void When_Sample_Data_Three_Largest_Basins_Multiplied_Should_Be_827904()
    {
        // Arrange
        string? inputData = Aoc2021Data.Day9;
        CaveSpot[,] caveGrid = CaveGridLoader.Load(inputData);

        // Act
        var finder = new LowSpotFinder(caveGrid);
        double basinsMultiplied = finder.CalculateThreeLargestBasinsMultiplied();

        //Assert
        Assert.AreEqual(827904, basinsMultiplied);
    }
    
    public class LowSpotFinder
    {
        private readonly CaveSpot[,] _caveSpotGrid;
        private int _xLength => _caveSpotGrid.GetLength(0);
        private int _yLength => _caveSpotGrid.GetLength(1);

        public LowSpotFinder(CaveSpot[,] caveSpotGrid)
        {
            _caveSpotGrid = caveSpotGrid;
        }

        public double CalculateRiskLevel()
        {
            double riskLevel = 0;

            foreach (CaveSpot lowSpot in FindLowSpots())
            {
                riskLevel += lowSpot.Height + 1;
            }

            return riskLevel;
        }

        private List<CaveSpot> FindLowSpots()
        {
            List<CaveSpot> lowCaveSpots = new();

            for (var y = 0; y < _yLength; y++)
            {
                for (int x = 0; x < _xLength; x++)
                {
                    // check if low spot
                    var top = y <= 0 ? 10 : _caveSpotGrid[x, y - 1].Height;
                    var left = x <= 0 ? 10 : _caveSpotGrid[x - 1, y].Height;
                    var right = x == _xLength - 1 ? 10 : _caveSpotGrid[x + 1, y].Height;
                    var bottom = y == _yLength - 1 ? 10 : _caveSpotGrid[x, y + 1].Height;
                    var theSpot = _caveSpotGrid[x, y].Height;

                    if (theSpot < top && theSpot < left && theSpot < right && theSpot < bottom)
                    {
                        TestContext.WriteLine($"Low Spot found at grid location ({x},{y}) with value: {theSpot}");
                        lowCaveSpots.Add(_caveSpotGrid[x, y]);
                    }
                }
            }

            return lowCaveSpots;
        }

        //private List<int> FindLowSpotsOld()
        //{
        //    List<int> lowSpots = new();

        //    for (var y = 0; y < _yLength; y++)
        //    {
        //        for (int x = 0; x < _xLength; x++)
        //        {
        //            // check if low spot
        //            var top = y <= 0 ? 10 : _caveGrid[x, y - 1];
        //            var left = x <= 0 ? 10 : _caveGrid[x - 1, y];
        //            var right = x == _xLength - 1 ? 10 : _caveGrid[x + 1, y];
        //            var bottom = y == _yLength - 1 ? 10 : _caveGrid[x, y + 1];
        //            var theSpot = _caveGrid[x, y];

        //            if (theSpot < top && theSpot < left && theSpot < right && theSpot < bottom)
        //            {
        //                TestContext.WriteLine($"Low Spot found at grid location ({x},{y}) with value: {theSpot}");
        //                lowSpots.Add(_caveGrid[x, y]);
        //            }
        //        }
        //    }

        //    return lowSpots;
        //}

        public double CalculateThreeLargestBasinsMultiplied()
        {
            double topThreeBasinsMultiplied = 1;

            var lowSpots = FindLowSpots();

            var lowSpotBasinSize = new Dictionary<CaveSpot, int>();

            foreach (CaveSpot lowCaveSpot in lowSpots)
            {
                lowSpotBasinSize.Add(lowCaveSpot, CalculateBasinSize(lowCaveSpot.X, lowCaveSpot.Y));
            }

            var topThree = lowSpotBasinSize.OrderByDescending(x => x.Value).Take(3);
            
            foreach (var keyValuePair in topThree)
            {
                topThreeBasinsMultiplied *= keyValuePair.Value;
            }

            return topThreeBasinsMultiplied;
        }

        // right, bottom, left, top, return
        private int CalculateBasinSize(int x, int y)
        {
            int basinSize = 0;
            var caveSpot = _caveSpotGrid[x, y];

            if (caveSpot.HasBeenChecked || caveSpot.Height == 9)
            {
                return basinSize;
            }

            caveSpot.HasBeenChecked = true;
            basinSize += 1;

            // check right
            if (y < _yLength - 1)
            {
                basinSize += CalculateBasinSize(caveSpot.X, caveSpot.Y + 1);
            }

            // check bottom
            if (x < _xLength - 1)
            {
                basinSize += CalculateBasinSize(caveSpot.X + 1, caveSpot.Y);

            }

            // check left
            if (y > 0)
            {
                basinSize += CalculateBasinSize(caveSpot.X, caveSpot.Y - 1);
            }

            // check top
            if (x > 0)
            {
                basinSize += CalculateBasinSize(caveSpot.X - 1, caveSpot.Y);
            }

            return basinSize;
        }
        
        //private int CalculateBasinSize1(CaveSpot caveSpot)
        //{
        //    int basinSize = 0;
        //    if (caveSpot.HasBeenChecked)
        //    {
        //        return basinSize;
        //    }

        //    basinSize += CalculateBasinSize(_caveSpotGrid[caveSpot.X, caveSpot.Y]);

        //    return basinSize;
        //}
    }

    public class CaveSpot
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public bool IsInBasin { get; set; }

        public bool HasBeenChecked { get; set; }
    }

    public class CaveGridLoader
    {
        public static int[,] LoadOld(string? data)
        {
            string[] inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);
            var xLength = inputData[0].Length;
            var yLength = inputData.Length;
            var caveGrid = new int[xLength, yLength];

            for (var y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLength; x++)
                {
                    caveGrid[x, y] = Convert.ToInt32(inputData[y][x].ToString());
                    TestContext.Write(caveGrid[x, y].ToString().PadRight(2));
                }

                TestContext.WriteLine();
            }

            return caveGrid;
        }

        public static CaveSpot[,] Load(string? data)
        {
            string[] inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);
            var xLength = inputData[0].Length;
            var yLength = inputData.Length;
            var caveSpotGrid = new CaveSpot[xLength, yLength];

            for (var y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLength; x++)
                {
                    caveSpotGrid[x, y] = new CaveSpot
                    {
                        Height = Convert.ToInt32(inputData[y][x].ToString()),
                        X = x,
                        Y = y
                    };
                    TestContext.Write(caveSpotGrid[x, y].Height.ToString().PadRight(2));
                }

                TestContext.WriteLine();
            }

            return caveSpotGrid;
        }
    }

}