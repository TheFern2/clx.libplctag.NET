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
    public class WriteReadIntArrays
    {
        [TestMethod]
        public async Task TestIntArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseINTArray", TagType.Int, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestIntArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadTag<IntPlcMapper, short[]>("BaseINTArray", new int[] { 128 });
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestIntArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            var updateValues = new List<short>(Randomizer.GenRandShortList(10));

            var result = await myPLC.Write("BaseINTArray", TagType.Int, updateValues.ToArray(), 128, 0, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseINTArray", TagType.Int, 128, 0, 10);
            short[] arrShort = Array.ConvertAll(result2.Value, Convert.ToInt16);
            Assert.IsTrue(arrShort.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestIntArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            var updateValues = new List<short>(Randomizer.GenRandShortList(10));

            var result = await myPLC.Write("BaseINTArray", TagType.Int, updateValues.ToArray(), 128, 10, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseINTArray", TagType.Int, 128, 10,10);
            short[] arrShort = Array.ConvertAll(result2.Value, Convert.ToInt16);
            Assert.IsTrue(arrShort.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestIntArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            var updateValues = new List<short>(Randomizer.GenRandShortList(10));

            var result = await myPLC.Write("BaseINTArray[119]", TagType.Int, updateValues.ToArray(), 128);
            Assert.AreEqual("MismatchLength", result.Status);

        }

        [TestMethod]
        public async Task TestIntArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            var updateValues = new List<short>(Randomizer.GenRandShortList(10));

            var result = await myPLC.Write("BaseINTArray", TagType.Int, updateValues.ToArray(), 128, 118, 10);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseINTArray", TagType.Int, 128, 118,10);
            short[] arrShort = Array.ConvertAll(result2.Value, Convert.ToInt16);
            Assert.IsTrue(arrShort.SequenceEqual(updateValues.ToArray()));
        }
    }
}
