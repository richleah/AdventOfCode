using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

public class Day_14
{
    [Test]
    public void Should_load_sample_data()
    {
        // Arrange

        // Act
        PolymerTemplateAndPairInsertionRules data = PolymerTemplateAndPairInsertionRulesLoader.Load(Aoc2021Data.Day14Sample);

        //Assert
        Assert.IsNotNull(data.PolymerTemplate);
        Assert.IsTrue(data.PolymerTemplate.Any());
        Assert.IsNotNull(data.CharacterToInsertRules);
        Assert.IsTrue(data.CharacterToInsertRules.Any());
    }

    private static IEnumerable<TestCaseData> InputsForPartA
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day14Sample, 1588);
            yield return new TestCaseData(Aoc2021Data.Day14, 2988);
        }
    }

    [TestCaseSource(nameof(InputsForPartA))]
    public void When_Sample_InputData_PartA_Quantity_Should_Be(string inputData, long expectedQuantity)
    {
        // Arrange
        var polymerTemplateAndPairInsertionRules = PolymerTemplateAndPairInsertionRulesLoader.Load(inputData);

        // Act
        long quantity = new PolymerizationEngine(polymerTemplateAndPairInsertionRules).GetDifferenceBetweenMostCommonAndLeastCommonElements(10);

        //Assert
        Assert.AreEqual(expectedQuantity, quantity);
    }

    [TestCaseSource(nameof(InputsForPartA))]
    public void When_Sample_InputData_PartA_Quantity_Should_BeV2(string inputData, long expectedQuantity)
    {
        // Arrange
        var polymerTemplateAndPairInsertionRules = PolymerTemplateAndPairInsertionRulesLoader.LoadV2(inputData);

        // Act
        long quantity = new PolymerizationEngine(polymerTemplateAndPairInsertionRules).GetDifferenceBetweenMostCommonAndLeastCommonElementsV2(10);

        //Assert
        Assert.AreEqual(expectedQuantity, quantity);
    }

    private static IEnumerable<TestCaseData> InputsForPartB
    {
        get
        {
            yield return new TestCaseData(Aoc2021Data.Day14Sample, 2188189693529);
            yield return new TestCaseData(Aoc2021Data.Day14, 3572761917024);
        }
    }

    [TestCaseSource(nameof(InputsForPartB))]
    public void When_Real_InputData_PartA_Quantity_Should_Be(string inputData, long expectedQuantity)
    {
        // Arrange
        var polymerTemplateAndPairInsertionRules = PolymerTemplateAndPairInsertionRulesLoader.LoadV2(inputData);

        // Act
        long quantity = new PolymerizationEngine(polymerTemplateAndPairInsertionRules).GetDifferenceBetweenMostCommonAndLeastCommonElementsV2(40);

        //Assert
        Assert.AreEqual(expectedQuantity, quantity);
    }
}

public class PolymerizationEngine
{
    private readonly PolymerTemplateAndPairInsertionRules _polymerTemplateAndPairInsertionRules;

    private readonly PolymerTemplateAndPairInsertionRulesV2 _polymerTemplateAndPairInsertionRulesV2;

    public PolymerizationEngine(PolymerTemplateAndPairInsertionRules polymerTemplateAndPairInsertionRules)
    {
        _polymerTemplateAndPairInsertionRules = polymerTemplateAndPairInsertionRules;
    }

    public PolymerizationEngine(PolymerTemplateAndPairInsertionRulesV2 polymerTemplateAndPairInsertionRules)
    {
        _polymerTemplateAndPairInsertionRulesV2 = polymerTemplateAndPairInsertionRules;
    }

    public long GetDifferenceBetweenMostCommonAndLeastCommonElements(int steps)
    {
        var quantity = 0;

        for (var i = 0; i < steps; i++)
        {
            // process polymer pairs against the insertion pair rules
            //
            _polymerTemplateAndPairInsertionRules.ProcessRulesAgainstTheTemplate();

            //foreach (string s in _polymerTemplateAndPairInsertionRules.PolymerTemplate)
            //{
            //    TestContext.Write(s);
            //}
            //TestContext.WriteLine();
        }

        // find most common element count and least common element count and return the difference
        var charactersByCount = _polymerTemplateAndPairInsertionRules.PolymerTemplate
            .ToList()
            .GroupBy(x => x, y => y)
            .OrderByDescending(x => x.Count())
            .ToList();

        string? maxCharacter = charactersByCount.First().Key;
        string? minCharacter = charactersByCount[charactersByCount.Count() - 1].Key;

        var maxCharCount = _polymerTemplateAndPairInsertionRules.PolymerTemplate.Count(x => x == maxCharacter);
        var minCharCount = _polymerTemplateAndPairInsertionRules.PolymerTemplate.Count(x => x == minCharacter);

        //TestContext.WriteLine($"Max Char: {maxCharacter} - Count: {maxCharCount}");
        //TestContext.WriteLine($"Min Char: {minCharacter} - Count: {minCharCount}");

        return maxCharCount - minCharCount;
    }

