using System;
using System.Collections.Generic;
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
        var data = ChitonRiskLevelLoader.Load(Aoc2021Data.Day15Sample);

        //Assert
        Assert.IsNotNull(data);
    }


    private static IEnumerable<TestCaseData> InputsForPartA
    {
        get
        {
            yield return new TestCaseData("12\r\n34", 6);
            yield return new TestCaseData("123\r\n456\r\n789", 20);
            yield return new TestCaseData(Aoc2021Data.Day15Sample, 40);
            //yield return new TestCaseData(Aoc2021Data.Day15, 2988);
        }
    }

    [TestCaseSource(nameof(InputsForPartA))]
    public void When_Sample_InputData_PartA_Total_Risk_Should_Be(string inputData, long expectedTotalRisk)
    {
        // Arrange
        var riskData = ChitonRiskLevelLoader.Load(inputData);

        // Act
        //long totalRisk = new ChitonRiskLevelOptimizer(riskData).GetLowestTotalRisk();

        //Assert
        //Assert.AreEqual(expectedTotalRisk, totalRisk);
    }
}

public class RiskLevelTracker
{
    public bool IsSuccessfulPath { get; set; }

    public long? AccumulatedRisk { get; set; }
}

public class ChitonRiskLevelOptimizer
{
    private readonly int[,] _riskData;
    private readonly int _columnLength;
    private readonly int _rowLength;
    private readonly int _start;
    private readonly int _end;
    private int NumberOfVertices => _columnLength * _rowLength;

    public ChitonRiskLevelOptimizer(int[,] riskData)
    {
        _riskData = riskData;
        _columnLength = _riskData.GetLength(0);
        _rowLength = _riskData.GetLength(1);
        _start = _riskData[0, 0];
        _end = _riskData[_columnLength - 1, _rowLength - 1];
    }

    public long GetLowestTotalRisk()
    {
        return FindLowestTotalRisk(0, 0, new bool[_columnLength, _rowLength]).AccumulatedRisk ?? 0;
    }

    private RiskLevelTracker FindLowestTotalRisk(int columnTo, int rowTo, bool[,] visitedPoints)
    {
        //TestContext.WriteLine($"");
        //TestContext.WriteLine($"");
        // if this is an out of bounds point, then return
        if (columnTo < 0 || rowTo < 0 || columnTo >= _columnLength || rowTo >= _rowLength)
        {
            return null;
        }
        // if this is a point previously visited, then return
        if (visitedPoints[columnTo, rowTo])
        {
            //visitedPoints[columnTo, rowTo] = false;
            return null;
        }
        visitedPoints[columnTo, rowTo] = true;
        //TestContext.WriteLine($"Processing riskGrid[{columnTo},{rowTo}] with value: {_riskData[columnTo, rowTo]}");

        if (columnTo == _columnLength - 1 && rowTo == _rowLength - 1)
        {
            //TestContext.WriteLine($"   Found the successful path - Exiting from {_riskData[columnTo, rowTo]}");
            visitedPoints[columnTo, rowTo] = false;
            return new RiskLevelTracker()
            {
                AccumulatedRisk = _riskData[columnTo, rowTo],
                IsSuccessfulPath = true
            };
        }

        List<RiskLevelTracker> riskValues = new();

        // check right
        riskValues.Add(FindLowestTotalRisk(columnTo + 1, rowTo, visitedPoints));

        // check down
        riskValues.Add(FindLowestTotalRisk(columnTo, rowTo + 1, visitedPoints));

        // check left
        riskValues.Add(FindLowestTotalRisk(columnTo - 1, rowTo, visitedPoints));

        // check top
        riskValues.Add(FindLowestTotalRisk(columnTo, rowTo - 1, visitedPoints));

        RiskLevelTracker? bestRiskValue = riskValues.Where(x => x is { AccumulatedRisk: { }, IsSuccessfulPath: true }).MinBy(y => y.AccumulatedRisk);

        if (bestRiskValue != null)
        {
            bestRiskValue.AccumulatedRisk += _riskData[columnTo, rowTo];
        }

        visitedPoints[columnTo, rowTo] = false;
        //TestContext.WriteLine($"   Exiting from {_riskData[columnTo, rowTo]}");
        return bestRiskValue;
    }

}

