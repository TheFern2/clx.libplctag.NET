using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class WriteReadStringArrays
    {
        [TestMethod]
        public async Task TestStringArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<string>(Randomizer.GenRandStringList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseSTRINGArray", TagType.String, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseSTRINGArray", TagType.String, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestStringArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<string>(Randomizer.GenRandStringList(128)); // Randomize first to ensure new values

            var result = await myPLC.WriteStringArray("BaseSTRINGArray", alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadStringArray("BaseSTRINGArray", 128);
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestStringArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<string>(Randomizer.GenRandStringList(128)); // Randomize first to ensure new values
            await myPLC.WriteStringArray("BaseSTRINGArray", alist.ToArray(), 128);
            var updateValues = new List<string>(Randomizer.GenRandStringList(10));

            var result = await myPLC.WriteStringArray("BaseSTRINGArray", updateValues.ToArray(), 128, 0, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadStringArray("BaseSTRINGArray", 128, 0, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestStringArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<string>(Randomizer.GenRandStringList(128)); // Randomize first to ensure new values
            await myPLC.WriteStringArray("BaseSTRINGArray", alist.ToArray(), 128);
            var updateValues = new List<string>(Randomizer.GenRandStringList(10));

            var result = await myPLC.WriteStringArray("BaseSTRINGArray", updateValues.ToArray(), 128, 10, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadStringArray("BaseSTRINGArray", 128, 10, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestStringArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<string>(Randomizer.GenRandStringList(128)); // Randomize first to ensure new values
            await myPLC.WriteStringArray("BaseSTRINGArray", alist.ToArray(), 128);
            var updateValues = new List<string>(Randomizer.GenRandStringList(10));

            var result = await myPLC.WriteStringArray("BaseSTRINGArray", updateValues.ToArray(), 128, 128, 10);
            Assert.AreEqual("Failure, Out of bounds", result.Status);

        }

        [TestMethod]
        public async Task TestStringArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<string>(Randomizer.GenRandStringList(128)); // Randomize first to ensure new values
            await myPLC.WriteStringArray("BaseSTRINGArray", alist.ToArray(), 128);
            var updateValues = new List<string>(Randomizer.GenRandStringList(10));

            var result = await myPLC.WriteStringArray("BaseSTRINGArray", updateValues.ToArray(), 128, 118, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadStringArray("BaseSTRINGArray", 128, 118, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }
    }
}