    public long GetDifferenceBetweenMostCommonAndLeastCommonElementsV2(int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            // process polymer pairs against the insertion pair rules
            //
            _polymerTemplateAndPairInsertionRulesV2.ProcessRulesAgainstTheTemplate();

            //var first = true;
            //TestContext.Write($"Step: {i + 1} - ");
            //foreach (var pair in _polymerTemplateAndPairInsertionRulesV2.PolymerTemplatePairs)
            //{
            //    TestContext.Write($"{pair.Key}({pair.Value})-");
            //}
            //TestContext.WriteLine();
        }

        return _polymerTemplateAndPairInsertionRulesV2.GetDifferenceBetweenMostCommonAndLeastCommonElements();
    }
}

public class PolymerTemplateAndPairInsertionRules
{
    public PolymerTemplateAndPairInsertionRules(LinkedList<string> polymerTemplate, Dictionary<string, string> characterToInsertRules)
    {
        PolymerTemplate = polymerTemplate;
        CharacterToInsertRules = characterToInsertRules;
    }

    public LinkedList<string> PolymerTemplate { get; }

    public Dictionary<string, string> CharacterToInsertRules { get; set; }

    public void ProcessRulesAgainstTheTemplate()
    {
        var currentNode = PolymerTemplate.First;
        while (currentNode != null && currentNode != PolymerTemplate.Last)
        {
            string nextTemplatePair = currentNode.Value + currentNode.Next.Value;
            currentNode = currentNode.Next;

            if (CharacterToInsertRules.ContainsKey(nextTemplatePair))
            {
                PolymerTemplate.AddBefore(currentNode, CharacterToInsertRules[nextTemplatePair]);
            }
        }
    }
}

public class PolymerTemplateAndPairInsertionRulesV2
{
    private readonly string _lastCharacterInTemplate;

    public PolymerTemplateAndPairInsertionRulesV2(Dictionary<string, long> polymerTemplatePairsPairs, Dictionary<string, string> characterToInsertRules)
    {
        PolymerTemplatePairs = polymerTemplatePairsPairs;
        CharacterToInsertRules = characterToInsertRules;
        _lastCharacterInTemplate = polymerTemplatePairsPairs.Last().Key[1].ToString();
    }

    public Dictionary<string, long> PolymerTemplatePairs { get; }

    public Dictionary<string, string> CharacterToInsertRules { get; set; }

    public void ProcessRulesAgainstTheTemplate()
    {
        // store all of the newly created pairs in this new dictionary and then add them back into the main Template dictionary after c[processing is complete
        Dictionary<string, long> newPolymerTemplatePairsPairs = new();

        foreach (var polymerTemplatePair in PolymerTemplatePairs)
        {
            //TestContext.WriteLine($"Processing Pair: {polymerTemplatePair.Key}({polymerTemplatePair.Value})");
            if (CharacterToInsertRules.ContainsKey(polymerTemplatePair.Key))
            {
                //TestContext.WriteLine($"   Processing Rule - Insert: {CharacterToInsertRules[polymerTemplatePair.Key]}");

                var newPair1 = polymerTemplatePair.Key[0] + CharacterToInsertRules[polymerTemplatePair.Key];
                var newPair2 = CharacterToInsertRules[polymerTemplatePair.Key] + polymerTemplatePair.Key[1];

                PolymerTemplatePairs[polymerTemplatePair.Key] = 0; // equivalent of removing the matched pair from the template
                //TestContext.WriteLine($"      Removing Pair: {polymerTemplatePair.Key}");

                if (newPolymerTemplatePairsPairs.ContainsKey(newPair1))
                {
                    //TestContext.WriteLine($"         Updating Pair: {newPair1}({polymerTemplatePair.Value})");
                    newPolymerTemplatePairsPairs[newPair1] += polymerTemplatePair.Value;
                }
                else
                {
                    //TestContext.WriteLine($"         Adding Pair: {newPair1}({polymerTemplatePair.Value})");
                    newPolymerTemplatePairsPairs.Add(newPair1, polymerTemplatePair.Value);
                }

                if (newPolymerTemplatePairsPairs.ContainsKey(newPair2))
                {
                    //TestContext.WriteLine($"         Updating Pair: {newPair2}({polymerTemplatePair.Value})");
                    newPolymerTemplatePairsPairs[newPair2] += polymerTemplatePair.Value;
                }
                else
                {
                    //TestContext.WriteLine($"         Adding Pair: {newPair2}({polymerTemplatePair.Value})");
                    newPolymerTemplatePairsPairs.Add(newPair2, polymerTemplatePair.Value);
                }
            }
        }

        // add in all of the newPolymerTemplatePairsPairs into the PolymerTemplatePairs
        foreach (var newPolymerTemplatePairsPair in newPolymerTemplatePairsPairs)
        {
            if (PolymerTemplatePairs.ContainsKey(newPolymerTemplatePairsPair.Key))
            {
                PolymerTemplatePairs[newPolymerTemplatePairsPair.Key] += newPolymerTemplatePairsPair.Value;
            }
            else
            {
                PolymerTemplatePairs.Add(newPolymerTemplatePairsPair.Key, newPolymerTemplatePairsPair.Value);
            }
        }

        // remove all zero count pairs
        foreach (var pair in PolymerTemplatePairs.Where(x => x.Value == 0).ToList())
        {
            PolymerTemplatePairs.Remove(pair.Key);
        }
    }

