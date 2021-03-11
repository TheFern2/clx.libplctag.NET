using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class WriteReadRealArrays
    {
        [TestMethod]
        public async Task TestRealArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseREALArray", TagType.Real, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseREALArray", TagType.Real, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestRealArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values

            var result = await myPLC.WriteRealArray("BaseREALArray", alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadRealArray("BaseREALArray", 128);
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestRealArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.WriteRealArray("BaseREALArray", alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.WriteRealArray("BaseREALArray", updateValues.ToArray(), 128, 0, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadRealArray("BaseREALArray", 128, 0, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestRealArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.WriteRealArray("BaseREALArray", alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.WriteRealArray("BaseREALArray", updateValues.ToArray(), 128, 10, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadRealArray("BaseREALArray", 128, 10, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestRealArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.WriteRealArray("BaseREALArray", alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.WriteRealArray("BaseREALArray", updateValues.ToArray(), 128, 128, 10);
            Assert.AreEqual("Failure, Out of bounds", result.Status);

        }

        [TestMethod]
        public async Task TestRealArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.WriteRealArray("BaseREALArray", alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.WriteRealArray("BaseREALArray", updateValues.ToArray(), 128, 118, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadRealArray("BaseREALArray", 128, 118, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }
    }
}
