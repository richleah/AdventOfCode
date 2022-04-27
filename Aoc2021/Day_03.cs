using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture]
public class Day_03
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_convert_binary_string_to_integer()
    {
        string bin_string1 = "1010101010101010";
        string bin_string2 = "10110";
        string bin_string3 = "01001";

        // converting to integer
        var int1 = Convert.ToInt32(bin_string1, 2);
        var int2 = Convert.ToInt32(bin_string2, 2);
        var int3 = Convert.ToInt32(bin_string3, 2);

        TestContext.WriteLine("Number value of binary \"{0}\" is = {1}", bin_string1, int1);
        TestContext.WriteLine("Number value of binary \"{0}\" is = {1}", bin_string2, int2);
        TestContext.WriteLine("Number value of binary \"{0}\" is = {1}", bin_string3, int3);

        Assert.AreEqual(43690, int1);
        Assert.AreEqual(22, int2);
        Assert.AreEqual(9, int3);
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        //var diagData = JsonSerializer.Deserialize<List<string>>(Aoc2021Data.Day3SampleB);
        var document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        var diagData = document.RootElement.GetProperty("data");

        // Act
        var diagnostics = diagData.EnumerateArray().Select(diagDatum => diagDatum.ToString()).ToList();

        //Assert
        Assert.IsNotNull(diagnostics);
        Assert.IsNotEmpty(diagnostics);
        //Assert.AreEqual(10, finalPosition.Depth);
        //Assert.AreEqual(new Position(15,10), GetPosition(directions.Moves));
    }

    // Part 1

    [Test]
    public void Should_generate_gamma_rate_of_22_for_sample_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(22, processor.GammaRate());
    }

    [Test]
    public void Should_generate_epsilon_rate_of_9_for_sample_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(9, processor.EpsilonRate());
    }

    [Test]
    public void Should_generate_power_consumption_of_198_for_sample_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(198, processor.PowerConsumption());
    }

    [Test]
    public void Should_generate_gamma_rate_of_2277_for_actual_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(2277, processor.GammaRate());
    }

    [Test]
    public void Should_generate_epsilon_rate_of_1818_for_actual_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(1818, processor.EpsilonRate());
    }

    [Test]
    public void Should_generate_power_consumption_of_4139586_for_actual_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(4139586, processor.PowerConsumption());
    }

    // Part 2

    [Test]
    public void Should_generate_oxygen_generator_rating_of_23_for_sample_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(23, processor.OxygenGeneratorRating());
    }

    [Test]
    public void Should_generate_c02_scrubber_rating_of_10_for_sample_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(10, processor.C02ScrubberRating());
    }

    [Test]
    public void Should_generate_life_support_rating_of_230_for_sample_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3Sample);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(230, processor.LifeSupportRating());
    }

    [Test]
    public void Should_generate_oxygen_generator_rating_of_2539_for_actual_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(2539, processor.OxygenGeneratorRating());
    }

    [Test]
    public void Should_generate_c02_scrubber_rating_of_709_for_actual_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(709, processor.C02ScrubberRating());
    }

    [Test]
    public void Should_generate_life_support_rating_of_1800151_for_actual_data()
    {
        // Arrange
        JsonDocument document = JsonDocument.Parse(Aoc2021Data.Day3);
        JsonElement diagnosticData = document.RootElement.GetProperty("data");
        var diagnostics = diagnosticData.EnumerateArray().Select(diagnosticDatum => diagnosticDatum.ToString()).ToList();

        // Act
        var processor = new DiagnosticsProcessor(diagnostics);

        //Assert
        Assert.AreEqual(1800151, processor.LifeSupportRating());
    }

    public class DiagnosticsProcessor
    {
        private List<string> _diagnosticData;

        public DiagnosticsProcessor(List<string> diagnosticData)
        {
            _diagnosticData = diagnosticData;
        }

        public int GammaRate()
        {
            string gammaRateBinary = "";
            // calculate
            for (int i = 0; i < _diagnosticData[0].Length; i++)
            {
                var gammaRateBits = _diagnosticData.SelectMany(x => x[i].ToString()).ToList();

                TestContext.WriteLine($"GammaRateBits: {string.Join("", gammaRateBits)}");
                //gammaRateBinary += gammaRateBits.Count(x => x == '0') > gammaRateBits.Count(x => x == '1') ? "0" : "1";
                gammaRateBinary += gammaRateBits.Count(x => x == '1') > gammaRateBits.Count(x => x == '0') ? "1" : "0";
            }

            TestContext.WriteLine($"GammaRateBinary: {string.Join("", gammaRateBinary)}");

            return Convert.ToInt32(gammaRateBinary, 2);
        }

        public int EpsilonRate()
        {
            string epsilonRateBinary = "";
            // calculate
            for (int i = 0; i < _diagnosticData[0].Length; i++)
            {
                var epsilonRateBits = _diagnosticData.SelectMany(x => x[i].ToString()).ToList();

                TestContext.WriteLine($"EpsilonRateBits: {string.Join("", epsilonRateBits)}");
                //epsilonRateBinary += epsilonRateBits.Count(x => x == '1') > epsilonRateBits.Count(x => x == '0') ? "0" : "1";
                epsilonRateBinary += epsilonRateBits.Count(x => x == '0') > epsilonRateBits.Count(x => x == '1') ? "1" : "0";
            }

            TestContext.WriteLine($"EpsilonRateBinary: {string.Join("", epsilonRateBinary)}");

            return Convert.ToInt32(epsilonRateBinary, 2);
        }

        public int OxygenGeneratorRating()
        {
            List<string> diagnosticData = new List<string>(_diagnosticData);
            // calculate
            for (int i = 0; i < diagnosticData[0].Length; i++)
            {
                // find the highest count bit, then only keep those
                var oxygenGeneratorBits = diagnosticData.SelectMany(x => x[i].ToString()).ToList();
                //TestContext.WriteLine($"oxygenGeneratorBits with 1: {oxygenGeneratorBits.Count(x => x == '1')}, oxygenGeneratorBits with 0: {oxygenGeneratorBits.Count(x => x == '0')}");
                //var bitWithHighestCount = oxygenGeneratorBits.Count(x => x == '1') >= oxygenGeneratorBits.Count(x => x == '0') ? '1' : '0';
                var bitWithLowestCount = oxygenGeneratorBits.Count(x => x == '1') >= oxygenGeneratorBits.Count(x => x == '0') ? '0' : '1';
                diagnosticData.RemoveAll(x => x[i] == bitWithLowestCount);

                TestContext.WriteLine($"BitWithLowestCount: {bitWithLowestCount}");
                TestContext.WriteLine($"DiagnosticData: {string.Join(",", diagnosticData)}");

                if (diagnosticData.Count() != 1) continue;
                TestContext.WriteLine($"Only 1 diagnostic left - exiting loop!");
                break;
            }

            TestContext.WriteLine($"Last item in the diagnostic data: {diagnosticData[0]}");
            return Convert.ToInt32(diagnosticData[0], 2);
        }

        public int C02ScrubberRating()
        {
            List<string> diagnosticData = new List<string>(_diagnosticData);
            // calculate
            for (int i = 0; i < diagnosticData[0].Length; i++)
            {
                // find the highest count bit, then only keep those
                var c02ScrubberBits = diagnosticData.SelectMany(x => x[i].ToString()).ToList();
                var bitWithHighestCount = c02ScrubberBits.Count(x => x == '0') <= c02ScrubberBits.Count(x => x == '1') ? '1' : '0';
                diagnosticData.RemoveAll(x => x[i] == bitWithHighestCount);

                TestContext.WriteLine($"BitWithHighestCount: {bitWithHighestCount}");
                TestContext.WriteLine($"DiagnosticData: {string.Join(",", diagnosticData)}");

                if (diagnosticData.Count() != 1) continue;
                TestContext.WriteLine($"Only 1 diagnostic left - exiting loop!");
                break;
            }

            TestContext.WriteLine($"Last item in the diagnostic data: {diagnosticData[0]}");
            return Convert.ToInt32(diagnosticData[0], 2);
        }

        public int PowerConsumption()
        {
            return GammaRate() * EpsilonRate();
        }

        public int LifeSupportRating()
        {
            return OxygenGeneratorRating() * C02ScrubberRating();
        }
    }
}