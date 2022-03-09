using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Aoc2021;

// https://adventofcode.com/2021/day/2

[TestFixture]
public class Day_6
{
    //private List<int>? _lanternFishDaysTilSpawnSampleData;
    //private List<int>? _lanternFishDaysTilSpawnRealData;

    [SetUp]
    public void Setup()
    {
        //_lanternFishDaysTilSpawnSampleData = Aoc2021Data.Day6Sample.Split(",").Select(x => Convert.ToInt32(x)).ToList();
        //_lanternFishDaysTilSpawnRealData = Aoc2021Data.Day6.Split(",").Select(x => Convert.ToInt32(x)).ToList();
    }

    [Test]
    public void Should_load_sample_data()
    {
        // Arrange
        string? data = Aoc2021Data.Day6Sample;
        var lanternFishDaysTilSpawn = data.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        foreach (int daysTilSpawn in lanternFishDaysTilSpawn)
        {
            TestContext.WriteLine(daysTilSpawn);
        }

        // Act

        //Assert
        Assert.IsNotNull(data);
        Assert.IsNotEmpty(lanternFishDaysTilSpawn);
    }

    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    //[TestCase(256, 26984457539)]
    public void Should_fish_count_With_sample_dataV1(int daysToRunSimulation, long countOfLanternFish)
    {
        // Arrange
        string? data = Aoc2021Data.Day6Sample;
        var lanternFishDaysTilSpawn = data.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        // Act
        var simulator = new LanternFishSimulatorV1(lanternFishDaysTilSpawn);

        //Assert
        Assert.AreEqual(countOfLanternFish, simulator.HowManyFishProduced(daysToRunSimulation));
    }

    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    //[TestCase(256, 26984457539)]
    public async Task Should_fish_count_With_sample_dataV2(int daysToRunSimulation, long countOfLanternFish)
    {
        // Arrange
        string? data = Aoc2021Data.Day6Sample;
        var lanternFishDaysTilSpawn = data.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        // Act
        var simulator = new LanternFishSimulatorV2(lanternFishDaysTilSpawn);

        //Assert
        Assert.AreEqual(countOfLanternFish, await simulator.GetCountOfFishProduced(daysToRunSimulation));
    }

    //[TestCase(3, 1)]
    //[TestCase(4, 2)]
    //[TestCase(5, 2)]
    //[TestCase(10, 2)]
    //[TestCase(11, 3)]
    //[TestCase(12, 3)]
    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    //[TestCase(256, 26984457539)]
    public async Task Should_fish_count_With_sample_dataV3(int daysToRunSimulation, long countOfLanternFish)
    {
        // Arrange
        string? data = Aoc2021Data.Day6Sample;
        var lanternFishDaysTilSpawn = data.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        //lanternFishDaysTilSpawn = new List<int>() {1};

        // Act
        var simulator = new LanternFishSimulatorV3(lanternFishDaysTilSpawn);

        //Assert
        Assert.AreEqual(countOfLanternFish, await simulator.GetCountOfFishProduced(daysToRunSimulation));
    }

    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    //[TestCase(256, 26984457539)]
    public void Should_fish_count_With_sample_dataV4(int daysToRunSimulation, long countOfLanternFish)
    {
        // Arrange
        string? data = Aoc2021Data.Day6Sample;
        //int daysToRunSimulation = 200;
        //long countOfLanternFish = 1;
        
        //lanternFishDaysTilSpawn = new List<int>() {1};

        // Act
        var simulator = new LanternFishSimulatorV4(data);

        //Assert
        Assert.AreEqual(countOfLanternFish, simulator.HowManyFishProduced(daysToRunSimulation));
    }

    [TestCase(256, 1592918715629)]
    public void Should_fish_count_With_real_dataV4(int daysToRunSimulation, long countOfLanternFish)
    {
        // Arrange
        string? data = Aoc2021Data.Day6;
        //int daysToRunSimulation = 200;
        //long countOfLanternFish = 1;
        
        //lanternFishDaysTilSpawn = new List<int>() {1};

        // Act
        var simulator = new LanternFishSimulatorV4(data);

        //Assert
        Assert.AreEqual(countOfLanternFish, simulator.HowManyFishProduced(daysToRunSimulation));
    }

    public class LanternFishSimulatorV1
    {
        private readonly int _daysToSpawnForExistingFish = 7;
        private readonly int _daysToSpawnForNewFish = 9;
        private readonly List<int> _lanternFishDaysTilSpawn;

        public LanternFishSimulatorV1(List<int> lanternFishDaysTilSpawn)
        {
            _lanternFishDaysTilSpawn = lanternFishDaysTilSpawn;
        }

        public int HowManyFishProduced(int daysToRunSimulation)
        {
            var lanternFish = new List<int>(_lanternFishDaysTilSpawn);

            for (var dayIndex = 0; dayIndex < daysToRunSimulation; dayIndex++)
            {
                int lanternFishToProcess = lanternFish.Count;

                for (var fishIndex = 0; fishIndex < lanternFishToProcess; fishIndex++)
                {
                    if (lanternFish[fishIndex] == 0)
                    {
                        lanternFish.Add(_daysToSpawnForNewFish - 1);
                        lanternFish[fishIndex] = _daysToSpawnForExistingFish;
                    }

                    lanternFish[fishIndex]--;
                }
            }

            return lanternFish.Count;
        }
    }

