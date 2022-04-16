using System;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

[TestFixture]
public class Day_11
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string? inputData = Aoc2021Data.Day11Sample;
        string[] data = Aoc2021Data.Day11Sample.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

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
    public void When_Sample_Data_Octopus_Flashes_Should_Be_1656()
    {
        // Arrange
        var octopusGrid = OctoGridLoader.Load(Aoc2021Data.Day11Sample);


        // Act
        double flashes = new DumboOctopusNavigationalSystem(octopusGrid).CountFlashes(100);

        //Assert
        Assert.AreEqual(1656, flashes);
    }

    [Test]
    public void When_Real_Data_Octopus_Flashes_Should_Be_1725()
    {
        // Arrange
        var octopusGrid = OctoGridLoader.Load(Aoc2021Data.Day11);


        // Act
        double flashes = new DumboOctopusNavigationalSystem(octopusGrid).CountFlashes(100);

        //Assert
        Assert.AreEqual(1725, flashes);
    }

    [Test]
    public void When_Sample_Data_Octopus_All_Flash_Should_Be_Step_195()
    {
        // Arrange
        var octopusGrid = OctoGridLoader.Load(Aoc2021Data.Day11Sample);

        // Act
        int step = new DumboOctopusNavigationalSystem(octopusGrid).CalculateStepWhenAllOctopusesFlash();

        //Assert
        Assert.AreEqual(195, step);
    }

    [Test]
    public void When_Real_Data_Octopus_All_Flash_Should_Be_Step_308()
    {
        // Arrange
        var octopusGrid = OctoGridLoader.Load(Aoc2021Data.Day11);

        // Act
        int step = new DumboOctopusNavigationalSystem(octopusGrid).CalculateStepWhenAllOctopusesFlash();

        //Assert
        Assert.AreEqual(308, step);
    }

    public class DumboOctopusNavigationalSystem
    {
        private readonly Octopus[,] _octopusGrid;

        private int RowLength => _octopusGrid.GetLength(0);
        private int ColumnLength => _octopusGrid.GetLength(1);

        public DumboOctopusNavigationalSystem(Octopus[,] octoGrid)
        {
            _octopusGrid = octoGrid;
        }

        public double CountFlashes(int iterations)
        {
            double flashes = 0;

            PrintGrid("Initial Grid");
            for (int i = 0; i < iterations; i++)
            {
                AddOneEnergyLevelToAllOctopuses();

                //PrintGrid("After an AddOneEnergyLevelToAllOctopuses, but before the Flashes are processed");

                flashes += SetOffFlashes();

                //PrintGrid("After an AddOneEnergyLevelToAllOctopuses and Flashes are processed, but before Reset");
                ResetOctopusesThatHaveFlashed();

                PrintGrid($"After AddOneEnergyLevelToAllOctopuses and Flashes is fully complete - Iteration: #{i + 1}");
            }

            return flashes;
        }

        public int CalculateStepWhenAllOctopusesFlash()
        {
            int step = 0;
            bool allOctopusesDidFlash = false;

            do
            {
                step += 1;
                AddOneEnergyLevelToAllOctopuses();

                SetOffFlashes();

                allOctopusesDidFlash = DidAllOctopusesFlash();

                ResetOctopusesThatHaveFlashed();

            } while (!allOctopusesDidFlash);

            return step;
        }

        private void AddOneEnergyLevelToAllOctopuses()
        {
            // this increments all cells by 1
            for (var columnIndex = 0; columnIndex < ColumnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < RowLength; rowIndex++)
                {
                    _octopusGrid[rowIndex, columnIndex].EnergyLevel += 1;
                }
            }
        }

        private double SetOffFlashes()
        {
            double flashes = 0;
            bool flashesContinue;

            do
            {
                flashesContinue = false;

                for (var columnIndex = 0; columnIndex < ColumnLength; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < RowLength; rowIndex++)
                    {
                        var currentOctopus = _octopusGrid[rowIndex, columnIndex];
                        if (currentOctopus.EnergyLevel > 9 && !currentOctopus.HasFlashed)
                        {
                            // if the octopus energy level is greater than 9 and it hasn't yet flashed, then process a flash
                            flashes += 1;
                            currentOctopus.HasFlashed = true;
                            flashesContinue = true;
                            // top
                            if (rowIndex > 0)
                            {
                                _octopusGrid[rowIndex - 1, columnIndex].EnergyLevel += 1;
                            }
                            // top right
                            if (rowIndex > 0 && columnIndex < ColumnLength - 1)
                            {
                                _octopusGrid[rowIndex - 1, columnIndex + 1].EnergyLevel += 1;
                            }
                            // right
                            if (columnIndex < ColumnLength - 1)
                            {
                                _octopusGrid[rowIndex, columnIndex + 1].EnergyLevel += 1;
                            }
                            // bottom right
                            if (rowIndex < RowLength - 1 && columnIndex < ColumnLength - 1)
                            {
                                _octopusGrid[rowIndex + 1, columnIndex + 1].EnergyLevel += 1;
                            }
                            // bottom
                            if (rowIndex < RowLength - 1)
                            {
                                _octopusGrid[rowIndex + 1, columnIndex].EnergyLevel += 1;
                            }
                            // bottom left
                            if (rowIndex < RowLength - 1 && columnIndex > 0)
                            {
                                _octopusGrid[rowIndex + 1, columnIndex - 1].EnergyLevel += 1;
                            }
                            // left
                            if (columnIndex > 0)
                            {
                                _octopusGrid[rowIndex, columnIndex - 1].EnergyLevel += 1;
                            }
                            // top left
                            if (rowIndex > 0 && columnIndex > 0)
                            {
                                _octopusGrid[rowIndex - 1, columnIndex - 1].EnergyLevel += 1;
                            }
                        }
                    }
                }
            } while (flashesContinue);

            return flashes;
        }

        private void ResetOctopusesThatHaveFlashed()
        {
            bool allOctopusesFlashed = true;
            for (var columnIndex = 0; columnIndex < ColumnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < RowLength; rowIndex++)
                {
                    var currentOctopus = _octopusGrid[rowIndex, columnIndex];
                    currentOctopus.HasFlashed = false;
                    if (currentOctopus.EnergyLevel > 9)
                    {
                        currentOctopus.EnergyLevel = 0;
                    }
                }
            }
        }

        private bool DidAllOctopusesFlash()
        {
            for (var columnIndex = 0; columnIndex < ColumnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < RowLength; rowIndex++)
                {
                    var currentOctopus = _octopusGrid[rowIndex, columnIndex];

                    if (!currentOctopus.HasFlashed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void PrintGrid(string message = "no message")
        {
            TestContext.WriteLine($"{message}: ");
            for (var columnIndex = 0; columnIndex < ColumnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < RowLength; rowIndex++)
                {
                    TestContext.Write(_octopusGrid[rowIndex, columnIndex].EnergyLevel.ToString().PadRight(3));
                }
                TestContext.WriteLine();
            }
            TestContext.WriteLine();
        }
    }

    public class Octopus
    {
        public Octopus()
        {
        }

        public Octopus(int row, int column, bool hasFlashed, int energyLevel)
        {
            Row = row;
            Column = column;
            HasFlashed = hasFlashed;
            EnergyLevel = energyLevel;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public int EnergyLevel { get; set; }

        public bool HasFlashed { get; set; }
    }

    public class OctoGridLoader
    {
        public static Octopus[,] Load(string? data)
        {
            string[] inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);
            var rowLength = inputData[0].Length;
            var columnLength = inputData.Length;
            //var octoGrid = new int[rowLength, columnLength];
            var octopusGrid = new Octopus[rowLength, columnLength];

            for (var columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
                {
                    //octoGrid[rowIndex, columnIndex] = Convert.ToInt32(inputData[columnIndex][rowIndex].ToString());
                    //TestContext.Write(octoGrid[rowIndex, columnIndex].ToString().PadRight(2));

                    octopusGrid[rowIndex, columnIndex] = new Octopus(row: rowIndex, column: columnIndex, hasFlashed: false, energyLevel: Convert.ToInt32(inputData[columnIndex][rowIndex].ToString()));
                    //TestContext.Write(octopusGrid[rowIndex, columnIndex].EnergyLevel.ToString().PadRight(3));
                }
                //TestContext.WriteLine();
            }

            return octopusGrid;
        }
    }
}

