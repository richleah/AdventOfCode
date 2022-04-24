using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

public class Day13
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
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13Sample);

        //Assert
        Assert.IsNotNull(data);

        //Assert.IsNotEmpty(inputData);
    }

    private static IEnumerable<TestCaseData> inputsForPartA
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day13Sample, 17);
            yield return new TestCaseData(Aoc2021Data.Day13, 745);
        }
    }

    [TestCaseSource(nameof(inputsForPartA))]
    public void When_InputData_PartA_Dot_Count_Should_Be_ExpectedDots(string inputData, int expectedDots)
    {
        // Arrange
        Page1 page1 = ThermalCameraCodeLoader.Load(inputData);

        // Act
        int dots = new ThermalImagingCameraPage1Decoder(page1).CountOfDotsAfterFirstFold();

        //Assert
        Assert.AreEqual(expectedDots, dots);
    }

    private static IEnumerable<TestCaseData> inputsForPartB
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day13Sample, 16);
            yield return new TestCaseData(Aoc2021Data.Day13, 99);
        }
    }

    [TestCaseSource(nameof(inputsForPartB))]
    public void When_InputData_PartB_Dot_Count_Should_Be_ExpectedDots(string inputData, int expectedDots)
    {
        // Arrange
        Page1 page1 = ThermalCameraCodeLoader.Load(inputData);

        // Act
        int dots = new ThermalImagingCameraPage1Decoder(page1).CountOfDotsAfterAllFolds();

        //Assert
        Assert.AreEqual(expectedDots, dots);
    }
}

public class ThermalImagingCameraPage1Decoder
{
    private readonly Page1 _page1;

    public ThermalImagingCameraPage1Decoder(Page1 page1)
    {
        _page1 = page1;
    }

    public int CountOfDotsAfterFirstFold()
    {
        // fold page 1
        _page1.GridOfDots = FoldTheGrid(_page1.GridOfDots, _page1.Folds.First());

        var dots = 0;

        for (var y = 0; y < _page1.GridOfDots.GetLength(1); y++)
        {
            for (var x = 0; x < _page1.GridOfDots.GetLength(0); x++)
            {
                TestContext.Write($"{(_page1.GridOfDots[x, y] ? "#" : ".")}");
                dots += _page1.GridOfDots[x, y] ? 1 : 0;
            }
            TestContext.WriteLine();
        }

        return dots;
    }

    public int CountOfDotsAfterAllFolds()
    {
        // fold page 1
        foreach (Fold fold in _page1.Folds)
        {
            _page1.GridOfDots = FoldTheGrid(_page1.GridOfDots, fold);
        }

        var dots = 0;

        for (var y = 0; y < _page1.GridOfDots.GetLength(1); y++)
        {
            for (var x = 0; x < _page1.GridOfDots.GetLength(0); x++)
            {
                TestContext.Write($"{(_page1.GridOfDots[x, y] ? "#" : ".")}");
                dots += _page1.GridOfDots[x, y] ? 1 : 0;
            }
            TestContext.WriteLine();
        }

        return dots;
    }

    public static bool[,] FoldTheGrid(bool[,] gridOfDots, Fold fold)
    {
        bool[,] keeperGrid;

        if (fold.Axis == Axises.Horizontal)
        {
            //[rows,columns]
            for (var y = fold.Line + 1; y < gridOfDots.GetLength(1); y++)
            {
                var multiplier = y - fold.Line;
                for (var x = 0; x < gridOfDots.GetLength(0); x++)
                {
                    gridOfDots[x, y - (multiplier * 2)] = gridOfDots[x, y - (multiplier * 2)] || gridOfDots[x, y];
                }
            }

            keeperGrid = new bool[gridOfDots.GetLength(0), fold.Line];
            for (var y = 0; y < fold.Line; y++)
            {
                for (var x = 0; x < keeperGrid.GetLength(0); x++)
                {
                    keeperGrid[x, y] = gridOfDots[x, y];
                }
            }
        }
        else
        {
            //[rows,columns]
            for (var x = fold.Line + 1; x < gridOfDots.GetLength(0); x++)
            {
                var multiplier = x - fold.Line;
                for (var y = 0; y < gridOfDots.GetLength(1); y++)
                {
                    // from => to
                    gridOfDots[x - (multiplier * 2), y] = gridOfDots[x - (multiplier * 2), y] || gridOfDots[x, y];
                }
            }

            keeperGrid = new bool[fold.Line, gridOfDots.GetLength(1)];
            for (var y = 0; y < gridOfDots.GetLength(1); y++)
            {
                for (var x = 0; x < fold.Line; x++)
                {
                    keeperGrid[x, y] = gridOfDots[x, y];
                }
            }
        }

        return keeperGrid;
    }
}

public class ThermalCameraCodeLoader
{
    public static Page1 Load(string? data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList();

        var gridInputData = inputData
            .Where(x => !x.StartsWith("fold along"))
            .Select(x =>
            {
                string[] lineData = x.Split(",", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToArray();

                return new Point(Convert.ToInt32(lineData[0]), Convert.ToInt32(lineData[1]));
            }).ToList();

        // build folds
        var folds = inputData.Where(x => x.StartsWith("fold along"))
            .Select(x => x.Replace("fold along ", string.Empty))
            .Select(x =>
            {
                string[] lineData = x.Split("=", StringSplitOptions.TrimEntries).ToArray();
                string axisPart = lineData[0];

                return new Fold(axisPart == "x" ? Axises.Vertical : Axises.Horizontal, Convert.ToInt32(lineData[1]));
            })
            .ToList();

        // determine grid size so that I can
        //var gridOfDots = new Cell[gridInputData.Max(x => x.X) + 1, gridInputData.Max(x => x.Y) + 1];
        var gridOfDots = new bool[gridInputData.Max(x => x.X) + 1, gridInputData.Max(x => x.Y) + 1];

        // build out grid
        //for (var y = 0; y < gridOfDots.GetLength(1); y++)
        //{
        //    for (var x = 0; x < gridOfDots.GetLength(0); x++)
        //    {
        //        gridOfDots[x, y] = new Cell(x, y);
        //    }
        //}

        foreach (Point dot in gridInputData)
        {
            gridOfDots[dot.X, dot.Y] = true;
        }

        return new Page1(gridOfDots, folds);
    }
}

public class Page1
{
    public Page1(bool[,] gridOfDots, List<Fold> folds)
    {
        GridOfDots = gridOfDots;
        Folds = folds;
    }

    public bool[,] GridOfDots { get; set; }

    public List<Fold> Folds { get; set; }
}

public class Fold
{
    public Fold(Axises axis, int line)
    {
        Axis = axis;
        Line = line;
    }

    public Axises Axis { get; set; }

    public int Line { get; set; }
}

public enum Axises
{
    Horizontal,
    Vertical
}