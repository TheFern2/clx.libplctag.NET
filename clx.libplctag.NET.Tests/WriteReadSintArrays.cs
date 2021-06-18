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
    public class WriteReadSintArrays
    {
        [TestMethod]
        public async Task TestSintArrayWithReadWrite()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseSINTArray", TagType.Sint, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseSINTArray", TagType.Sint, 128);
            string[] arrString = Array.ConvertAll(alist.ToArray(), Convert.ToString);
            Assert.IsTrue(result2.Value.SequenceEqual(arrString));
        }

        [TestMethod]
        public async Task TestSintArrayWithReadWriteArray()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(128)); // Randomize first to ensure new values

            var result = await myPLC.Write("BaseSINTArray", TagType.Sint, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadTag<SintPlcMapper, sbyte[]>("BaseSINTArray", new int[] { 128 });
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestSintArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseSINTArray", TagType.Sint, alist.ToArray(), 128);
            var updateValues = new List<sbyte>(Randomizer.GenRandSbyteList(10));

            var result = await myPLC.Write("BaseSINTArray[0]", TagType.Sint, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseSINTArray", TagType.Sint, 128, 0, 10);
            sbyte[] arrSbyte = Array.ConvertAll(result2.Value, Convert.ToSByte);
            Assert.IsTrue(arrSbyte.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestSintArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseSINTArray", TagType.Sint, alist.ToArray(), 128);
            var updateValues = new List<sbyte>(Randomizer.GenRandSbyteList(10));

            var result = await myPLC.Write("BaseSINTArray[10]", TagType.Sint, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseSINTArray", TagType.Sint, 128, 10, 10);
            sbyte[] arrSbyte = Array.ConvertAll(result2.Value, Convert.ToSByte);
            Assert.IsTrue(arrSbyte.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestSintArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseSINTArray", TagType.Sint, alist.ToArray(), 128);
            var updateValues = new List<sbyte>(Randomizer.GenRandSbyteList(10));

            var result = await myPLC.Write("BaseSINTArray[119]", TagType.Sint, updateValues.ToArray(), 128);
            Assert.AreEqual("MismatchLength", result.Status);

        }

        [TestMethod]
        public async Task TestSintArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseSINTArray", TagType.Sint, alist.ToArray(), 128);
            var updateValues = new List<sbyte>(Randomizer.GenRandSbyteList(10));

            var result = await myPLC.Write("BaseSINTArray[118]", TagType.Sint, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseSINTArray", TagType.Sint, 128, 118, 10);
            sbyte[] arrSbyte = Array.ConvertAll(result2.Value, Convert.ToSByte);
            Assert.IsTrue(arrSbyte.SequenceEqual(updateValues.ToArray()));
        }
    }
}
