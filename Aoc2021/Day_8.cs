using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture]
public class Day_8
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string? data = Aoc2021Data.Day8Sample;
        string[] inputData = data.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);
        List<List<string>> listOfSignalPatterns = new();
        List<List<string>> listOfOutput = new();

        foreach (string line in inputData)
        {
            string[] lineData = line.Split("|", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);
            listOfSignalPatterns.Add(lineData[0].Split(" ", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList());
            listOfOutput.Add(lineData[1].Split(" ", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList());
            TestContext.Write("Wiring: " + string.Join(", ", lineData[0].Split(" ", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries)));
            TestContext.WriteLine(" - Gauges: " + string.Join(", ", lineData[1].Split(" ", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries)));
            Assert.AreEqual(10, listOfSignalPatterns.Last().Count);
            Assert.AreEqual(4, listOfOutput.Last().Count);
        }

        // Act

        //Assert
        Assert.IsNotNull(data);

        //Assert.IsNotEmpty(inputData);
    }

    [Test]
    public void When_SampleInput_Count_Should_Be_26()
    {
        // Arrange
        string[] inputData = Aoc2021Data.Day8Sample.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        var segmentDisplayDataSets = SevenSegmentDisplayDataTransformer.Transform(inputData);
        var reader = new SevenSegmentOutputReader(segmentDisplayDataSets);

        //Assert
        Assert.AreEqual(26, reader.GetCountOfUniquelyIdentifiableDigitsInTheOutput());
    }

    [Test]
    public void When_Input_Count_Should_Be_534()
    {
        // Arrange
        string[] inputData = Aoc2021Data.Day8.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        var segmentDisplayDataSets = SevenSegmentDisplayDataTransformer.Transform(inputData);
        var reader = new SevenSegmentOutputReader(segmentDisplayDataSets);

        //Assert
        Assert.AreEqual(534, reader.GetCountOfUniquelyIdentifiableDigitsInTheOutput());
    }

    [Test]
    public void When_SampleInput_OutputCount_Should_Be_61229()
    {
        // Arrange
        string[] inputData = Aoc2021Data.Day8Sample.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        var segmentDisplayDataSets = SevenSegmentDisplayDataTransformer.Transform(inputData);
        var reader = new SevenSegmentOutputReader(segmentDisplayDataSets.ToList());

        //Assert
        Assert.AreEqual(61229, reader.GetCountOfTheOutput());
    }

    [Test]
    public void When_SampleInput_OutputCount_Should_Be_1070188()
    {
        // Arrange
        string[] inputData = Aoc2021Data.Day8.Split(Environment.NewLine, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

        // Act
        var segmentDisplayDataSets = SevenSegmentDisplayDataTransformer.Transform(inputData);
        var reader = new SevenSegmentOutputReader(segmentDisplayDataSets.ToList());

        //Assert
        Assert.AreEqual(1070188, reader.GetCountOfTheOutput());
    }

    [Test]
    public void Test_SegmentWireDeductionWizard()
    {
        // Arrange
        var dataSet = new List<string> {"acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab"};

        // Act
        SegmentsAndSignalWires.SegmentsAndSignalWiresMappings x = SegmentWireDeductionWizard.Deduce(dataSet);

        //Assert
        Assert.AreEqual("d", x[Segments.Top].SignalWire);
        Assert.AreEqual("e", x[Segments.TopLeft].SignalWire);
        Assert.AreEqual("a", x[Segments.TopRight].SignalWire);
        Assert.AreEqual("f", x[Segments.Middle].SignalWire);
        Assert.AreEqual("g", x[Segments.BottomLeft].SignalWire);
        Assert.AreEqual("b", x[Segments.BottomRight].SignalWire);
        Assert.AreEqual("c", x[Segments.Bottom].SignalWire);
    }

    [Test]
    public void Test_TranslateSegmentWireMappingToDigit()
    {
        // Arrange
        var dataSet = new List<string> {"acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab"};

        // Act
        SegmentsAndSignalWires.SegmentsAndSignalWiresMappings mappedSegments = new(new List<SegmentsAndSignalWires.SegmentToSignalWireMapping>
        {
            new(Segments.Top, "d"),
            new(Segments.TopLeft, "g"),
            new(Segments.TopRight, "b"),
            new(Segments.Middle, "c"),
            new(Segments.BottomLeft, "a"),
            new(Segments.BottomRight, "e"),
            new(Segments.Bottom, "f")
        });

        //Assert
        Assert.AreEqual(1, mappedSegments.TranslateSegmentWireMappingToDigit("be"));
        Assert.AreEqual(1, mappedSegments.TranslateSegmentWireMappingToDigit("eb"));
        Assert.AreEqual(2, mappedSegments.TranslateSegmentWireMappingToDigit("dbcaf"));
        Assert.AreEqual(3, mappedSegments.TranslateSegmentWireMappingToDigit("dbcef"));
        Assert.AreEqual(4, mappedSegments.TranslateSegmentWireMappingToDigit("gbce"));
        Assert.AreEqual(5, mappedSegments.TranslateSegmentWireMappingToDigit("dgcef"));
        Assert.AreEqual(6, mappedSegments.TranslateSegmentWireMappingToDigit("dgcaef"));
        Assert.AreEqual(7, mappedSegments.TranslateSegmentWireMappingToDigit("dbe"));
        Assert.AreEqual(8, mappedSegments.TranslateSegmentWireMappingToDigit("dgbcaef"));
        Assert.AreEqual(9, mappedSegments.TranslateSegmentWireMappingToDigit("dgbcef"));
        Assert.AreEqual(0, mappedSegments.TranslateSegmentWireMappingToDigit("dgbaef"));
    }
}

public class SevenSegmentDisplayDataTransformer
{
    public static List<SevenSegmentDisplayDataSet> Transform(IEnumerable<string> inputData)
    {
        List<SevenSegmentDisplayDataSet> segmentDisplayDataSets = new();

        foreach (string line in inputData)
        {
            string[] lineData = line.Split("|", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

            segmentDisplayDataSets.Add(
                new SevenSegmentDisplayDataSet(
                    lineData[0].Split(" ", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList(),
                    lineData[1].Split(" ", StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries).ToList()));
        }

        return segmentDisplayDataSets;
    }
}

public class SevenSegmentOutputReader
{
    // digit => count of segments used to create digit
    // 0 => 6
    // 1 => 2 <= unique
    // 2 => 5
    // 3 => 5
    // 4 => 4 <= unique
    // 5 => 5
    // 6 => 6
    // 7 => 3 <= unique
    // 8 => 7 <= unique
    // 9 => 6

    private readonly List<SevenSegmentDisplayDataSet> _segmentDisplayDataSets;

    public SevenSegmentOutputReader(List<SevenSegmentDisplayDataSet> segmentDisplayDataSets)
    {
        _segmentDisplayDataSets = segmentDisplayDataSets;
    }

    public int GetCountOfUniquelyIdentifiableDigitsInTheOutput()
    {
        int[] uniqueSegmentCounts = {2, 3, 4, 7};
        var count = 0;

        foreach (SevenSegmentDisplayDataSet segmentDisplayDataSet in _segmentDisplayDataSets)
        {
            count += segmentDisplayDataSet.DigitOutputs.Count(signalPattern => uniqueSegmentCounts.Contains(signalPattern.Length));
        }

        return count;
    }

    public long GetCountOfTheOutput()
    {
        long count = 0;

        // goal is to read a line of data and determine the proper wires to segments, and then determine each of the 4 output digits
        foreach (SevenSegmentDisplayDataSet sevenSegmentDisplayDataSet in _segmentDisplayDataSets)
        {
            // deduce the wires to segments
            sevenSegmentDisplayDataSet.SegmentsToSignalWiresMapping = SegmentWireDeductionWizard.Deduce(sevenSegmentDisplayDataSet.SignalPatterns);

            count += SevenSegmentOutputTranslator.Translate(sevenSegmentDisplayDataSet.DigitOutputs, sevenSegmentDisplayDataSet.SegmentsToSignalWiresMapping);
        }

        return count;
    }
}

public class SevenSegmentOutputTranslator
{
    public static int Translate(List<string> digitOutputs, SegmentsAndSignalWires.SegmentsAndSignalWiresMappings segmentsToSignalWiresMapping)
    {
        var fourDigitValueAsString = string.Empty;

        // determine the 4 output values
        foreach (string digitOutput in digitOutputs)
        {
            TestContext.WriteLine($"Digit Output: {digitOutput}");

            // translate the digitOutput based on the segments to signal wires mappings
            int digit = segmentsToSignalWiresMapping.TranslateSegmentWireMappingToDigit(digitOutput);

            fourDigitValueAsString += digit.ToString();
        }

        var fourDigitValue = Convert.ToInt32(fourDigitValueAsString);

        TestContext.WriteLine($"4 digit translated Value: {fourDigitValue}");
        TestContext.WriteLine("=======================================================");

        return fourDigitValue;
    }
}

public class SegmentWireDeductionWizard
{
    public static SegmentsAndSignalWires.SegmentsAndSignalWiresMappings Deduce(List<string> signalPatterns)
    {
        var segmentsAndSignalWires = new SegmentsAndSignalWires();

        // digit = 1
        string digit1SignalPattern = signalPatterns.Single(x => x.Length == 2);
        segmentsAndSignalWires[Segments.Top].PossibleSignalWires.RemoveAll(x => digit1SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.TopLeft].PossibleSignalWires.RemoveAll(x => digit1SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.RemoveAll(x => !digit1SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.Middle].PossibleSignalWires.RemoveAll(x => digit1SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.BottomLeft].PossibleSignalWires.RemoveAll(x => digit1SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.BottomRight].PossibleSignalWires.RemoveAll(x => !digit1SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.Bottom].PossibleSignalWires.RemoveAll(x => digit1SignalPattern.Contains(x));
        TestContext.WriteLine($"After processing the digit 1: {digit1SignalPattern}");
        TestContext.WriteLine(segmentsAndSignalWires.ToString());

        // digit = 7
        string digit7SignalPattern = signalPatterns.Single(x => x.Length == 3);
        var topSegmentWire = digit7SignalPattern.Single(x => !segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.Contains(x.ToString())).ToString();
        segmentsAndSignalWires[Segments.Top].PossibleSignalWires.RemoveAll(x => !topSegmentWire.Contains(x));
        segmentsAndSignalWires[Segments.TopLeft].PossibleSignalWires.RemoveAll(x => topSegmentWire.Contains(x));
        segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.RemoveAll(x => topSegmentWire.Contains(x));
        segmentsAndSignalWires[Segments.Middle].PossibleSignalWires.RemoveAll(x => topSegmentWire.Contains(x));
        segmentsAndSignalWires[Segments.BottomLeft].PossibleSignalWires.RemoveAll(x => topSegmentWire.Contains(x));
        segmentsAndSignalWires[Segments.BottomRight].PossibleSignalWires.RemoveAll(x => topSegmentWire.Contains(x));
        segmentsAndSignalWires[Segments.Bottom].PossibleSignalWires.RemoveAll(x => topSegmentWire.Contains(x));
        TestContext.WriteLine($"After processing the digit 7: {digit7SignalPattern}");
        TestContext.WriteLine(segmentsAndSignalWires.ToString());

        // digit = 4
        string digit4SignalPattern = signalPatterns.Single(x => x.Length == 4);
        var topLeftAndMiddleSegmentWires = digit4SignalPattern.Where(x => !segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.Contains(x.ToString())).Select(x => x.ToString()).ToList();

        segmentsAndSignalWires[Segments.TopLeft].PossibleSignalWires.RemoveAll(x => !topLeftAndMiddleSegmentWires.Contains(x));
        segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.RemoveAll(x => topLeftAndMiddleSegmentWires.Contains(x));
        segmentsAndSignalWires[Segments.Middle].PossibleSignalWires.RemoveAll(x => !topLeftAndMiddleSegmentWires.Contains(x));
        segmentsAndSignalWires[Segments.BottomLeft].PossibleSignalWires.RemoveAll(x => topLeftAndMiddleSegmentWires.Contains(x));
        segmentsAndSignalWires[Segments.BottomRight].PossibleSignalWires.RemoveAll(x => topLeftAndMiddleSegmentWires.Contains(x));
        segmentsAndSignalWires[Segments.Bottom].PossibleSignalWires.RemoveAll(x => topLeftAndMiddleSegmentWires.Contains(x));
        TestContext.WriteLine($"After processing the digit 4: {digit4SignalPattern}");
        TestContext.WriteLine(segmentsAndSignalWires.ToString());

        // digit = 3
        var possibleTopRightSignalWires = segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.ToList();
        string digit3SignalPattern = signalPatterns.Single(x => x.Length == 5 && x.Contains(possibleTopRightSignalWires[0]) && x.Contains(possibleTopRightSignalWires[1]));
        segmentsAndSignalWires[Segments.TopLeft].PossibleSignalWires.RemoveAll(x => digit3SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.Middle].PossibleSignalWires.RemoveAll(x => segmentsAndSignalWires[Segments.TopLeft].PossibleSignalWires.Single().Contains(x));
        segmentsAndSignalWires[Segments.BottomLeft].PossibleSignalWires.RemoveAll(x => digit3SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.Bottom].PossibleSignalWires.RemoveAll(x => segmentsAndSignalWires[Segments.BottomLeft].PossibleSignalWires.Single().Contains(x));
        TestContext.WriteLine($"After processing the digit 3: {digit3SignalPattern}");
        TestContext.WriteLine(segmentsAndSignalWires.ToString());

        // digit 2
        string digit2SignalPattern = signalPatterns.Single(x => x.Length == 5 && x.Contains(segmentsAndSignalWires[Segments.BottomLeft].PossibleSignalWires.Single()));
        string topRightSignalWire = possibleTopRightSignalWires.Single(x => digit2SignalPattern.Contains(x));
        string bottomRightSignalWire = possibleTopRightSignalWires.Single(x => !digit2SignalPattern.Contains(x));
        segmentsAndSignalWires[Segments.TopRight].PossibleSignalWires.RemoveAll(x => x == bottomRightSignalWire);
        segmentsAndSignalWires[Segments.BottomRight].PossibleSignalWires.RemoveAll(x => x == topRightSignalWire);
        TestContext.WriteLine($"After processing the digit 2: {digit2SignalPattern}");
        TestContext.WriteLine(segmentsAndSignalWires.ToString());

        return segmentsAndSignalWires.MappedSegmentsToSignalWires;
    }
}

/// <summary>
///     Holds the input data for one set of 4 (single digit) displays
/// </summary>
public class SevenSegmentDisplayDataSet
{
    /// <summary>
    ///     constructor
    /// </summary>
    /// <param name="signalPatterns"></param>
    /// <param name="digitOutputs"></param>
    public SevenSegmentDisplayDataSet(List<string> signalPatterns, List<string> digitOutputs)
    {
        SignalPatterns = signalPatterns;
        DigitOutputs = digitOutputs;
    }

    /// <summary>
    ///     The list (10 in length) of signal patterns to the left of the pipe
    /// </summary>
    public List<string> SignalPatterns { get; set; }

    /// <summary>
    ///     The list (4 in length) of the actual output (list of lit segments) for each of the 4 displays
    /// </summary>
    public List<string> DigitOutputs { get; set; }

    public SegmentsAndSignalWires.SegmentsAndSignalWiresMappings SegmentsToSignalWiresMapping { get; set; }
}

/// <summary>
///     Holds the possible wiring per 4 digit display
/// </summary>
public class SegmentsAndSignalWires
{
    private readonly List<SegmentToPossibleSignalWires> _segmentsToPossibleSignalWires;

    /// <summary>
    ///     Constructor - loads up the _segmentsToPossibleSignalWires field with all possible signal wiring per each segment (7
    ///     segments)
    /// </summary>
    public SegmentsAndSignalWires()
    {
        _segmentsToPossibleSignalWires = new List<SegmentToPossibleSignalWires>();

        for (var i = 0; i < 7; i++)
        {
            _segmentsToPossibleSignalWires.Add(new SegmentToPossibleSignalWires((Segments)i));
        }
    }

    //public List<SegmentToSignalWireMapping> MappedSegmentsToSignalWires => GetSegmentToSignalWireMapping(_segmentsToPossibleSignalWires);
    public SegmentsAndSignalWiresMappings MappedSegmentsToSignalWires => GetSegmentToSignalWireMapping(_segmentsToPossibleSignalWires);

    // indexer
    public SegmentToPossibleSignalWires this[Segments segment] => _segmentsToPossibleSignalWires[(int)segment];

    private bool IsReadyToTranslateOutput()
    {
        if (_segmentsToPossibleSignalWires.Any(segmentToSignalWire => segmentToSignalWire.PossibleSignalWires.Count != 1))
        {
            return false;
        }

        return true;
    }

    public int TranslateOutputValue(string output)
    {
        if (!IsReadyToTranslateOutput())
        {
            throw new ApplicationException("SevenSegmentsDisplayDataSet is not ready for translations. One or more of the segments have more than one wire associated!");
        }

        SegmentsAndSignalWiresMappings segmentToSignalWireMapping = GetSegmentToSignalWireMapping(_segmentsToPossibleSignalWires);

        return 0;
    }

    private static SegmentsAndSignalWiresMappings GetSegmentToSignalWireMapping(IReadOnlyCollection<SegmentToPossibleSignalWires> segmentsToPossibleSignalWires)
    {
        SegmentsAndSignalWiresMappings mappedSegments = new(new List<SegmentToSignalWireMapping>
        {
            new(Segments.Top, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.Top).PossibleSignalWires.Single()),
            new(Segments.TopLeft, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.TopLeft).PossibleSignalWires.Single()),
            new(Segments.TopRight, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.TopRight).PossibleSignalWires.Single()),
            new(Segments.Middle, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.Middle).PossibleSignalWires.Single()),
            new(Segments.BottomLeft, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.BottomLeft).PossibleSignalWires.Single()),
            new(Segments.BottomRight, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.BottomRight).PossibleSignalWires.Single()),
            new(Segments.Bottom, segmentsToPossibleSignalWires.Single(x => x.Segment == Segments.Bottom).PossibleSignalWires.Single())
        });

        return mappedSegments;
    }

    public override string ToString()
    {
        return $"     {string.Join("", _segmentsToPossibleSignalWires[0].PossibleSignalWires),-5}     {Environment.NewLine}" +
               $"{string.Join("", _segmentsToPossibleSignalWires[1].PossibleSignalWires),-5}     {string.Join("", _segmentsToPossibleSignalWires[2].PossibleSignalWires),-5}{Environment.NewLine}" +
               $"     {string.Join("", _segmentsToPossibleSignalWires[3].PossibleSignalWires),-5}     {Environment.NewLine}" +
               $"{string.Join("", _segmentsToPossibleSignalWires[4].PossibleSignalWires),-5}     {string.Join("", _segmentsToPossibleSignalWires[5].PossibleSignalWires),-5}{Environment.NewLine}" +
               $"     {string.Join("", _segmentsToPossibleSignalWires[6].PossibleSignalWires),-5}     {Environment.NewLine}";
    }

    /// <summary>
    ///     Holds a Segment (title) and it's possible signal wiring (a-g)
    /// </summary>
    public class SegmentToPossibleSignalWires
    {
        internal SegmentToPossibleSignalWires(Segments segment)
        {
            Segment = segment;
            PossibleSignalWires = new List<string>(7) {"a", "b", "c", "d", "e", "f", "g"};
        }

        public Segments Segment { get; }

        public List<string> PossibleSignalWires { get; }
    }

    public class SegmentsAndSignalWiresMappings
    {
        private readonly List<SegmentToSignalWireMapping> _segmentsToSignalWiresMappings;

        public SegmentsAndSignalWiresMappings(List<SegmentToSignalWireMapping> segmentsToSignalWiresMappings)
        {
            _segmentsToSignalWiresMappings = segmentsToSignalWiresMappings;
        }

        // indexer
        public SegmentToSignalWireMapping this[Segments segment] => _segmentsToSignalWiresMappings[(int)segment];

        private string TwosDigit()
        {
            return string.Concat((_segmentsToSignalWiresMappings[(int)Segments.Top].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.TopRight].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Middle].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.BottomLeft].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Bottom].SignalWire)
                .OrderBy(x => x));
        }

        private string ThreesDigit()
        {
            return string.Concat((_segmentsToSignalWiresMappings[(int)Segments.Top].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.TopRight].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Middle].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.BottomRight].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Bottom].SignalWire)
                .OrderBy(x => x));
        }

        private string ZerosDigit()
        {
            return string.Concat((_segmentsToSignalWiresMappings[(int)Segments.Top].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.TopRight].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.TopLeft].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.BottomRight].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.BottomLeft].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Bottom].SignalWire)
                .OrderBy(x => x));
        }

        private string SixesDigit()
        {
            return string.Concat((_segmentsToSignalWiresMappings[(int)Segments.Top].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.TopLeft].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Middle].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.BottomLeft].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.BottomRight].SignalWire
                                  + _segmentsToSignalWiresMappings[(int)Segments.Bottom].SignalWire)
                .OrderBy(x => x));
        }

        public int TranslateSegmentWireMappingToDigit(string digitOutput)
        {
            digitOutput = string.Concat(digitOutput.OrderBy(c => c));

            switch (digitOutput.Length)
            {
                case 2:
                    return 1;
                case 3:
                    return 7;
                case 4:
                    return 4;
                case 5:
                    if (digitOutput == TwosDigit())
                    {
                        return 2;
                    }

                    if (digitOutput == ThreesDigit())
                    {
                        return 3;
                    }

                    return 5;
                case 6:
                    if (digitOutput == ZerosDigit())
                    {
                        return 0;
                    }

                    if (digitOutput == SixesDigit())
                    {
                        return 6;
                    }

                    return 9;
                case 7:
                    return 8;
                default:
                    throw new ApplicationException("");
            }
        }
    }

    public class SegmentToSignalWireMapping
    {
        internal SegmentToSignalWireMapping(Segments segment, string signalWire)
        {
            Segment = segment;
            SignalWire = signalWire;
        }

        public Segments Segment { get; }

        public string SignalWire { get; }
    }
}

public enum Segments
{
    Top = 0,
    TopLeft = 1,
    TopRight = 2,
    Middle = 3,
    BottomLeft = 4,
    BottomRight = 5,
    Bottom = 6
}