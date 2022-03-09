using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture]
public class Day_4
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        int boardSize = 5;
        string? data = Aoc2021Data.Day4Sample;
        string[] dataLines = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        var numbersToCall = dataLines[0].Split(",").ToList();

        // remove the numbers to call from the data so that you can process the boards
        var boardInput = dataLines.Skip(1).ToArray();
        
        foreach (string line in boardInput)
        {
            TestContext.WriteLine(line);
        }

        // Act
        //var diagnostics = diagData.EnumerateArray().Select(diagDatum => diagDatum.ToString()).ToList();

        //Assert
        //Assert.IsNotNull(diagnostics);
        //Assert.IsNotEmpty(diagnostics);
    }

    [Test]
    public void Should_generate_gamma_rate_of_22_for_sample_data()
    {
        // Arrange
        //JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        //JsonElement diagnosticData = document.RootElement.GetProperty("data");
        //var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        //var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        //Assert.AreEqual(22, processor.GammaRate());
    }

    public class Board
    { 
        private readonly int _boardSize;
        private readonly BoardSpot[,] _board;

        public Board(IReadOnlyCollection<string> rowsData)
        {
            _boardSize = rowsData.Count;
            _board = new BoardSpot[_boardSize, _boardSize];

            var row = 0;
            foreach (string rowData in rowsData)
            {
                var column = 0;
                string[] rowValues = rowData.Split(" ", StringSplitOptions.TrimEntries);
                foreach (string rowValue in rowValues)
                {
                    _board[row, column++] = new BoardSpot() {Value = Convert.ToInt32(rowValue)};
                }

                row++;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var columnCount = 0;
            foreach (BoardSpot boardSpot in _board)
            {
                columnCount++;
                if (columnCount > _boardSize)
                {
                    sb.AppendLine();
                    columnCount = 0;
                }

                sb.Append($" {boardSpot.Value}");
            }
            return sb.ToString();
        }

        public class BoardSpot
        {
            public int Value { get; set; }
            public bool IsMarked { get; set; }
        }
    }
}