    public class LanternFishSimulatorV2
    {
        private readonly int _daysToSpawnForExistingFish = 7;
        private readonly int _daysToSpawnForNewFish = 9;
        private readonly List<int> _lanternFishDaysTilSpawn;

        public LanternFishSimulatorV2(List<int> lanternFishDaysTilSpawn)
        {
            _lanternFishDaysTilSpawn = lanternFishDaysTilSpawn;
        }

        public async Task<uint> GetCountOfFishProduced(int daysToSimulate)
        {
            uint fishProduced = 0;

            foreach (int fishAge in _lanternFishDaysTilSpawn)
            {
                fishProduced += await GetCountOfFishProduced(fishAge, daysToSimulate);
            }

            return fishProduced;
        }

        public async Task<uint> GetCountOfFishProduced(int daysTilSpawn, int daysToSimulate)
        {
            //TestContext.WriteLine($"GetCountOfFishProduced({daysTilSpawn}, {daysToSimulate})");
            // when age is 0 we spawn a new fish
            // foreach the life of the fish
            uint fishProduced = 1;
            int myAge = --daysTilSpawn;

            do
            {
                //TestContext.WriteLine($"  myAge: {myAge}");
                if (myAge == -1)
                {
                    myAge = _daysToSpawnForExistingFish - 1;
                    fishProduced += await GetCountOfFishProduced(_daysToSpawnForNewFish, daysToSimulate);
                }

                myAge--;
            } while (--daysToSimulate > 0);

            //TestContext.WriteLine($"    Returned: {fishProduced} fish produced.");
            return fishProduced;
        }
    }

    public class LanternFishSimulatorV3
    {
        private readonly int _daysToSpawnForExistingFish = 7;
        private readonly int _daysToSpawnForNewFish = 9;
        private readonly List<int> _lanternFishDaysTilSpawn;

        public LanternFishSimulatorV3(List<int> lanternFishDaysTilSpawn)
        {
            _lanternFishDaysTilSpawn = lanternFishDaysTilSpawn;
        }

        public async Task<uint> GetCountOfFishProduced(int daysToSimulate)
        {
            uint fishProduced = 0;
            var dataCount = 1;

            foreach (int fishAge in _lanternFishDaysTilSpawn)
            {
                //TestContext.WriteLine($"NEW Fish {dataCount}");
                fishProduced++;
                int daysToSimulateWhenFishAtFirstDay0 = daysToSimulate - fishAge;

                for (int i = daysToSimulateWhenFishAtFirstDay0; i > 0; i -= 7)
                {
                    //TestContext.WriteLine($"Fish {dataCount}");
                    fishProduced += await GetCountOfFishProducedNew(i); //, "  ");
                }

                //TestContext.WriteLine($"TOTAL Fish {fishProduced}");
                dataCount++;
            }

            return fishProduced;
        }

        public async Task<uint> GetCountOfFishProducedNew(int daysToSimulate) //, string indent)
        {
            //TestContext.WriteLine($"{indent}GetCountOfFishProducedNew({daysToSimulate})");
            uint fishProduced = 1;

            daysToSimulate -= 9;

            if (daysToSimulate < 0)
            {
                //TestContext.WriteLine($"{indent}OUT Returned {fishProduced} fish produced.");
                return fishProduced;
            }

            for (int i = daysToSimulate; i > 0; i -= 7)
            {
                fishProduced += await GetCountOfFishProducedNew(i); //, indent += "  ");
            }

            //TestContext.WriteLine($"    Returned: {fishProduced} fish produced.");
            //TestContext.WriteLine($"{indent}Returned {fishProduced} fish produced.");
            return fishProduced;
        }
    }
    
    public class LanternFishSimulatorV4
    {
        private readonly int _daysToSpawnForExistingFish = 7;
        private readonly int _daysToSpawnForNewFish = 9;
        private readonly IEnumerable<long> _lanternFishDaysTilSpawn;

        public LanternFishSimulatorV4(string lanternFishDaysTilSpawn)
        {
            _lanternFishDaysTilSpawn = lanternFishDaysTilSpawn.Split(',').Select(long.Parse);
        }

        public long HowManyFishProduced(int daysToRunSimulation)
        {
            // copied from https://github.com/tpetrina/adventofcode/blob/main/2021/day6.csx
            List<long> Evolve(List<long> input)
            {
                var next = input[0];
                input.RemoveAt(0);
                input[6] += next;
                input.Add(next);
                return input;
            }

            var fishes = new List<long> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (var fish in _lanternFishDaysTilSpawn)
            {
                fishes[(int)fish]++;
            }

            for (var i = 0; i < daysToRunSimulation; ++i)
            {
                fishes = Evolve(fishes);
                TestContext.WriteLine(string.Join(",", fishes));
            }

            TestContext.WriteLine(fishes.Sum());
            return fishes.Sum();
        }
    }

}