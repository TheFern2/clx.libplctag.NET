using libplctag.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace thefern.libplctag.NET.Tests
{
    [TestClass]
    public class WriteReadTags
    {
        [TestMethod]
        public async Task TestBoolWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseBOOL", TagType.Bool, false);
            var result = await myPLC.Read("BaseBOOL", TagType.Bool);
            Assert.AreEqual(result.Value, "False");

            await myPLC.Write("BaseBOOL", TagType.Bool, true);
            var result2 = await myPLC.Read("BaseBOOL", TagType.Bool);
            Assert.AreEqual(result2.Value, "True");
        }

        [TestMethod]
        public async Task TestBoolWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            var result = await myPLC.ReadTag<BoolPlcMapper, bool>("BaseBOOL");
            //Assert.AreEqual(result.Value, typeof(bool));
            Assert.IsInstanceOfType(result.Value, typeof(bool));
        }

        [TestMethod]
        public async Task TestDintWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseDINT", TagType.Dint, -545437491);
            var result = await myPLC.Read("BaseDINT", TagType.Dint);
            Assert.AreEqual(result.Value, "-545437491");
            await myPLC.Write("BaseDINT", TagType.Dint, -545437485);
            var result2 = await myPLC.Read("BaseDINT", TagType.Dint);
            Assert.AreEqual(result2.Value, "-545437485");
        }

        [TestMethod]
        public async Task TestDintWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseDINT", TagType.Dint, -545437493);
            var result = await myPLC.ReadTag<DintPlcMapper, int>("BaseDINT");
            Assert.AreEqual(result.Value, -545437493);
            Assert.IsInstanceOfType(result.Value, typeof(int));
            await myPLC.Write("BaseDINT", TagType.Dint, -545437484);
            var result2 = await myPLC.ReadTag<DintPlcMapper, int>("BaseDINT");
            Assert.AreEqual(result2.Value, -545437484);
            Assert.IsInstanceOfType(result2.Value, typeof(int));
        }

        [TestMethod]
        public async Task TestIntWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseINT", TagType.Int, (short)8012);
            var result = await myPLC.Read("BaseINT", TagType.Int);
            Assert.AreEqual(result.Value, "8012");
            await myPLC.Write("BaseINT", TagType.Int, (short)8009);
            var result2 = await myPLC.Read("BaseINT", TagType.Int);
            Assert.AreEqual(result2.Value, "8009");
        }

        [TestMethod]
        public async Task TestIntWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.WriteTag<IntPlcMapper, short>("BaseINT", 7999);
            var result = await myPLC.ReadTag<IntPlcMapper, short>("BaseINT");
            Assert.AreEqual(result.Value, 7999);
            Assert.IsInstanceOfType(result.Value, typeof(short));
            await myPLC.WriteTag<IntPlcMapper, short>("BaseINT", 6512);
            var result2 = await myPLC.ReadTag<IntPlcMapper, short>("BaseINT");
            Assert.AreEqual(result2.Value, 6512);
            Assert.IsInstanceOfType(result2.Value, typeof(short));
        }

        [TestMethod]
        public async Task TestLintWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseLINT", TagType.Lint, (long)-576406435);
            var result = await myPLC.Read("BaseLINT", TagType.Lint);
            Assert.AreEqual(result.Value, "-576406435");
            await myPLC.Write("BaseLINT", TagType.Lint, (long)566406435);
            var result2 = await myPLC.Read("BaseLINT", TagType.Lint);
            Assert.AreEqual(result2.Value, "566406435");
        }

        [TestMethod]
        public async Task TestLintWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.WriteTag<LintPlcMapper, long>("BaseLINT", -576403435);
            var result = await myPLC.ReadTag<LintPlcMapper, long>("BaseLINT");
            Assert.AreEqual(result.Value, -576403435);
            Assert.IsInstanceOfType(result.Value, typeof(long));
            await myPLC.WriteTag<LintPlcMapper, long>("BaseLINT", 566906435);
            var result2 = await myPLC.ReadTag<LintPlcMapper, long>("BaseLINT");
            Assert.AreEqual(result2.Value, 566906435);
            Assert.IsInstanceOfType(result2.Value, typeof(long));
        }

        [TestMethod]
        public async Task TestSintWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseSINT", TagType.Sint, (sbyte)-62);
            var result = await myPLC.Read("BaseSINT", TagType.Sint);
            Assert.AreEqual(result.Value, "-62");
            await myPLC.Write("BaseSINT", TagType.Sint, (sbyte)64);
            var result2 = await myPLC.Read("BaseSINT", TagType.Sint);
            Assert.AreEqual(result2.Value, "64");
        }

        [TestMethod]
        public async Task TestSintWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.WriteTag<SintPlcMapper, sbyte>("BaseSINT", 65);
            var result = await myPLC.ReadTag<SintPlcMapper, sbyte>("BaseSINT");
            Assert.AreEqual(result.Value, 65);
            Assert.IsInstanceOfType(result.Value, typeof(sbyte));
            await myPLC.WriteTag<SintPlcMapper, sbyte>("BaseSINT", -65);
            var result2 = await myPLC.ReadTag<SintPlcMapper, sbyte>("BaseSINT");
            Assert.AreEqual(result2.Value, -65);
            Assert.IsInstanceOfType(result2.Value, typeof(sbyte));
        }

        [TestMethod]
        public async Task TestRealWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseREAL", TagType.Real, (float)2);
            var result = await myPLC.Read("BaseREAL", TagType.Real);
            Assert.AreEqual(result.Value, "2");
            await myPLC.Write("BaseREAL", TagType.Real, (float)2.7);
            var result2 = await myPLC.Read("BaseREAL", TagType.Real);
            Assert.AreEqual(result2.Value, "2.7");
        }

        [TestMethod]
        public async Task TestRealWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseREAL", TagType.Real, 2);
            var result = await myPLC.ReadTag<RealPlcMapper, float>("BaseREAL");
            Assert.AreEqual(result.Value, 2);
            Assert.IsInstanceOfType(result.Value, typeof(float));
            await myPLC.Write("BaseREAL", TagType.Real, (float?)2.5);
            var result2 = await myPLC.ReadTag<RealPlcMapper, float>("BaseREAL");
            Assert.AreEqual(result2.Value, 2.5);
            Assert.IsInstanceOfType(result2.Value, typeof(float));
        }

        [TestMethod]
        public async Task TestStringWithRead()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseSTRING", TagType.String, "yXbDjcoUjcYjRQDxnZTeDCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            var result = await myPLC.Read("BaseSTRING", TagType.String);
            Assert.AreEqual(result.Value, "yXbDjcoUjcYjRQDxnZTeDCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            await myPLC.Write("BaseSTRING", TagType.String, "yFbDjcoUjcYjRQDxnZTeDCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            var result2 = await myPLC.Read("BaseSTRING", TagType.String);
            Assert.AreEqual(result2.Value, "yFbDjcoUjcYjRQDxnZTeDCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
        }

        [TestMethod]
        public async Task TestStringWithReadTag()
        {
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);
            await myPLC.Write("BaseSTRING", TagType.String, "yXbDjcoUjcYjRQDxnYTeDCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            var result = await myPLC.ReadTag<StringPlcMapper, string>("BaseSTRING");
            Assert.AreEqual(result.Value, "yXbDjcoUjcYjRQDxnYTeDCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            Assert.IsInstanceOfType(result.Value, typeof(string));
            await myPLC.Write("BaseSTRING", TagType.String, "yFbDjcoUjcYjRQDxnZTeXCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            var result2 = await myPLC.ReadTag<StringPlcMapper, string>("BaseSTRING");
            Assert.AreEqual(result2.Value, "yFbDjcoUjcYjRQDxnZTeXCdZuOTXrJMHJIBeZPgUEPsTjqLNNk");
            Assert.IsInstanceOfType(result2.Value, typeof(string));
        }
    }
}
