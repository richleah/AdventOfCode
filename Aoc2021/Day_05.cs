using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

public class Day_05
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange

        // Act
        List<(Point, Point)> ventCoordinatePairs = HydrothermalVentsDataLoader.Load(Aoc2021Data.Day5Sample);

        //Assert
        Assert.IsNotNull(ventCoordinatePairs);

        //Assert.IsNotEmpty(inputData);
    }

    private static IEnumerable<TestCaseData> inputsForPartA
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day5Sample, 10, 5);
            yield return new TestCaseData(Aoc2021Data.Day5, 1000, 7318);
        }
    }

    [TestCaseSource(nameof(inputsForPartA))]
    public void When_InputData_PartA_Dot_Count_Should_Be_ExpectedOverlaps(string inputData, int gridSize, int expectedOverlaps)
    {
        // Arrange
        var data = HydrothermalVentsDataLoader.Load(inputData);

        // Act
        int overlaps = new HydrothermalVentAvoidanceSystem(data).CountOfHorizontalAndVerticalVentLineOverlaps(gridSize);

        //Assert
        Assert.AreEqual(expectedOverlaps, overlaps);
    }

    private static IEnumerable<TestCaseData> inputsForPartB
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day5Sample, 10, 12);
            yield return new TestCaseData(Aoc2021Data.Day5, 1000, 19939);
        }
    }

    [TestCaseSource(nameof(inputsForPartB))]
    public void When_InputData_PartB_Dot_Count_Should_Be_ExpectedOverlaps(string inputData, int gridSize, int expectedOverlaps)
    {
        // Arrange
        var data = HydrothermalVentsDataLoader.Load(inputData);

        // Act
        int overlaps = new HydrothermalVentAvoidanceSystem(data).CountOfVentLineOverlaps(gridSize);

        //Assert
        Assert.AreEqual(expectedOverlaps, overlaps);
    }
}

public class HydrothermalVentAvoidanceSystem
{
    private readonly List<(Point FromPoint, Point ToPoint)> _ventCoordinatePairs;

    public HydrothermalVentAvoidanceSystem(List<(Point, Point)> ventCoordinatePairs)
    {
        _ventCoordinatePairs = ventCoordinatePairs;
    }

    public int CountOfHorizontalAndVerticalVentLineOverlaps(int gridSize)
    {
        var horizontalAndVerticalVentLines = _ventCoordinatePairs
            .Where(x => x.FromPoint.X == x.ToPoint.X || x.FromPoint.Y == x.ToPoint.Y)
            .ToList();

        int[,] ventLinesGrid = GetVentLinesGrid(gridSize, horizontalAndVerticalVentLines);

        int overlaps = CountOverlaps(ventLinesGrid);

        return overlaps;
    }

    public int CountOfVentLineOverlaps(int gridSize)
    {

        int[,] ventLinesGrid = GetVentLinesGrid(gridSize, _ventCoordinatePairs);

        int overlaps = CountOverlaps(ventLinesGrid);

        return overlaps;
    }

    private int[,] GetVentLinesGrid(int gridSize, List<(Point FromPoint, Point ToPoint)> ventLineCoordinates)
    {
        var ventLinesGrid = new int[gridSize, gridSize];

        foreach ((Point FromPoint, Point ToPoint) ventLineCoordinate in ventLineCoordinates)
        {
            //TestContext.WriteLine($"FromPoint: ({ventLineCoordinate.FromPoint.X},{ventLineCoordinate.FromPoint.Y}) -> ToPoint: ({ventLineCoordinate.ToPoint.X},{ventLineCoordinate.ToPoint.Y})");
            int x = ventLineCoordinate.FromPoint.X;
            int y = ventLineCoordinate.FromPoint.Y;

            // horizontal
            if (ventLineCoordinate.FromPoint.X == ventLineCoordinate.ToPoint.X)
            {
                do
                {
                    ventLinesGrid[ventLineCoordinate.FromPoint.X, y]++;

                } while (ventLineCoordinate.FromPoint.Y < ventLineCoordinate.ToPoint.Y ? y++ != ventLineCoordinate.ToPoint.Y : y-- != ventLineCoordinate.ToPoint.Y);
                continue;
            }

            // vertical
            if (ventLineCoordinate.FromPoint.Y == ventLineCoordinate.ToPoint.Y)
            {
                do
                {
                    ventLinesGrid[x, ventLineCoordinate.FromPoint.Y]++;

                } while (ventLineCoordinate.FromPoint.X < ventLineCoordinate.ToPoint.X ? x++ != ventLineCoordinate.ToPoint.X : x-- != ventLineCoordinate.ToPoint.X);
                continue;
            }

            // diagonal
            do
            {
                //TestContext.WriteLine($"     Diagonal x: {x} - y: {y}");
                ventLinesGrid[x, y]++;

            } while ((ventLineCoordinate.FromPoint.X < ventLineCoordinate.ToPoint.X ? x++ != ventLineCoordinate.ToPoint.X : x-- != ventLineCoordinate.ToPoint.X)
                     && (ventLineCoordinate.FromPoint.Y < ventLineCoordinate.ToPoint.Y ? y++ != ventLineCoordinate.ToPoint.Y : y-- != ventLineCoordinate.ToPoint.Y));
        }
        return ventLinesGrid;
    }

    private static int CountOverlaps(int[,] ventLinesGrid)
    {
        int overlaps = 0;

        foreach (int gridSpot in ventLinesGrid)
        {
            if (gridSpot > 1)
            {
                overlaps++;
            }
        }

        return overlaps;
    }
}

public class HydrothermalVentsDataLoader
{
    public static List<(Point, Point)> Load(string? data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList();

        var coordinatePairs = inputData
            .Select(x => x.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Select(x =>
            {
                var beginCoordinate = x[0].Split(",");

                var endCoordinate = x[1].Split(",");

                return (new Point(Convert.ToInt32(beginCoordinate[0]), Convert.ToInt32(beginCoordinate[1])), new Point(Convert.ToInt32(endCoordinate[0]), Convert.ToInt32(endCoordinate[1])));
            })
            .ToList();

        //foreach ((Point fromPoint, Point toPoint) coordinatePair in coordinatePairs)
        //{
        //    TestContext.Write($"From Point: {coordinatePair.fromPoint.X},{coordinatePair.fromPoint.Y} -> ");
        //    TestContext.Write($"To Point: {coordinatePair.toPoint.X},{coordinatePair.toPoint.Y}");
        //    TestContext.WriteLine();
        //}

        return coordinatePairs;
    }
}