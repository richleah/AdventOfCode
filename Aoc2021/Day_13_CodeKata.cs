using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021.CodeKata;

public class Day_13_CodeKata
{
    [Test]
    public void Should_load_sample_data()
    {
        // Arrange

        // Act
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13Sample);

        // Let's add the ability to print the grid of dots
        // and then let's start building a method that will fold the paper, the grid of dots
        //Page1Decoder.PrintTheGrid(data.GridOfDots);
        //Page1Decoder.PrintTheGrid(data.GridOfDots, data.Folds.Skip(1).First());

        //Assert
        Assert.IsNotNull(data);

        //Assert.IsNotEmpty(inputData);
    }

    [Test]
    public void Should_fold_horizontal()
    {
        // Arrange
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13Sample);

        //Assert.AreEqual(15, data.GridOfDots.GetLength(0));
        //Assert.AreEqual(11, data.GridOfDots.GetLength(1));
        TestContext.WriteLine();
        TestContext.WriteLine("BeforeGrid:");
        Page1Decoder.PrintTheGrid(data.GridOfDots, data.Folds.First());

        // Act
        bool[,] returnedGrid = Page1Decoder.FoldTheGrid(data.GridOfDots, data.Folds.First());

        TestContext.WriteLine();
        TestContext.WriteLine("AfterGrid");
        Page1Decoder.PrintTheGrid(returnedGrid);
        
        // Assert
        Assert.AreEqual(7, returnedGrid.GetLength(0));
        Assert.AreEqual(11, data.GridOfDots.GetLength(1));
    }

    [Test]
    public void Should_fold_vertical()
    {
        // Arrange
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13Sample);

        //Assert.AreEqual(15, data.GridOfDots.GetLength(0));
        //Assert.AreEqual(11, data.GridOfDots.GetLength(1));

        bool[,] returnedGrid = Page1Decoder.FoldTheGrid(data.GridOfDots, data.Folds.First());
        // Act

        TestContext.WriteLine();
        TestContext.WriteLine("BeforeGrid:");
        Page1Decoder.PrintTheGrid(returnedGrid, data.Folds.Skip(1).First());

        bool[,] returnedGrid2 = Page1Decoder.FoldTheGrid(returnedGrid, data.Folds.Skip(1).First());

        TestContext.WriteLine();
        TestContext.WriteLine("AfterGrid");
        Page1Decoder.PrintTheGrid(returnedGrid2);
        
        // Assert
        Assert.AreEqual(7, returnedGrid2.GetLength(0));
        Assert.AreEqual(5, returnedGrid2.GetLength(1));
    }

    [Test]
    public void Should_count_dots_sample_data_after_first_fold()
    {
        // Arrange
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13Sample);

        // Act
        bool[,] returnedGrid = Page1Decoder.FoldTheGrid(data.GridOfDots, data.Folds.First());
        int count = Page1Decoder.CountDots(returnedGrid);

        //TestContext.WriteLine();
        //TestContext.WriteLine("BeforeGrid:");
        //Page1Decoder.PrintTheGrid(returnedGrid, data.Folds.Skip(1).First());
        //TestContext.WriteLine();
        //TestContext.WriteLine("AfterGrid");
        //Page1Decoder.PrintTheGrid(returnedGrid2);
        
        // Assert
        Assert.AreEqual(17, count);
    }

    [Test]
    public void Should_count_dots_real_data_after_first_fold()
    {
        // Arrange
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13);

        // Act
        bool[,] returnedGrid = Page1Decoder.FoldTheGrid(data.GridOfDots, data.Folds.First());
        int count = Page1Decoder.CountDots(returnedGrid);

        //TestContext.WriteLine();
        //TestContext.WriteLine("BeforeGrid:");
        //Page1Decoder.PrintTheGrid(returnedGrid, data.Folds.Skip(1).First());
        //TestContext.WriteLine();
        //TestContext.WriteLine("AfterGrid");
        //Page1Decoder.PrintTheGrid(returnedGrid2);
        
        // Assert
        Assert.AreEqual(745, count);
    }

    [Test]
    public void Should_fold_real_data()
    {
        // Arrange
        Page1 data = ThermalCameraCodeLoader.Load(Aoc2021Data.Day13);

        // Act
        Page1Decoder.FoldTheGrid(data);

        // Assert
        //Assert.AreEqual(17, count);
    }



}

