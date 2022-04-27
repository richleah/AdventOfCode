using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/1

[TestFixture]
public class Day_01
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day_1_Sample()
    {
        var sonar = JsonSerializer.Deserialize<SonarMeasurements>(Aoc2021Data.Day1Sample);
        Assert.AreEqual(7, CountDepthIncreases(sonar.Depths));
    }

    [Test]
    public void Day_1_exercise()
    {
        var sonar = JsonSerializer.Deserialize<SonarMeasurements>(Aoc2021Data.Day1);
        Assert.AreEqual(1195, CountDepthIncreases(sonar.Depths));
    }

    public static int CountDepthIncreases(List<int> depths)
    {
        int depthIncreaseCount = 0;
        for (int index = 1; index < depths.Count; index++)
        {
            int currentDepth = depths[index];
            int previousDepth = depths[index - 1];
            TestContext.Write($"current depth: {currentDepth}, previous depth: {previousDepth} => ");

            if (currentDepth > previousDepth)
            {
                TestContext.WriteLine($"increase");
                depthIncreaseCount++;
            }
            else
            {
                TestContext.WriteLine($"decrease");
            }
        }
        return depthIncreaseCount;
    }

    [Test]
    public void Day_1b_Sample()
    {
        var sonar = JsonSerializer.Deserialize<SonarMeasurements>(Aoc2021Data.Day1Sample);
        Assert.AreEqual(5, CountDepthIncreasesV2(sonar.Depths));
    }

    [Test]
    public void Day_1b_Exercise()
    {
        var sonar = JsonSerializer.Deserialize<SonarMeasurements>(Aoc2021Data.Day1);
        Assert.AreEqual(1235, CountDepthIncreasesV2(sonar.Depths));
    }

    public static int CountDepthIncreasesV2(List<int> depths)
    {
        int depthIncreaseCount = 0;
        for (int index = 3; index < depths.Count; index++)
        {
            int currentDepth = depths[index] + depths[index - 1] + depths[index - 2];
            int previousDepth = depths[index - 1] + depths[index - 2] + depths[index - 3];
            TestContext.Write($"current depth: {currentDepth}, previous depth: {previousDepth} => ");

            if (currentDepth > previousDepth)
            {
                TestContext.WriteLine($"increase");
                depthIncreaseCount++;
            }
            else
            {
                TestContext.WriteLine($"decrease");
            }
        }
        return depthIncreaseCount;
    }

    public class SonarMeasurements
    {
        public SonarMeasurements()
        {
            Depths = new();
        }

        [JsonPropertyName("depths")]
        public List<int> Depths { get; set; }
    }

}