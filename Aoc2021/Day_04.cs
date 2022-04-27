using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture]
public class Day_04
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
        var bingoBoardsAndDrawNumbers = BingoDataLoader.Load(Aoc2021Data.Day4);

        TestContext.WriteLine(string.Join(",", bingoBoardsAndDrawNumbers.DrawNumbers));
        TestContext.WriteLine();

        foreach (Board board in bingoBoardsAndDrawNumbers.Boards)
        {
            TestContext.WriteLine(board.ToString());
        }

        //Assert
        Assert.IsNotNull(bingoBoardsAndDrawNumbers.DrawNumbers);
        Assert.IsNotNull(bingoBoardsAndDrawNumbers.Boards);
    }

    private static IEnumerable<TestCaseData> inputsForPartA
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day4Sample, 4512);
            yield return new TestCaseData(Aoc2021Data.Day4, 49860);
        }
    }

    [TestCaseSource(nameof(inputsForPartA))]
    public void When_InputData_PartA_Winning_Board_Total_Should_Be(string inputData, int expectedWinningScore)
    {
        // Arrange
        var bingoBoardsAndDrawNumbers = BingoDataLoader.Load(inputData);

        // Act
        var winningScore = new BingoGameManager(bingoBoardsAndDrawNumbers).GetScoreOfFirstWinningBoard();

        //Assert
        Assert.AreEqual(expectedWinningScore, winningScore);
    }

    private static IEnumerable<TestCaseData> inputsForPartB
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day4Sample, 1924);
            yield return new TestCaseData(Aoc2021Data.Day4, 24628);
        }
    }

    [TestCaseSource(nameof(inputsForPartB))]
    public void When_InputData_PartB_Winning_Board_Total_Should_Be(string inputData, int expectedWinningScore)
    {
        // Arrange
        var bingoBoardsAndDrawNumbers = BingoDataLoader.Load(inputData);

        // Act
        var winningScore = new BingoGameManager(bingoBoardsAndDrawNumbers).GetScoreOfLastWinningBoard();

        //Assert
        Assert.AreEqual(expectedWinningScore, winningScore);
    }

}

public class BingoGameManager
{
    private BingoBoardsAndDrawNumbers _bingoBoardsAndDrawNumbers;

    public BingoGameManager(BingoBoardsAndDrawNumbers bingoBoardsAndDrawNumbers)
    {
        _bingoBoardsAndDrawNumbers = bingoBoardsAndDrawNumbers;
    }

    public double GetScoreOfFirstWinningBoard()
    {
        foreach (int drawNumber in _bingoBoardsAndDrawNumbers.DrawNumbers)
        {
            _bingoBoardsAndDrawNumbers.MarkDrawNumber(drawNumber);

            if (_bingoBoardsAndDrawNumbers.HasWinningBoard())
            {
                return _bingoBoardsAndDrawNumbers.Boards.First(x => x.IsWinner()).WinningBoardTotal() * drawNumber;
            }
        }

        return 0;
    }

    public double GetScoreOfLastWinningBoard()
    {
        foreach (int drawNumber in _bingoBoardsAndDrawNumbers.DrawNumbers)
        {
            _bingoBoardsAndDrawNumbers.MarkDrawNumber(drawNumber);

            var lastWinningBoard = _bingoBoardsAndDrawNumbers.LastWinningBoard();
            if (lastWinningBoard != null)
            {
                return lastWinningBoard.WinningBoardTotal() * drawNumber;
            }
        }

        return 0;
    }
}

public class Board
{
    private readonly int _boardSize = 5;
    private readonly BoardSpot[,] _board;
    private bool _isWon = false;
    private bool _lastBoardToWin;

    public Board(BoardSpot[,] board)
    {
        _board = board;
    }