public class Page1Decoder
{
    public static void PrintTheGrid(bool[,] grid, Fold? fold = null)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                if (fold != null && fold.Axis == Axis.Horizontal && fold.Line == row)
                {
                    TestContext.Write("-");
                    continue;
                }

                if (fold != null && fold.Axis == Axis.Vertical && fold.Line == column)
                {
                    TestContext.Write("|");
                    continue;
                }

                TestContext.Write(grid[row, column] ? "#" : ".");
            }
            TestContext.WriteLine();
        }
    }

    public static void FoldTheGrid(Page1 page1)
    {
        bool[,] grid = page1.GridOfDots;

        foreach (Fold fold in page1.Folds)
        {
            grid = FoldTheGrid(grid, fold);
        }

        PrintTheGrid(grid);
    }
    
    public static bool[,]? FoldTheGrid(bool[,] grid, Fold fold)
    {
        // determine the new grid size
        int newRowCount = 0;
        int newColumnCount = 0;
        bool[,]? returnGrid = null;

        if (fold.Axis == Axis.Horizontal)
        {
            newRowCount = fold.Line;
            newColumnCount = grid.GetLength(1);

            returnGrid = new bool[newRowCount, newColumnCount];

            // copy existing grid into the new return grid
            for (int row = 0; row < fold.Line; row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (grid[row, column])
                    {
                        returnGrid[row, column] = true;
                    }
                }
            }

            // fold the existing grid and update the new return grid when there is a dot on the grid (dot==true)
            for (int row = fold.Line + 1; row < grid.GetLength(0); row++)
            {
                var rowApply = fold.Line - (row - fold.Line);
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (grid[row, column])
                    {
                        returnGrid[rowApply, column] = true;
                    }
                }
            }
        }
        else if (fold.Axis == Axis.Vertical)
        {
            newRowCount = grid.GetLength(0);
            newColumnCount = fold.Line;

            returnGrid = new bool[newRowCount, newColumnCount];

            // copy existing grid into the new return grid
            for (int column = 0; column < fold.Line; column++)
            {
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    if (grid[row, column])
                    {
                        returnGrid[row, column] = true;
                    }
                }
            }

            // fold the existing grid and update the new return grid when there is a dot on the grid (dot==true)
            for (int column = fold.Line + 1; column < grid.GetLength(1); column++)
            {
                var columnApply = fold.Line - (column - fold.Line);
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    if (grid[row, column])
                    {
                        returnGrid[row, columnApply] = true;
                    }
                }
            }
        }

        return returnGrid;
    }

    public static int CountDots(bool[,]? grid)
    {
        int count = 0;

        foreach (bool b in grid)
        {
            if (b)
            {
                count++;
            }
        }

        return count;
    }
}

public class ThermalCameraCodeLoader
{
    public static Page1 Load(string data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList();

        var gridInputData = inputData
            .Where(x => !x.StartsWith("fold along"))
            .Select(x =>
            {
                string[] lineData = x.Split(",", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToArray();

                return new Point(Convert.ToInt32(lineData[0]), Convert.ToInt32(lineData[1]));
            }).ToList();

        // determine grid size so that I can instantiate the grid
        var gridOfDots = new bool[gridInputData.Max(point => point.Y) + 1, gridInputData.Max(point => point.X) + 1];

        foreach (Point dot in gridInputData)
        {
            gridOfDots[dot.Y, dot.X] = true;
        }

        // build folds
        var folds = inputData.Where(x => x.StartsWith("fold along"))
            .Select(x => x.Replace("fold along ", string.Empty))
            .Select(x =>
            {
                string[] lineData = x.Split("=", StringSplitOptions.TrimEntries).ToArray();
                string axisPart = lineData[0];

                return new Fold(axisPart == "x" ? Axis.Vertical : Axis.Horizontal, Convert.ToInt32(lineData[1]));
            })
            .ToList();

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
    public Fold(Axis axis, int line)
    {
        Axis = axis;
        Line = line;
    }

    public Axis Axis { get; set; }

    public int Line { get; set; }
}

public enum Axis
{
    Horizontal,
    Vertical
}