public class ChitonRiskLevelLoader
{
    public static Node[,] Load(string data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        int rowCount = inputData.Count;
        int columnCount = inputData[0].Length;

        var gridOfRiskLevel = new Node[rowCount, columnCount];

        Graph graph = new();

        // NOTE: We could create a recursive routine to load up the graph with nodes and their neighbors if we wanted to (I think)
        // start at 0,0, create a new node, then proceed to add neighbors, if the neighbor isn't a node yet, then new it up, then proceed to add neighbors, etc.
        // you have to be able to traverse the data as if it were a grid (row,column), and you would have to be able to uniquely identify each node so that you
        // could know if a node had been created for it and know it's distance
        // therefore, should the "name" of each node be its position in the grid (3,5)?

        // build out grid of Nodes and add each one to the graph
        for (var row = 0; row < rowCount; row++)
        {
            var rowData = inputData[row];
            for (var column = 0; column < columnCount; column++)
            {
                gridOfRiskLevel[row, column] = new Node(rowData[column].ToString(), Convert.ToInt32(rowData[column].ToString()));
                graph.Add(gridOfRiskLevel[row, column]);
                TestContext.Write(gridOfRiskLevel[row, column].GetName().PadRight(2));
            }
            TestContext.WriteLine();
        }

        // load up all of the possible neighbors for each node in the graph
        for (var row = 0; row < rowCount; row++)
        {
            var rowData = inputData[row];
            for (var column = 0; column < columnCount; column++)
            {
                // top
                Node itemNode;

                if (row > 0)
                {
                    itemNode = gridOfRiskLevel[row - 1, column];
                    gridOfRiskLevel[row, column].AddNeighbor(itemNode, itemNode.Risk);
                }
                // right
                if (column < columnCount - 1)
                {
                    itemNode = gridOfRiskLevel[row, column + 1];
                    gridOfRiskLevel[row, column].AddNeighbor(itemNode, itemNode.Risk);
                }
                // bottom
                if (row < rowCount - 1)
                {
                    itemNode = gridOfRiskLevel[row + 1, column];
                    gridOfRiskLevel[row, column].AddNeighbor(itemNode, itemNode.Risk);
                }
                // left
                if (column > 0)
                {
                    itemNode = gridOfRiskLevel[row, column - 1];
                    gridOfRiskLevel[row, column].AddNeighbor(itemNode, itemNode.Risk);
                }
            }
        }
        
        return gridOfRiskLevel;
    }
}

class RiskCalculator
{
    readonly Dictionary<Node, int> _distances;
    readonly Dictionary<Node, Node> _routes;
    readonly Graph _graph;
    readonly List<Node> _allNodes;

    public RiskCalculator(Graph g)
    {
        this._graph = g;
        this._allNodes = g.GetNodes();
        _distances = SetDistances();
        _routes = SetRoutes();
    }

    public void Calculate(Node source, Node destination)
    {
        _distances[source] = 0;

        while (_allNodes.ToList().Count != 0)
        {
            Node LeastExpensiveNode = GetLeastExpensiveNode();
            ExamineConnections(LeastExpensiveNode);
            _allNodes.Remove(LeastExpensiveNode);
        }
        Print(source, destination);
    }

    private void Print(Node Source, Node Destination)
    {
        Console.WriteLine($"The least possible cost for flying from {Source.GetName()} to {Destination.GetName()} is: {_distances[Destination]} $");
        PrintLeg(Destination);
        Console.ReadKey();
    }

    private void PrintLeg(Node d)
    {
        if (_routes[d] == null)
            return;
        Console.WriteLine($"{d.GetName()} <-- {_routes[d].GetName()}");
        PrintLeg(_routes[d]);
    }

    private void ExamineConnections(Node n)
    {
        foreach (var neighbor in n.GetNeighbors())
        {
            if (_distances[n] + neighbor.Value < _distances[neighbor.Key])
            {
                _distances[neighbor.Key] = neighbor.Value + _distances[n];
                _routes[neighbor.Key] = n;
            }
        }
    }

    private Node GetLeastExpensiveNode()
    {
        Node LeastExpensive = _allNodes.FirstOrDefault();

        foreach (var n in _allNodes)
        {
            if (_distances[n] < _distances[LeastExpensive])
                LeastExpensive = n;
        }

        return LeastExpensive;
    }

    private Dictionary<Node, int> SetDistances()
    {
        Dictionary<Node, int> Distances = new();

        foreach (Node n in _graph.GetNodes())
        {
            Distances.Add(n, int.MaxValue);
        }
        return Distances;
    }

    private Dictionary<Node, Node> SetRoutes()
    {
        Dictionary<Node, Node> Routes = new();

        foreach (Node n in _graph.GetNodes())
        {
            Routes.Add(n, null);
        }
        return Routes;
    }
}

public class Node
{

    public Node(string nodeName, int risk)
    {
        Name = nodeName;
        Risk = risk;
        Neighbors = new Dictionary<Node, int>();
    }

    public void AddNeighbor(Node n, int risk)
    {
        Neighbors.Add(n, risk);
    }

    public string Name { get; }

    public string GetName()
    {
        return Name;
    }

    public Dictionary<Node, int> Neighbors { get; }

    public int Risk { get; set; }

    public Dictionary<Node, int> GetNeighbors()
    {
        return Neighbors;
    }
}

public class Graph
{
    private readonly List<Node> _nodes;

    public Graph()
    {
        _nodes = new List<Node>();
    }

    public void Add(Node n)
    {
        _nodes.Add(n);
    }

    public void Remove(Node n)
    {
        _nodes.Remove(n);
    }

    public List<Node> GetNodes()
    {
        return _nodes.ToList();
    }

    public int GetCount()
    {
        return _nodes.Count;
    }
}

