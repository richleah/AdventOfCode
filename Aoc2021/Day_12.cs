using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

public class Day_12
{
    private static IEnumerable<TestCaseData> inputsForPartA
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day12Sample1, 10);
            yield return new TestCaseData(Aoc2021Data.Day12Sample2, 19);
            yield return new TestCaseData(Aoc2021Data.Day12Sample3, 226);
            yield return new TestCaseData(Aoc2021Data.Day12, 4338);
        }
    }

    private static IEnumerable<TestCaseData> inputsForPartB
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day12Sample1, 36);
            yield return new TestCaseData(Aoc2021Data.Day12Sample2, 103);
            yield return new TestCaseData(Aoc2021Data.Day12Sample3, 3509);
            yield return new TestCaseData(Aoc2021Data.Day12, 114189);
        }
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string[] data = Aoc2021Data.Day12Sample1.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        CaveMapLoader.Load(Aoc2021Data.Day12Sample1);

        //Assert
        Assert.IsNotNull(data);

        //Assert.IsNotEmpty(inputData);
    }

    [TestCaseSource(nameof(inputsForPartA))]
    public void When_InputData_PartA_Paths_Should_Be_ExpectedPaths(string inputData, int expectedPaths)
    {
        // Arrange
        CaveMap caveMap = CaveMapLoader.Load(inputData);

        // Act
        int paths = new CaveMapPathFinder(caveMap).CountAllPossiblePaths();

        //Assert
        Assert.AreEqual(expectedPaths, paths);
    }

    [TestCaseSource(nameof(inputsForPartB))]
    public void When_InputData_PartB_Paths_Should_Be_ExpectedPaths(string inputData, int expectedPaths)
    {
        // Arrange
        CaveMap caveMap = CaveMapLoader.Load(inputData);

        // Act
        int paths = new CaveMapPathFinder(caveMap).CountAllPossiblePathsAllowingForOneSmallCaveToHaveASecondVisit();

        //Assert
        Assert.AreEqual(expectedPaths, paths);
    }
}

public class CaveMapPathFinder
{
    private readonly CaveMap _caveMap;

    public CaveMapPathFinder(CaveMap caveMap)
    {
        _caveMap = caveMap;
    }

    public int CountAllPossiblePaths(bool allowForOneSmallCaveToHaveASecondVisit = false)
    {
        TestContext.WriteLine();
        CaveNode? smallCaveToAllowASecondVisit = null;

        return SpelunkSuccessfulPaths(_caveMap.StartCave, new Stack<CaveNode>(), smallCaveToAllowASecondVisit);
    }

    public int CountAllPossiblePathsAllowingForOneSmallCaveToHaveASecondVisit()
    {
        TestContext.WriteLine();
        CaveNode? smallCaveToAllowASecondVisit = null;

        return SpelunkSuccessfulPaths(_caveMap.StartCave, new Stack<CaveNode>(), smallCaveToAllowASecondVisit, true);
    }