    public bool IsWinner()
    {
        if (_isWon)
        {
            return true;
        }
        else if (_board[0, 0].IsMarked && _board[1, 0].IsMarked && _board[2, 0].IsMarked && _board[3, 0].IsMarked && _board[4, 0].IsMarked
                 || _board[0, 1].IsMarked && _board[1, 1].IsMarked && _board[2, 1].IsMarked && _board[3, 1].IsMarked && _board[4, 1].IsMarked
                 || _board[0, 2].IsMarked && _board[1, 2].IsMarked && _board[2, 2].IsMarked && _board[3, 2].IsMarked && _board[4, 2].IsMarked
                 || _board[0, 3].IsMarked && _board[1, 3].IsMarked && _board[2, 3].IsMarked && _board[3, 3].IsMarked && _board[4, 3].IsMarked
                 || _board[0, 4].IsMarked && _board[1, 4].IsMarked && _board[2, 4].IsMarked && _board[3, 4].IsMarked && _board[4, 4].IsMarked
                 || _board[0, 0].IsMarked && _board[0, 1].IsMarked && _board[0, 2].IsMarked && _board[0, 3].IsMarked && _board[0, 4].IsMarked
                 || _board[1, 0].IsMarked && _board[1, 1].IsMarked && _board[1, 2].IsMarked && _board[1, 3].IsMarked && _board[1, 4].IsMarked
                 || _board[2, 0].IsMarked && _board[2, 1].IsMarked && _board[2, 2].IsMarked && _board[2, 3].IsMarked && _board[2, 4].IsMarked
                 || _board[3, 0].IsMarked && _board[3, 1].IsMarked && _board[3, 2].IsMarked && _board[3, 3].IsMarked && _board[3, 4].IsMarked
                 || _board[4, 0].IsMarked && _board[4, 1].IsMarked && _board[4, 2].IsMarked && _board[4, 3].IsMarked && _board[4, 4].IsMarked)
        {
            _isWon = true;
            return true;
        };

        return false;
    }

    public int WinningBoardTotal()
    {
        var boardTotal = 0;
        foreach (BoardSpot boardSpot in _board)
        {
            if (boardSpot.IsMarked)
            {
                continue;
            }

            boardTotal += boardSpot.Value;
        }
        return boardTotal;
    }

    public void MarkDrawNumber(int drawNumber)
    {
        foreach (BoardSpot boardSpot in _board)
        {
            if (boardSpot.IsMarked || boardSpot.Value != drawNumber)
            {
                continue;
            }

            boardSpot.IsMarked = true;
            break;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var columnCount = 0;
        foreach (BoardSpot boardSpot in _board)
        {
            sb.Append($"{boardSpot.Value.ToString().PadRight(3)}");
            columnCount++;
            if (columnCount >= _boardSize)
            {
                sb.AppendLine();
                columnCount = 0;
            }
        }
        return sb.ToString();
    }
}

public class BoardSpot
{
    public int Value { get; set; }
    public bool IsMarked { get; set; }
}

public class BingoBoardsAndDrawNumbers
{
    private Board? _lastWinningBoard;

    public BingoBoardsAndDrawNumbers(List<int> drawNumbers, List<Board> boards)
    {
        DrawNumbers = drawNumbers;
        Boards = boards;
    }

    public List<int> DrawNumbers { get; set; }

    public List<Board> Boards { get; set; }

    public bool HasWinningBoard()
    {
        return Boards.Any(x => x.IsWinner());
    }

    public void MarkDrawNumber(int drawNumber)
    {
        foreach (Board board in Boards)
        {
            if (board.IsWinner())
            {
                continue;
            }
            board.MarkDrawNumber(drawNumber);

            if (board.IsWinner())
            {
                // this means it is the last winner
                SetLastWinningBoard(board);
            }
        }
    }

    private void SetLastWinningBoard(Board board)
    {
        _lastWinningBoard = board;
    }

    public Board? LastWinningBoard()
    {
        if (!Boards.All(x => x.IsWinner()))
        {
            return null;
        }

        return _lastWinningBoard;
    }
}

public class BingoDataLoader
{
    public static BingoBoardsAndDrawNumbers Load(string? data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList();

        var drawNumbersDataList = inputData
            .First()
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(x => Convert.ToInt32(x))
            .ToList();

        inputData.RemoveAt(0);

        List<List<string>> boardsDataList = new();
        for (int i = 0; i < inputData.Count; i += 5)
        {
            boardsDataList.Add(inputData.Skip(i).Take(5).ToList());
        }

        List<Board> boardsList = new();
        foreach (var boardRows in boardsDataList)
        {
            var tempBoard = new BoardSpot[5, 5];
            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                List<int> columnData = boardRows[rowIndex].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(y => Convert.ToInt32(y))
                    .ToList();
                for (int colIndex = 0; colIndex < 5; colIndex++)
                {
                    tempBoard[rowIndex, colIndex] = new BoardSpot()
                    {
                        Value = columnData[colIndex]
                    };
                }
            }
            boardsList.Add(new Board(tempBoard));
        }

        return new BingoBoardsAndDrawNumbers(drawNumbersDataList, boardsList);
    }
}
