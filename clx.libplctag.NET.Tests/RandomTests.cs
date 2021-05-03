using libplctag.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace clx.libplctag.NET.Tests
{
    [TestClass]
    public class RandomTests
    {
        const int MAX_NUMBER_TESTS = 100;

        [TestMethod]
        public async Task WriteReadBoolRandom()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var rand = new Random();
            var numberOfTests = rand.Next(0, MAX_NUMBER_TESTS);
            var alist = new List<bool>(Randomizer.GenRandBoolList(numberOfTests));
            Console.WriteLine("Number of random tests: " + numberOfTests);

            for (int i = 0; i < alist.Count; i++)
            {
                await myPLC.Write("BaseBOOL", TagType.Bool, alist[i]);
                var result = await myPLC.Read("BaseBOOL", TagType.Bool);
                Assert.AreEqual(alist[i].ToString(), result.Value);
                await Task.Delay(500);
            }
        }

        [TestMethod]
        public async Task WriteReadTagBoolRandom()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var rand = new Random();
            var numberOfTests = rand.Next(0, MAX_NUMBER_TESTS);
            var alist = new List<bool>(Randomizer.GenRandBoolList(numberOfTests));
            Console.WriteLine("Number of random tests: " + numberOfTests);

            for (int i = 0; i < alist.Count; i++)
            {
                await myPLC.WriteTag<BoolPlcMapper, bool>("BaseBOOL", alist[i]);
                var result = await myPLC.ReadTag<BoolPlcMapper, bool>("BaseBOOL");
                Assert.AreEqual(alist[i], result.Value);
                await Task.Delay(500);
            }
        }
    }
}