    private static int SpelunkSuccessfulPaths(CaveNode currentCave, Stack<CaveNode> previouslyVisitedCavePath, CaveNode? smallCaveToAllowASecondVisit, bool allowForOneSmallCaveToHaveASecondVisit = false)
    {
        bool isAnyPreviouslyVisitedSmallCageBeenVisitedTwice = previouslyVisitedCavePath.Where(x => x.CanOnlyBeVisitedOnce).GroupBy(y => y.Name).Any(z => z.Count() == 2);

        if (allowForOneSmallCaveToHaveASecondVisit && currentCave.Name != "start" && currentCave.Name != "end"
            && currentCave.CanOnlyBeVisitedOnce && !isAnyPreviouslyVisitedSmallCageBeenVisitedTwice)
        {
            // only add a small cave that can have 2 visits when you encounter a small cave
            // AND there are no other small caves that have been previously visited twice
            //TestContext.WriteLine($"     -----Setting the smallCaveToAllowASecondVisit to {currentCave.Name}");
            smallCaveToAllowASecondVisit = currentCave;
        }

        TestContext.WriteLine($"Path: {string.Join(",", previouslyVisitedCavePath.Select(x => x.Name).Reverse())},{currentCave.Name} - Second Visit Cave: {smallCaveToAllowASecondVisit?.Name ?? "None"}");
        var successfulPaths = 0;

        if (currentCave.Name == "end")
        {
            // if this is the end cave, then we exit with successful path
            TestContext.WriteLine("    Successful Path!");

            return 1;
        }

        if ((previouslyVisitedCavePath.Any()
             && currentCave.Name == "start")
            || currentCave.Name == "end" // stop/return if we are are at the start or end cave and we have visited other caves already
            || ((smallCaveToAllowASecondVisit == null
                 || smallCaveToAllowASecondVisit.Name != currentCave.Name)
                && currentCave.CanOnlyBeVisitedOnce && previouslyVisitedCavePath.Any(x => x.Name == currentCave.Name))
            || (allowForOneSmallCaveToHaveASecondVisit
                && smallCaveToAllowASecondVisit != null
                && smallCaveToAllowASecondVisit.Name == currentCave.Name
                && previouslyVisitedCavePath.Count(x => x.Name == currentCave.Name) >= 2)) // stop/return if we have arrived at a cave that we have allowed 2 stops at, but we are now past that second stop
        {
            // if this cave can only be visited once and it is in the path
            // traveled thus far, then we need to stop traversing this path
            //TestContext.WriteLine($"     Dead end!");
            return 0;
        }

        //TestContext.WriteLine();
        previouslyVisitedCavePath.Push(currentCave);

        foreach (var connectedCave in currentCave.ConnectedCaves)
        {
            successfulPaths += SpelunkSuccessfulPaths(connectedCave.Value, previouslyVisitedCavePath, smallCaveToAllowASecondVisit, allowForOneSmallCaveToHaveASecondVisit);
        }

        CaveNode caveThatWasPopped = previouslyVisitedCavePath.Pop();

        //TestContext.WriteLine($"-----Popping: {caveThatWasPopped.Name}     Path: {string.Join(",", previouslyVisitedCavePath.Select(x => x.Name).Reverse())}");

        return successfulPaths;
    }
}

public class CaveMapLoader
{
    public static CaveMap Load(string? data)
    {
        Dictionary<string, CaveNode> caveList = new();

        string[] inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        foreach (string lineData in inputData)
        {
            CaveNode caveA;
            CaveNode caveB;

            string[] caveConnections = lineData.Split("-", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);
            string caveAName = caveConnections[0];
            string caveBName = caveConnections[1];

            if (!caveList.ContainsKey(caveAName))
            {
                caveA = new CaveNode(caveAName);
                caveList.Add(caveAName, caveA);
            }

            caveA = caveList[caveAName];

            if (!caveList.ContainsKey(caveBName))
            {
                caveB = new CaveNode(caveBName);
                caveList.Add(caveBName, caveB);
            }

            caveB = caveList[caveBName];

            caveB.ConnectedCaves.Add(caveAName, caveA);
            caveA.ConnectedCaves.Add(caveBName, caveB);
        }

        foreach (var caveNode in caveList)
        {
            TestContext.WriteLine($"Cave: {caveNode.Key} - CanOnlyBeVisitedOnce: {caveNode.Value.CanOnlyBeVisitedOnce}");

            foreach (var connectedCave in caveNode.Value.ConnectedCaves)
            {
                TestContext.WriteLine($"     - Cave: {connectedCave.Key}");
            }
        }

        return new CaveMap(caveList);
    }
}

public class CaveMap
{
    private readonly Dictionary<string, CaveNode> _caveList;

    public CaveMap(Dictionary<string, CaveNode> caveList)
    {
        _caveList = caveList;
    }

    public CaveNode StartCave => _caveList["start"];

    public CaveNode this[string index] => _caveList[index];
}

public class CaveNode
{
    public CaveNode(string name)
    {
        Name = name;
        ConnectedCaves = new Dictionary<string, CaveNode>();
    }

    public string Name { get; set; }

    public bool CanOnlyBeVisitedOnce => Name.All(char.IsLower);

    public Dictionary<string, CaveNode> ConnectedCaves { get; set; }
}