using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class ReadTags
    {
        /*[TestMethod]
        public async Task TestBoolWithRead()
        {
            var myPLC = new PLC("192.168.1.196", 2);
            await myPLC.Write("BaseBOOL", TagType.Bool, false);
            var result = await myPLC.Read("BaseBOOL", TagType.Bool);
            Assert.AreEqual(result.Value, "False");
            await myPLC.Write("BaseBOOL", TagType.Bool, true);
            var result2 = await myPLC.Read("BaseBOOL", TagType.Bool);
            Assert.AreEqual(result2.Value, "True");
        }

        [TestMethod]
        public async Task TestBoolWithReadBoolTag()
        {
            var myPLC = new PLC("192.168.1.196", 2);
            var result = await myPLC.ReadBoolTag("BaseBOOL");
            Assert.AreEqual(result.Value, typeof(bool));            
        }*/

        [TestMethod]
        public async Task TestDintWithRead()
        {
            var myPLC = new PLC("192.168.1.196", 2);
            await myPLC.Write("BaseDINT", TagType.Dint, -545437491);
            var result = await myPLC.Read("BaseDINT", TagType.Dint);
            Assert.AreEqual(result.Value, "-545437491");
            await myPLC.Write("BaseDINT", TagType.Dint, -545437485);
            var result2 = await myPLC.Read("BaseDINT", TagType.Dint);
            Assert.AreEqual(result2.Value, "-545437485");
        }

        [TestMethod]
        public async Task TestDintWithReadDintTag()
        {
            var myPLC = new PLC("192.168.1.196", 2);
            await myPLC.Write("BaseDINT", TagType.Dint, -545437491);
            var result = await myPLC.ReadDintTag("BaseDINT");
            Assert.AreEqual(result.Value, -545437491);
            await myPLC.Write("BaseDINT", TagType.Dint, -545437484);
            var result2 = await myPLC.ReadDintTag("BaseDINT");
            Assert.AreEqual(result2.Value, -545437484);
        }
    }
}
