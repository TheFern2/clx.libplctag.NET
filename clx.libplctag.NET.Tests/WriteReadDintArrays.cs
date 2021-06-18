using libplctag.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace clx.libplctag.NET.Tests
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

            var result = await myPLC.Write("BaseDINTArray", TagType.Dint, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadTag<DintPlcMapper, int[]>("BaseDINTArray", new int[] { 128 });
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestDintArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseDINTArray", TagType.Dint, alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.Write("BaseDINTArray[0]", TagType.Dint, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseDINTArray[0]", TagType.Dint, 128,10);
            int[] arrInt = Array.ConvertAll(result2.Value, Convert.ToInt32);
            Assert.IsTrue(arrInt.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestDintArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseDINTArray", TagType.Dint, alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.Write("BaseDINTArray[10]", TagType.Dint, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseDINTArray[10]", TagType.Dint, 128, 10);
            int[] arrInt = Array.ConvertAll(result2.Value, Convert.ToInt32);
            Assert.IsTrue(arrInt.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestDintArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseDINTArray", TagType.Dint, alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.Write("BaseDINTArray[119]", TagType.Dint, updateValues.ToArray(), 128);
            Assert.AreEqual("MismatchLength", result.Status);

        }

        [TestMethod]
        public async Task TestDintArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<int>(Randomizer.GenRandIntList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseDINTArray", TagType.Dint, alist.ToArray(), 128);
            var updateValues = new List<int>(Randomizer.GenRandIntList(10));

            var result = await myPLC.Write("BaseDINTArray[118]", TagType.Dint, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseDINTArray[118]", TagType.Dint, 128, 10);
            int[] arrInt = Array.ConvertAll(result2.Value, Convert.ToInt32);
            Assert.IsTrue(arrInt.SequenceEqual(updateValues.ToArray()));
        }
    }
}
