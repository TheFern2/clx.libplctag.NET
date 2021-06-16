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
    public class SingleArrayItems
    {
        [TestMethod]
        public async Task TestBoolArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseBOOLArray[6]", TagType.Bool);
            Assert.AreEqual("Success", result.Status);
            
            /*var alist = new List<bool>(Randomizer.GenRandBoolList(1));
            result = await myPLC.Write("BaseBOOLArray[6]", TagType.Bool, alist[0]);
            Assert.AreEqual("Success", result.Status);*/
        }
        
        [TestMethod]
        public async Task TestDintArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseDINTArray[5]", TagType.Dint);
            Assert.AreEqual("Success", result.Status);
            
            var alist = new List<int>(Randomizer.GenRandIntList(1));
            result = await myPLC.Write("BaseDINTArray[5]", TagType.Dint, alist[0]);
            Assert.AreEqual("Success", result.Status);
        }
        
        [TestMethod]
        public async Task TestIntArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseINTArray[6]", TagType.Int);
            Assert.AreEqual("Success", result.Status);
            
            var alist = new List<short>(Randomizer.GenRandShortList(1));
            result = await myPLC.Write("BaseINTArray[6]", TagType.Int, alist[0]);
            Assert.AreEqual("Success", result.Status);
        }
        
        [TestMethod]
        public async Task TestSintArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseSINTArray[6]", TagType.Sint);
            Assert.AreEqual("Success", result.Status);
            
            var alist = new List<sbyte>(Randomizer.GenRandSbyteList(1));
            result = await myPLC.Write("BaseSINTArray[6]", TagType.Sint, alist[0]);
            Assert.AreEqual("Success", result.Status);
        }
        
        [TestMethod]
        public async Task TestLintArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseLINTArray[6]", TagType.Lint);
            Assert.AreEqual("Success", result.Status);
            
            var alist = new List<long>(Randomizer.GenRandLongList(1));
            result = await myPLC.Write("BaseLINTArray[6]", TagType.Lint, alist[0]);
            Assert.AreEqual("Success", result.Status);
        }
        
        [TestMethod]
        public async Task TestRealArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseREALArray[6]", TagType.Real);
            Assert.AreEqual("Success", result.Status);
            
            var alist = new List<float>(Randomizer.GenRandFloatList(1));
            result = await myPLC.Write("BaseREALArray[6]", TagType.Real, alist[0]);
            Assert.AreEqual("Success", result.Status);
        }
        
        [TestMethod]
        public async Task TestStringArraySingleItem()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.Read("BaseSTRINGArray[6]", TagType.String);
            Assert.AreEqual("Success", result.Status);
            
            var alist = new List<string>(Randomizer.GenRandStringList(1));
            result = await myPLC.Write("BaseSTRINGArray[6]", TagType.String, alist[0]);
            Assert.AreEqual("Success", result.Status);
        }
    }
}