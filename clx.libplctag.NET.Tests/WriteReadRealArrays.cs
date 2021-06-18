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

            var result = await myPLC.Write("BaseREALArray", TagType.Real, alist.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.ReadTag<RealPlcMapper, float[]>("BaseREALArray", new int[] { 128 });
            Assert.IsTrue(result2.Value.SequenceEqual(alist.ToArray()));
        }

        [TestMethod]
        public async Task TestRealArrayRange01()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseREALArray", TagType.Real, alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.Write("BaseREALArray[0]", TagType.Real, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseREALArray", TagType.Real, 128, 0, 10);
            float[] arrFloat = Array.ConvertAll(result2.Value, Convert.ToSingle);
            Assert.IsTrue(arrFloat.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestRealArrayRange02()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseREALArray", TagType.Real, alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.Write("BaseREALArray[10]", TagType.Real, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseREALArray", TagType.Real, 128, 10, 10);
            float[] arrFloat = Array.ConvertAll(result2.Value, Convert.ToSingle);
            Assert.IsTrue(arrFloat.SequenceEqual(updateValues.ToArray()));
        }

        [TestMethod]
        public async Task TestRealArrayRange03()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseREALArray", TagType.Real, alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.Write("BaseREALArray[119]", TagType.Real, updateValues.ToArray(), 128);
            Assert.AreEqual("MismatchLength", result.Status);

        }

        [TestMethod]
        public async Task TestRealArrayRange04()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var alist = new List<float>(Randomizer.GenRandFloatList(128)); // Randomize first to ensure new values
            await myPLC.Write("BaseREALArray", TagType.Real, alist.ToArray(), 128);
            var updateValues = new List<float>(Randomizer.GenRandFloatList(10));

            var result = await myPLC.Write("BaseREALArray[118]", TagType.Real, updateValues.ToArray(), 128);
            Assert.AreEqual("Success", result.Status);

            var result2 = await myPLC.Read("BaseREALArray", TagType.Real, 128, 118, 10);
            float[] arrFloat = Array.ConvertAll(result2.Value, Convert.ToSingle);
            Assert.IsTrue(arrFloat.SequenceEqual(updateValues.ToArray()));
        }
    }
}
