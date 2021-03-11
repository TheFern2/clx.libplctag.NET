using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class WriteReadBoolArrays
    {
        [TestMethod]
        public async Task TestBoolArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<bool>(Randomizer.GenRandBoolList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseBOOLArray", TagType.Bool, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseBOOLArray", TagType.Bool, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestBoolArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<bool>(Randomizer.GenRandBoolList(128)); // Randomize first to ensure new values

            var result = await myPLC.WriteBoolArray("BaseBOOLArray", alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadBoolArray("BaseBOOLArray", 128);
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestBoolArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<bool>(Randomizer.GenRandBoolList(128)); // Randomize first to ensure new values
            await myPLC.WriteBoolArray("BaseBOOLArray", alist.ToArray(), 128);
            var updateValues = new List<bool>(Randomizer.GenRandBoolList(10));

            var result = await myPLC.WriteBoolArray("BaseBOOLArray", updateValues.ToArray(), 128, 0, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadBoolArray("BaseBOOLArray", 128, 0, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestBoolArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<bool>(Randomizer.GenRandBoolList(128)); // Randomize first to ensure new values
            await myPLC.WriteBoolArray("BaseBOOLArray", alist.ToArray(), 128);
            var updateValues = new List<bool>(Randomizer.GenRandBoolList(10));

            var result = await myPLC.WriteBoolArray("BaseBOOLArray", updateValues.ToArray(), 128, 10, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadBoolArray("BaseBOOLArray", 128, 10, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestBoolArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<bool>(Randomizer.GenRandBoolList(128)); // Randomize first to ensure new values
            await myPLC.WriteBoolArray("BaseBOOLArray", alist.ToArray(), 128);
            var updateValues = new List<bool>(Randomizer.GenRandBoolList(10));

            var result = await myPLC.WriteBoolArray("BaseBOOLArray", updateValues.ToArray(), 128, 128, 10);
            Assert.AreEqual("Failure, Out of bounds", result.Status);

        }

        [TestMethod]
        public async Task TestBoolArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<bool>(Randomizer.GenRandBoolList(128)); // Randomize first to ensure new values
            await myPLC.WriteBoolArray("BaseBOOLArray", alist.ToArray(), 128);
            var updateValues = new List<bool>(Randomizer.GenRandBoolList(10));

            var result = await myPLC.WriteBoolArray("BaseBOOLArray", updateValues.ToArray(), 128, 118, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadBoolArray("BaseBOOLArray", 128, 118, 10);
            Assert.IsTrue(result2.Value.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestBoolReadArray2D()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.ReadBoolArray2D("SmallBOOLArray2D", 32, 32);
            Assert.AreEqual("Success", result.Status);

            await Task.Delay(1000);

            var result1 = await myPLC.WriteBoolArray2D("SmallBOOLArray2D", result.Value, 32, 32);
            Assert.AreEqual("Success", result1.Status);
        }

        [TestMethod]
        public async Task TestBoolReadArray3D()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.ReadBoolArray3D("BaseBOOLArray3D", 32, 32, 32);
            Assert.AreEqual("Success", result.Status);

            await Task.Delay(1000);

            var result1 = await myPLC.WriteBoolArray3D("BaseBOOLArray3D", result.Value, 32, 32, 32);
            Assert.AreEqual("Success", result1.Status);
        }
    }
}
