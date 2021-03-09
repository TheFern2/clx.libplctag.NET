using System;
using System.Threading.Tasks;
using libplctag;
using libplctag.DataTypes;

namespace thefern.libplctag.NET.TestProgram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myPLC = new PLC("192.168.1.196", 2);
            var result = await myPLC.Read("BaseBOOL", TagType.Bool);
            Console.WriteLine(result);

            var result0 = await myPLC.Read("BaseBOOLsdfsdf", TagType.Bool);
            Console.WriteLine(result0);

            var result2 = await myPLC.Read("BaseBOOL", TagType.Bit);
            Console.WriteLine(result2);

            var result3 = await myPLC.Read("BaseDINT", TagType.Dint);
            Console.WriteLine(result3);

            var result33 = await myPLC.Read("BaseDINTssdfsdf", TagType.Dint);
            Console.WriteLine(result33);

            var result4 = await myPLC.Read("BaseINT", TagType.Int);
            Console.WriteLine(result4);

            var result5 = await myPLC.Read("BaseSINT", TagType.Sint);
            Console.WriteLine(result5);

            var result6 = await myPLC.Read("BaseLINT", TagType.Lint);
            Console.WriteLine(result6);

            var result7 = await myPLC.Read("BaseREAL", TagType.Real);
            Console.WriteLine(result7);

            var result8 = await myPLC.Read("BaseSTRING", TagType.String);
            Console.WriteLine(result8);

            // individual tags
            var result88 = await myPLC.ReadBoolTag("BaseBOOL");
            Console.WriteLine(result88.Value.GetType());
            

            /*var tag2 = new Tag<BoolPlcMapper, bool>()
            {
                Name = "BaseBOOLArray[13]",
                Gateway = "192.168.1.196",
                Path = "1,2",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(5)
            };

            await tag2.InitializeAsync();
            tag2.Value = true;
            await tag2.WriteAsync();
            await tag2.ReadAsync();
            Console.WriteLine("tag2: " + tag2.Value);*/

            var writeResults = await myPLC.Write("BaseBOOL", TagType.Bool, true);
            //var writeResults = await myPLC.WriteDintTag("BaseDINT", -545437486);
            Console.WriteLine(writeResults);
        }
    }
}
