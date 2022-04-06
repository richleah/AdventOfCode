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
        var finder = new CaveExplorer(caveGrid);
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
        var finder = new CaveExplorer(caveGrid);
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
        var finder = new CaveExplorer(caveGrid);
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
        var finder = new CaveExplorer(caveGrid);
        double basinsMultiplied = finder.CalculateThreeLargestBasinsMultiplied();

        //Assert
        Assert.AreEqual(827904, basinsMultiplied);
    }
    
    public class CaveExplorer
    {
        private readonly CaveSpot[,] _caveSpotGrid;
        private int _rowLength => _caveSpotGrid.GetLength(0);
        private int _columnLength => _caveSpotGrid.GetLength(1);

        public CaveExplorer(CaveSpot[,] caveSpotGrid)
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

            for (var y = 0; y < _columnLength; y++)
            {
                for (int x = 0; x < _rowLength; x++)
                {
                    // check if low spot
                    var top = y <= 0 ? 10 : _caveSpotGrid[x, y - 1].Height;
                    var left = x <= 0 ? 10 : _caveSpotGrid[x - 1, y].Height;
                    var right = x == _rowLength - 1 ? 10 : _caveSpotGrid[x + 1, y].Height;
                    var bottom = y == _columnLength - 1 ? 10 : _caveSpotGrid[x, y + 1].Height;
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

        public double CalculateThreeLargestBasinsMultiplied()
        {
            double topThreeBasinsMultiplied = 1;

            var lowSpots = FindLowSpots();

            var lowSpotBasinSize = new Dictionary<CaveSpot, int>();

            foreach (CaveSpot lowCaveSpot in lowSpots)
            {
                lowSpotBasinSize.Add(lowCaveSpot, CalculateBasinSize(lowCaveSpot.Row, lowCaveSpot.Column));
            }

            var topThree = lowSpotBasinSize.OrderByDescending(x => x.Value).Take(3);
            
            foreach (var keyValuePair in topThree)
            {
                topThreeBasinsMultiplied *= keyValuePair.Value;
            }

            return topThreeBasinsMultiplied;
        }

        // right, bottom, left, top, return
        private int CalculateBasinSize(int row, int column)
        {
            int basinSize = 0;
            var caveSpot = _caveSpotGrid[row, column];

            if (caveSpot.HasBeenChecked || caveSpot.Height == 9)
            {
                return basinSize;
            }

            caveSpot.HasBeenChecked = true;
            basinSize += 1;

            // check right
            if (column < _columnLength - 1)
            {
                basinSize += CalculateBasinSize(caveSpot.Row, caveSpot.Column + 1);
            }

            // check bottom
            if (row < _rowLength - 1)
            {
                basinSize += CalculateBasinSize(caveSpot.Row + 1, caveSpot.Column);
            }

            // check left
            if (column > 0)
            {
                basinSize += CalculateBasinSize(caveSpot.Row, caveSpot.Column - 1);
            }

            // check top
            if (row > 0)
            {
                basinSize += CalculateBasinSize(caveSpot.Row - 1, caveSpot.Column);
            }

            return basinSize;
        }
    }

    public class CaveSpot
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int Height { get; set; }

        public bool HasBeenChecked { get; set; }
    }

    public class CaveGridLoader
    {
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
                        Row = x,
                        Column = y
                    };
                    TestContext.Write(caveSpotGrid[x, y].Height.ToString().PadRight(2));
                }
                TestContext.WriteLine();
            }

            return caveSpotGrid;
        }
    }

}