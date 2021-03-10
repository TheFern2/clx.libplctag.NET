using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libplctag;
using libplctag.DataTypes;
using libplctag.NativeImport;
using thefern.libplctag.NET.Tests;

namespace thefern.libplctag.NET.TestProgram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
             * This is just a playground for testing the library.
             */

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

            /*var tagHandle = plctag.plc_tag_create("protocol=ab_eip&gateway=192.168.1.196&path=1,2&plc=LGX&elem_size=4&elem_count=4&debug=1&name=SmallDINTArray", 1000);
            plctag.plc_tag_read(tagHandle, 1000);

            var value = plctag.plc_tag_get_int32(tagHandle, 0);
            Console.WriteLine(value);
            // plctag.plc_tag_set_uint8(tagHandle, 0, 255);
            plctag.plc_tag_set_int32(tagHandle, 0, 1);
            plctag.plc_tag_write(tagHandle, 1000);
            plctag.plc_tag_read(tagHandle, 1000);
            var value2 = plctag.plc_tag_get_int32(tagHandle, 0);
            Console.WriteLine(value2);*/

            var result9 = await myPLC.Read("BaseBOOLArray", TagType.Bool, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result9.Value));

            var result10 = await myPLC.Read("BaseDINTArray", TagType.Dint, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result10.Value));

            var result11 = await myPLC.Read("BaseINTArray", TagType.Int, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result11.Value));

            var result12 = await myPLC.Read("BaseLINTArray", TagType.Lint, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result12.Value));

            var result13 = await myPLC.Read("BaseSINTArray", TagType.Sint, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result13.Value));

            var result14 = await myPLC.Read("BaseREALArray", TagType.Real, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result14.Value));

            var result15 = await myPLC.Read("BaseSTRINGArray", TagType.String, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result15.Value));

        }
    }
}
