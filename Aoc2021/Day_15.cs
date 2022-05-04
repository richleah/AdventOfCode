using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

public class Day_15
{
    [Test]
    public void Should_load_sample_data()
    {
        // Arrange

        // Act
        object data = ChitonRiskLevelLoader.Load(Aoc2021Data.Day15Sample);

        //Assert
        Assert.IsNotNull(data);
    }

}

public class ChitonRiskLevelLoader
{
    public static object Load(string data)
    {
        return null;
    }
}