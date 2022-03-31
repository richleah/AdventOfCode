using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture(Ignore = "Not completed")]
public class Day_7
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string? data = Aoc2021Data.Day7Sample;
        var crabHorizontalPositions = data.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        foreach (int position in crabHorizontalPositions)
        {
            TestContext.WriteLine(position);
        }

        // Act

        //Assert
        Assert.IsNotNull(data);
        Assert.IsNotEmpty(crabHorizontalPositions);
    }

    [Test]
    public void Should_determine_fuel_costs_with_sample_data()
    {
        // Arrange
        string? data = Aoc2021Data.Day7Sample;
        var crabPositions = data.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        // Act
        var optimizer = new CrabPositionOptimizer(crabPositions);

        //Assert
        Assert.AreEqual(37, optimizer.FuelRequired().Fuel);
    }

}

public class CrabPositionOptimizer
{
    private readonly List<int> _crabPositions;

    public CrabPositionOptimizer(List<int> crabPositions)
    {
        _crabPositions = crabPositions;
    }

    public PositionFuel FuelRequired()
    {
        var optimalPosition = new PositionFuel();

        var averagePosition = (int)Math.Round(_crabPositions.Average());
        TestContext.WriteLine($"Average Position: {averagePosition}");

        foreach (int crabPosition in _crabPositions)
        {
            optimalPosition.Fuel += Math.Abs(averagePosition - crabPosition);
        }

        return optimalPosition;
    }

    public class PositionFuel
    {
        public int Position { get; set; }

        public int Fuel { get; set; }
    }
}