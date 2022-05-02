using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using MathNet.Numerics.Statistics;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

//[TestFixture(Ignore = "Not completed")]
public class Day_07
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
        var crabHorizontalPositions = CrabSubmarinePositionLoader.Load(data);

        foreach (double position in crabHorizontalPositions)
        {
            TestContext.WriteLine(position);
        }

        // Act

        //Assert
        Assert.IsNotNull(data);
        Assert.IsNotEmpty(crabHorizontalPositions);
    }

    private static IEnumerable<TestCaseData> InputsForPartA
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day7Sample, 37);
            yield return new TestCaseData(Aoc2021Data.Day7, 335330);
        }
    }

    [TestCaseSource(nameof(InputsForPartA))]
    public void When_InputData_PartA_Fuel_Costs_Should_Be(string inputData, int expectedFuelCosts)
    {
        // Arrange
        var crabPositions = CrabSubmarinePositionLoader.Load(inputData);

        // Act
        double fuelCosts = new CrabSubmarinePositionOptimizer(crabPositions).CalculateFuelCostsToLineUpHorizontally();

        //Assert
        Assert.AreEqual(expectedFuelCosts, fuelCosts);
    }

    private static IEnumerable<TestCaseData> InputsForPartB
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day7Sample, 168);
            yield return new TestCaseData(Aoc2021Data.Day7, 92439766);
        }
    }

    [TestCaseSource(nameof(InputsForPartB))]
    public void When_InputData_PartA_Real_Fuel_Costs_Should_Be(string inputData, int expectedFuelCosts)
    {
        // Arrange
        var crabPositions = CrabSubmarinePositionLoader.Load(inputData);

        // Act
        var fuelCosts = new CrabSubmarinePositionOptimizer(crabPositions).CalculateRealFuelCostsToLineUpHorizontally();

        //Assert
        Assert.AreEqual(expectedFuelCosts, fuelCosts);
    }
}

public class CrabSubmarinePositionOptimizer
{
    private readonly List<double> _crabSubmarinePositions;

    public CrabSubmarinePositionOptimizer(List<double> crabSubmarinePositions)
    {
        _crabSubmarinePositions = crabSubmarinePositions;
    }

    public double CalculateFuelCostsToLineUpHorizontally()
    {
        double fuelRequired = 0;

        double median = _crabSubmarinePositions.Median();
        
        foreach (double crabPosition in _crabSubmarinePositions)
        {
            fuelRequired += Math.Abs(median - crabPosition);
        }

        return fuelRequired;
    }

    public double CalculateRealFuelCostsToLineUpHorizontally()
    {
        // find the average of all of the crab sub positions
        var averagePosition = (int)Math.Round(_crabSubmarinePositions.Average());

        // calculate the costs of moving to the average position
        double totalFuelCostsAverage = CalculateFuelCosts(averagePosition);
        TestContext.WriteLine($"Average Costs: {totalFuelCostsAverage}");

        // start moving from the average position, both up (+1) and down (-1) and calculate costs for that
        // position and continue until you find the lowest costs and return it
        int position = averagePosition;
        double nextFuelCost = totalFuelCostsAverage;
        double lowestFuelCost;
        do
        {
            lowestFuelCost = nextFuelCost;
            nextFuelCost = CalculateFuelCosts(--position);
            TestContext.WriteLine($"Position: {position} - MinusOne Costs: {nextFuelCost}");
        } while (nextFuelCost < lowestFuelCost);
        
        position = averagePosition;
        nextFuelCost = lowestFuelCost;
        do
        {
            lowestFuelCost = nextFuelCost;
            nextFuelCost = CalculateFuelCosts(++position);
            TestContext.WriteLine($"Position: {position} - PlusOne Costs: {nextFuelCost}");
        } while (nextFuelCost < lowestFuelCost);
        
        return lowestFuelCost;
    }

    private double CalculateFuelCosts(int position)
    {
        double totalFuelCosts = 0;
        TestContext.WriteLine($"Selected AVG Position: {position}");

        foreach (double crabPosition in _crabSubmarinePositions)
        {
            //N * (N - 1) / 2;
            var positionDifference = Math.Abs(position - crabPosition) + 1;
            var fuelCosts = positionDifference * ((positionDifference - 1) / 2);
            totalFuelCosts += fuelCosts;
            //TestContext.WriteLine($"    Crab position: {crabPosition.ToString().PadLeft(2)} - Position diff: {positionDifference} - Fuel Cost: {fuelCosts}");
        }

        return totalFuelCosts;
    }
}

public class CrabSubmarinePositionLoader
{
    public static List<double> Load(string data)
    {
        return data.Split(",").Select(Convert.ToDouble).ToList();
    }
}