    public long GetDifferenceBetweenMostCommonAndLeastCommonElements()
    {
        Dictionary<string, long> templateElementCount = new();
        foreach (var polymerTemplatePair in PolymerTemplatePairs)
        {
            // the count is found by looking at the first letter of each pair and adding the count of each together
            var templateElement = polymerTemplatePair.Key[0].ToString();
            if (templateElementCount.ContainsKey(templateElement))
            {
                templateElementCount[templateElement] += polymerTemplatePair.Value;
            }
            else
            {
                templateElementCount.Add(templateElement, polymerTemplatePair.Value);
            }
        }

        // this adds the last element of the template into the count for that element
        templateElementCount[_lastCharacterInTemplate] += 1;

        var orderedTemplateElementCount = templateElementCount.OrderByDescending(x => x.Value).ToList();
            
        // find most common element count and least common element count and return the difference
        var charactersByCount = PolymerTemplatePairs
            .OrderByDescending(x => x.Value)
            .ToList();

        var maxCharCount = orderedTemplateElementCount.First().Value;
        var minCharCount = orderedTemplateElementCount.Last().Value;

        //TestContext.WriteLine($"Max Char: {maxCharacter} - Count: {maxCharCount}");
        //TestContext.WriteLine($"Min Char: {minCharacter} - Count: {minCharCount}");

        return maxCharCount - minCharCount;
    }
}

public class PolymerTemplateAndPairInsertionRulesLoader
{
    public static PolymerTemplateAndPairInsertionRules Load(string data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        var polymerTemplate = inputData[0].Select(character => character.ToString()).ToList();
        var polymerTemplateLinkedList = new LinkedList<string>(polymerTemplate);

        TestContext.Write("Polymer Template: ");
        polymerTemplate.ForEach(TestContext.Write);
        TestContext.WriteLine();
        TestContext.WriteLine();

        inputData.RemoveAt(0);

        Dictionary<string, string> characterToInsertRules = new();

        TestContext.WriteLine("Polymer Rules: ");
        foreach (string lineData in inputData)
        {
            var lineSplit = lineData.Split("->", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            characterToInsertRules.Add(lineSplit[0], lineSplit[1]);
            TestContext.WriteLine($"{lineSplit[0]} -> {lineSplit[1]}");
        }

        return new PolymerTemplateAndPairInsertionRules(polymerTemplateLinkedList, characterToInsertRules);
    }

    public static PolymerTemplateAndPairInsertionRulesV2 LoadV2(string data)
    {
        var inputData = data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        Dictionary<string, long> polymerTemplatePairs = new();

        string templateData = inputData[0];
        for (var i = 0; i < templateData.Length - 1; i++)
        {
            string nextTemplatePair = templateData[i] + templateData[i + 1].ToString();

            if (polymerTemplatePairs.ContainsKey(nextTemplatePair))
            {
                polymerTemplatePairs[nextTemplatePair]++;
            }
            else
            {
                polymerTemplatePairs.Add(nextTemplatePair, 1);
            }
        }

        //TestContext.WriteLine("Polymer Template: ");

        foreach (var polymerTemplatePair in polymerTemplatePairs)
        {
            //TestContext.WriteLine($"{polymerTemplatePair.Key}({polymerTemplatePair.Value})");
        }
        //TestContext.WriteLine();

        inputData.RemoveAt(0);

        Dictionary<string, string> characterToInsertRules = new();

        //TestContext.WriteLine("Polymer Rules: ");
        foreach (string lineData in inputData)
        {
            var lineSplit = lineData.Split("->", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            characterToInsertRules.Add(lineSplit[0], lineSplit[1]);
            //TestContext.WriteLine($"{lineSplit[0]} -> {lineSplit[1]}");
        }
        //TestContext.WriteLine();

        return new PolymerTemplateAndPairInsertionRulesV2(polymerTemplatePairs, characterToInsertRules);
    }
}