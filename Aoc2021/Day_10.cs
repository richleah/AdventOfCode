using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

[TestFixture]
public class Day_10
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string[] data = Aoc2021Data.Day10Sample.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        foreach (string dataLine in data)
        {
            foreach (char character in dataLine)
            {
                TestContext.Write(character.ToString().PadRight(2));
            }
            TestContext.WriteLine();
        }

        //Assert
        Assert.IsNotNull(data);

        //Assert.IsNotEmpty(inputData);
    }

    [Test]
    public void When_Sample_Data_Syntax_Error_Score_Should_Be_26397()
    {
        // Arrange
        string[] data = Aoc2021Data.Day10Sample.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        double errorScore = new NavigationSystem(data).CalculateNavigationScores().SyntaxErrorScore;

        //Assert
        Assert.AreEqual(26397, errorScore);
    }

    [Test]
    public void When_Real_Data_Syntax_Error_Score_Should_Be_392367()
    {
        // Arrange
        string[] data = Aoc2021Data.Day10.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        double errorScore = new NavigationSystem(data).CalculateNavigationScores().SyntaxErrorScore;

        //Assert
        Assert.AreEqual(392367, errorScore);
    }

    [Test]
    public void When_Sample_Data_Auto_Complete_Score_Should_Be_288957()
    {
        // Arrange
        string[] data = Aoc2021Data.Day10Sample.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        double errorScore = new NavigationSystem(data).CalculateNavigationScores().AutoCompleteScore;

        //Assert
        Assert.AreEqual(288957, errorScore);
    }

    [Test]
    public void When_Real_Data_Syntax_Error_Score_Should_Be_2192104158()
    {
        // Arrange
        string[] data = Aoc2021Data.Day10.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        double errorScore = new NavigationSystem(data).CalculateNavigationScores().AutoCompleteScore;

        //Assert
        Assert.AreEqual(2192104158, errorScore);
    }

    public class NavCharacters
    {
        public const string OpenParen = "(";
        public const string OpenSquare = "[";
        public const string OpenCurly = "{";
        public const string OpenAngle = "<";
        public static readonly string[] AllOpen = { OpenParen, OpenSquare, OpenCurly, OpenAngle };
        public const string CloseParen = ")";
        public const string CloseSquare = "]";
        public const string CloseCurly = "}";
        public const string CloseAngle = ">";
        public static readonly string[] CloseNavCharacters = { CloseParen, CloseSquare, CloseCurly, CloseAngle };

    }

    public class NavigationSystem
    {
        private readonly string[] _inputData;
        public NavigationSystem(string[] inputData)
        {
            _inputData = inputData;
        }

        public Scores CalculateNavigationScores()
        {
            double syntaxErrorScore = 0;
            List<double> autoCompleteScore = new();

            foreach (string dataLine in _inputData)
            {
                var characterCountLeft = dataLine.Length;
                var lineStack = new Stack<string?>();
                foreach (char character in dataLine)
                {
                    characterCountLeft -= 1;
                    var isLastCharacterInDataLine = characterCountLeft == 0;
                    bool isCharacterPoppedOrPushed = false;
                    lineStack.TryPeek(out string? topOfStackCharacter);
                    if (NavCharacters.AllOpen.Contains(character.ToString()))
                    {
                        // if it is an open character simply push it on the stack
                        //TestContext.Write($"Pushed: {character,-2}");
                        lineStack.Push(character.ToString());
                        isCharacterPoppedOrPushed = true;
                    }

                    // else if it is a close character, verify that the character matches the top character on the stack
                    // if it is, then pop and continue processing
                    // if it isn't then hold the current character and stop processing this line
                    if (character.ToString() == NavCharacters.CloseParen && topOfStackCharacter == NavCharacters.OpenParen
                        || character.ToString() == NavCharacters.CloseSquare && topOfStackCharacter == NavCharacters.OpenSquare
                        || character.ToString() == NavCharacters.CloseCurly && topOfStackCharacter == NavCharacters.OpenCurly
                        || character.ToString() == NavCharacters.CloseAngle && topOfStackCharacter == NavCharacters.OpenAngle)
                    {
                        //TestContext.Write($"Popped: {character,-2}");
                        lineStack.Pop();
                        isCharacterPoppedOrPushed = true;
                    }

                    //TestContext.WriteLine($"Stack: {string.Join("", lineStack.Reverse())}; CurrentCharacter: {character}; PushedPopped?: {isCharacterPoppedOrPushed}");

                    // need to figure out where to do this our
                    if (isLastCharacterInDataLine && lineStack.Count > 0)
                    {
                        // Line incomplete
                        TestContext.WriteLine($"Line Incomplete! Stack: {string.Join("", lineStack.Reverse())}");
                        autoCompleteScore.Add(CalculateAutoCompleteScore(lineStack));
                    }

                    if (isCharacterPoppedOrPushed)
                    {
                        continue;
                    }

                    switch (character.ToString())
                    {
                        case NavCharacters.CloseParen:
                            syntaxErrorScore += 3;
                            break;
                        case NavCharacters.CloseSquare:
                            syntaxErrorScore += 57;
                            break;
                        case NavCharacters.CloseCurly:
                            syntaxErrorScore += 1197;
                            break;
                        case NavCharacters.CloseAngle:
                            syntaxErrorScore += 25137;
                            break;
                    }

                    // we have had a mismatch in openning/closing characters
                    TestContext.WriteLine($"Line Corrupt! Last character detected: {character}");
                    break;
                }
                TestContext.WriteLine();
            }

            var sortedList = autoCompleteScore.OrderBy(x => x).ToList();
            int middleIndex = sortedList.Count() / 2;
            var winningAutoCompleteScore = sortedList[middleIndex];

            return new Scores(winningAutoCompleteScore, syntaxErrorScore);
        }

        private double CalculateAutoCompleteScore(Stack<string?> lineStack)
        {
            double autoCompleteScore = 0;
            foreach (string? character in lineStack)
            {
                autoCompleteScore *= 5;
                switch (character.ToString())
                {
                    case NavCharacters.OpenParen:
                        autoCompleteScore += 1;
                        break;
                    case NavCharacters.OpenSquare:
                        autoCompleteScore += 2;
                        break;
                    case NavCharacters.OpenCurly:
                        autoCompleteScore += 3;
                        break;
                    case NavCharacters.OpenAngle:
                        autoCompleteScore += 4;
                        break;
                }

            }

            return autoCompleteScore;
        }
    }

    public class Scores
    {
        public Scores(double autoCompleteScore, double syntaxErrorScore)
        {
            AutoCompleteScore = autoCompleteScore;
            SyntaxErrorScore = syntaxErrorScore;
        }

        public double AutoCompleteScore { get; set; }

        public double SyntaxErrorScore { get; set; }
    }
}