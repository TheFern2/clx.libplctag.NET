using System.Collections.Generic;
using libplctag.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace clx.libplctag.NET.Tests
{
    [TestClass]
    public class MultipleTags
    {
        [TestMethod]
        public async Task TestMultipleTagsReadWrite()
        {
            // Reading multiple tags with one PLC instance
            var myPLC = new PLC(Configuration.ipAddress, Configuration.slot);

            var boolValue = new List<bool>(Randomizer.GenRandBoolList(1));
            var dintValue = new List<int>(Randomizer.GenRandIntList(1));
            var intValue = new List<short>(Randomizer.GenRandShortList(1));

            await myPLC.Write("BaseBOOL", TagType.Bool, boolValue[0]);
            await myPLC.Write("BaseDINT", TagType.Dint, dintValue[0]);
            await myPLC.Write("BaseINT", TagType.Int, intValue[0]);
            
            var result = await myPLC.Read("BaseBOOL", TagType.Bool);
            Assert.AreEqual(boolValue[0].ToString(), result.Value);
            var result2 = await myPLC.Read("BaseDINT", TagType.Dint);
            Assert.AreEqual(dintValue[0].ToString(), result2.Value);
            var result3 = await myPLC.Read("BaseINT", TagType.Int);
            Assert.AreEqual(intValue[0].ToString(), result3.Value);

        }
    }
}