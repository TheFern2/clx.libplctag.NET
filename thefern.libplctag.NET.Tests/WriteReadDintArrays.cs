using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class WriteReadDintArrays
    {
        [TestMethod]
        public async Task TestDintArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseDINTArray", TagType.Dint, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseDINTArray", TagType.Dint, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestDintArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values

            var result = await myPLC.WriteDintArray("BaseDINTArray", alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadDintArray("BaseDINTArray", 128);
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestDintArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.WriteDintArray("BaseDINTArray", alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.WriteDintArray("BaseDINTArray", updateValues.ToArray(), 128, 0, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadDintArray("BaseDINTArray", 128, 0, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestDintArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.WriteDintArray("BaseDINTArray", alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.WriteDintArray("BaseDINTArray", updateValues.ToArray(), 128, 10, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadDintArray("BaseDINTArray", 128, 10, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestDintArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.WriteDintArray("BaseDINTArray", alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.WriteDintArray("BaseDINTArray", updateValues.ToArray(), 128, 128, 10);
            Assert.AreEqual("Failure, Out of bounds", result.Status);

            /*var result2 = await myPLC.ReadDintArray("BaseDINTArray", 128, 10, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));*/
        }

        [TestMethod]
        public async Task TestDintArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.WriteDintArray("BaseDINTArray", alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.WriteDintArray("BaseDINTArray", updateValues.ToArray(), 128, 118, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadDintArray("BaseDINTArray", 128, 118, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }
    }
}
