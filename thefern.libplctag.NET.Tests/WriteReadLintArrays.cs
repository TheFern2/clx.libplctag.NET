using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class WriteReadLintArrays
    {
        [TestMethod]
        public async Task TestLintArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<long>(Randomizer.GenRandLongList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseLINTArray", TagType.Lint, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseLINTArray", TagType.Lint, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestLintArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<long>(Randomizer.GenRandLongList(128)); // Randomize first to ensure new values

            var result = await myPLC.WriteLintArray("BaseLINTArray", alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadLintArray("BaseLINTArray", 128);
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestLintArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<long>(Randomizer.GenRandLongList(128)); // Randomize first to ensure new values
            await myPLC.WriteLintArray("BaseLINTArray", alist.ToArray(), 128);
            var updateValues = new List<long>(Randomizer.GenRandLongList(10));

            var result = await myPLC.WriteLintArray("BaseLINTArray", updateValues.ToArray(), 128, 0, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadLintArray("BaseLINTArray", 128, 0, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestLintArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<long>(Randomizer.GenRandLongList(128)); // Randomize first to ensure new values
            await myPLC.WriteLintArray("BaseLINTArray", alist.ToArray(), 128);
            var updateValues = new List<long>(Randomizer.GenRandLongList(10));

            var result = await myPLC.WriteLintArray("BaseLINTArray", updateValues.ToArray(), 128, 10, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadLintArray("BaseLINTArray", 128, 10, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestLintArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<long>(Randomizer.GenRandLongList(128)); // Randomize first to ensure new values
            await myPLC.WriteLintArray("BaseLINTArray", alist.ToArray(), 128);
            var updateValues = new List<long>(Randomizer.GenRandLongList(10));

            var result = await myPLC.WriteLintArray("BaseLINTArray", updateValues.ToArray(), 128, 128, 10);
            Assert.AreEqual("Failure, Out of bounds", result.Status);

        }

        [TestMethod]
        public async Task TestLintArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<long>(Randomizer.GenRandLongList(128)); // Randomize first to ensure new values
            await myPLC.WriteLintArray("BaseLINTArray", alist.ToArray(), 128);
            var updateValues = new List<long>(Randomizer.GenRandLongList(10));

            var result = await myPLC.WriteLintArray("BaseLINTArray", updateValues.ToArray(), 128, 118, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadLintArray("BaseLINTArray", 128, 118, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }
    }
}
