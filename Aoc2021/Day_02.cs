using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture]
public class Day_02
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day_2_Sample()
    {
        // Arrange
        var directions = JsonSerializer.Deserialize<Directions>(Aoc2021Data.Day2Sample);

        // Act
        var finalPosition = GetPosition(directions.Moves);

        //Assert
        Assert.AreEqual(15, finalPosition.Horizontal);
        Assert.AreEqual(10, finalPosition.Depth);
        finalPosition.Horizontal.Should().Be(15);
        finalPosition.Depth.Should().Be(10);
        Assert.AreEqual(new Position(15, 10), GetPosition(directions.Moves));

    }

    [Test]
    public void Day_2_Exercise()
    {
        // Arrange
        var directions = JsonSerializer.Deserialize<Directions>(Aoc2021Data.Day2);

        // Act
        var finalPosition = GetPosition(directions.Moves);

        // Assert
        Assert.AreEqual(new Position(2063,1005), finalPosition);
        Assert.AreEqual(2073315, finalPosition.Horizontal * finalPosition.Depth);
    }

    public static Position GetPosition(List<Move> moves)
    {
        var position = new Position(0, 0);

        foreach (var move in moves)
        {
            switch (move.Direction)
            {
                case "forward":
                    position.Horizontal += move.Distance;
                    break;
                case "down":
                    position.Depth += move.Distance;
                    break;
                case "up":
                    position.Depth -= move.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
            TestContext.WriteLine($"Move => Direction: {move.Direction}, Distance: {move.Distance}");
            TestContext.WriteLine($"      Position => Horizontal: {position.Horizontal}, Depth: {position.Depth}");
        }
        return position;
    }

    [Test]
    public void Day_2b_Sample()
    {
        var directions = JsonSerializer.Deserialize<Directions>(Aoc2021Data.Day2Sample);
        var finalPosition = GetPositionV2(directions.Moves);
        Assert.AreEqual(new Position(15, 60), finalPosition);
        Assert.AreEqual(900, finalPosition.Horizontal * finalPosition.Depth);

    }

    [Test]
    public void Day_2b_Exercise()
    {
        var directions = JsonSerializer.Deserialize<Directions>(Aoc2021Data.Day2);
        var finalPosition = GetPositionV2(directions.Moves);
        Assert.AreEqual(2063, finalPosition.Horizontal);
        Assert.AreEqual(892056, finalPosition.Depth);

        Assert.AreEqual(new Position(2063, 892056), finalPosition);
        Assert.AreEqual(1840311528, finalPosition.Horizontal * finalPosition.Depth);
    }

    public static Position GetPositionV2(List<Move> moves)
    {
        var position = new Position(0, 0, 0);

        foreach (var move in moves)
        {
            switch (move.Direction)
            {
                case "forward":
                    position.Horizontal += move.Distance;
                    position.Depth += position.Aim * move.Distance;
                    break;
                case "down":
                    position.Aim += move.Distance;
                    break;
                case "up":
                    position.Aim -= move.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
            TestContext.WriteLine($"Move => Direction: {move.Direction}, Distance: {move.Distance}");
            TestContext.WriteLine($"      Position => Horizontal: {position.Horizontal}, Depth: {position.Depth}, Aim: {position.Aim}");
        }
        return position;
    }

    public class Position : IEquatable<Position>
    {
        public Position(int horizontal, int depth)
        {
            Horizontal = horizontal;
            Depth = depth;
        }

        public Position(int horizontal, int depth, int aim)
        {
            Horizontal = horizontal;
            Depth = depth;
            Aim = aim;
        }

        public int Horizontal { get; set; }

        public int Depth { get; set; }

        public int Aim { get; set; }

        public bool Equals(Position? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.Horizontal == this.Horizontal && obj.Depth == this.Depth;
        }
    }

    public class Directions
    {
        public Directions()
        {
            MovesAsText = new();
        }

        [JsonPropertyName("moves")] public List<string> MovesAsText { get; set; }
        
        public List<Move> Moves
        {
            get
            {
                return MovesAsText
                    .Select(moveAsText => moveAsText
                        .Split(' '))
                    .Select(moveText => new Move(moveText[0], Convert.ToInt32(moveText[1])))
                    .ToList();
            }
        }
    }

    public class Move
    {
        public Move()
        {
        }

        public Move(string direction, int distance)
        {
            Direction = direction;
            Distance = distance;
        }

        public string Direction { get; set; }
        public int Distance { get; set; }
    }
}