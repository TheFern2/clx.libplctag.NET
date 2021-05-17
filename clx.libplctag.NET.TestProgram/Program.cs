using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libplctag;
using libplctag.DataTypes;
using libplctag.NativeImport;
using clx.libplctag.NET.Tests;
using System.Diagnostics;

namespace clx.libplctag.NET.TestProgram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
             * This is just a playground for testing the library.
             */

            var myPLC = new PLC("192.168.1.196", 2);
            /*var result = await myPLC.Read("BaseBOOL", TagType.Bool).ConfigureAwait(false);
            Console.WriteLine(result);

            var result0 = await myPLC.Read("BaseBOOLsdfsdf", TagType.Bool);
            Console.WriteLine(result0);

            var result2 = await myPLC.Read("BaseBOOL", TagType.Bit);
            Console.WriteLine(result2);

            var result3 = await myPLC.Read("BaseDINT", TagType.Dint);
            Console.WriteLine(result3);

            var result33 = await myPLC.Read("BaseDINTssdfsdf", TagType.Dint).ConfigureAwait(false);
            Console.WriteLine(result33);

            var result4 = await myPLC.Read("BaseINT", TagType.Int);
            Console.WriteLine(result4);

            var result5 = await myPLC.Read("BaseSINT", TagType.Sint).ConfigureAwait(false);
            Console.WriteLine(result5);

            var result6 = await myPLC.Read("BaseLINT", TagType.Lint);
            Console.WriteLine(result6);

            var result7 = await myPLC.Read("BaseREAL", TagType.Real);
            Console.WriteLine(result7);

            var result8 = await myPLC.Read("BaseSTRING", TagType.String);
            Console.WriteLine(result8);

            */
            /*var tagHandle = plctag.plc_tag_create("protocol=ab_eip&gateway=192.168.1.196&path=1,2&plc=LGX&elem_size=4&elem_count=4&debug=1&name=SmallDINTArray", 1000);
                       plctag.plc_tag_read(tagHandle, 1000);
           
                       var value = plctag.plc_tag_get_int32(tagHandle, 0);
                       Console.WriteLine(value);
                       // plctag.plc_tag_set_uint8(tagHandle, 0, 255);
                       plctag.plc_tag_set_int32(tagHandle, 0, 1);
                       plctag.plc_tag_write(tagHandle, 1000);
                       plctag.plc_tag_read(tagHandle, 1000);
                       var value2 = plctag.plc_tag_get_int32(tagHandle, 0);
                       Console.WriteLine(value2);*/ /*

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
            Console.WriteLine("[{0}]", string.Join(", ", result15.Value));*/

            // AsyncTest.SyncAsyncComparison();
            /*var result15 = await myPLC.Read("BaseINTArray", TagType.Int, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result15.Value));

            var alist = new List<short>(Randomizer.GenRandShortList(128)); // Randomize first to ensure new values
            Console.WriteLine("[{0}]", string.Join(", ", alist));

            // short[] myArray = new short[] { 19110, 20088, 32763, 5789, -27593, 6672, -10796, 9376, -9293, 21946, -24828, 17287, 24677, 26733, -8161, 11453, -12396, -17640, -2687, -12214, -15676, -29839, -29818, 4299, -17709, 24160, 17833, -25770, -13273, -22881, -5770, -11422, 9968, 32364, -19276, 24363, -23486, -27436, 16574, -320, 16137, -21880, 4083, -32279, 1010, -12202, -6704, 11058, 12130, 9892, -25291, 27870, 4139, -3218, -4299, 16180, 17138, -4305, -9270, -18986, 21605, -17794, -10119, -19180, -5052, 19361, -25450, 25080, 13240, 243, 2170, -17728, -1447, 30400, 4416, -26565, -1155, -30308, -29480, 27260, -1905, -25993, -5134, 9601, -30359, -874, 17206, -19582, 3895, -2689, -25544, 13585, 14601, 2792, 10841, 1163, 21006, -9505, 5540, 14416, -19521, 983, 30584, -20881, -25047, 25203, -3451, 6505, 25132, -10503, -15433, 14677, -7593, -3764, 15685, 14829, 20106, 13046, -21590, 28588, -30613, 26899, -11584, -16839, -6982, 21352, 438, 28527 };

            var result50 = await myPLC.Write("BaseINTArray", TagType.Int, alist.ToArray(), 128);
            //var result50 = await myPLC.WriteIntArray("BaseINTArray", myArray, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result50.Value));

            var result51 = await myPLC.ReadBoolArray2D("BaseBOOLArray2D", 32, 32);
            Console.WriteLine("[{0}]", string.Join(", ", result51));
            //Console.WriteLine("[{0}]", string.Join(", ", result51.Value.Cast<bool>()));
            Console.WriteLine(String.Join(", ", result51.Value.Cast<bool>()));*/

            // var result = await myPLC.ReadBoolArray2D("SmallBOOLArray2D", 32, 32);
            // Console.WriteLine("[{0}]", string.Join(", ", result.Value.Length));

            // await Task.Delay(8000);

            // var result1 = await myPLC.WriteBoolArray2D("SmallBOOLArray2D", result.Value, 32, 32);
            // Console.WriteLine(String.Join(", ", result1.Value.Cast<bool>()));
            /*var result = await myPLC.ReadTag<BoolPlcMapper, bool>("BaseBOOL");
            Console.WriteLine("[{0}]", string.Join(", ", result));

            var result1 = await myPLC.ReadTag<BoolPlcMapper, bool>("BaseBOOLsdfsd");
            Console.WriteLine("[{0}]", string.Join(", ", result1));

            var result2 = await myPLC.ReadTag<DintPlcMapper, int>("BaseDINT");
            Console.WriteLine("[{0}]", string.Join(", ", result2));

            var result3 = await myPLC.ReadTag<DintPlcMapper, int>("BaseDINTsdfsdf");
            Console.WriteLine("[{0}]", string.Join(", ", result3));

            var result4 = await myPLC.ReadTag<BoolArrayPlcMapper, bool[]>("BaseBOOLArray", new int[] { 128 });
            Console.WriteLine("[{0}]", string.Join(", ", result4));

            var result5 = await myPLC.ReadTag<BoolArrayPlcMapper, bool[,]>("SmallBOOLArray2D", new int[] { 32, 32 });
            Console.WriteLine("[{0}]", string.Join(", ", result5));
            //Console.WriteLine(String.Join(", ", result5.Value.Cast<bool>()));

            var result6 = await myPLC.ReadTag<BoolArrayPlcMapper, bool[,,]>("BaseBOOLArray3D", new int[] { 32, 32, 32 });
            Console.WriteLine("[{0}]", string.Join(", ", result6));
            //Console.WriteLine(String.Join(", ", result6.Value.Cast<bool>()));

            var result7 = await myPLC.Read("BaseBOOLArray", TagType.Bool, 128);
            Console.WriteLine("[{0}]", string.Join(", ", result7.Value));
            System.Console.WriteLine(result7.Value.GetType());

            var result8 = await myPLC.ReadTag<BoolArrayPlcMapper, bool[]>("BaseBOOLArray", new int[] { 128 });
            Console.WriteLine("[{0}]", string.Join(", ", result8.Value));

            var result9 = await myPLC.WriteTag<BoolPlcMapper, bool>("BaseBOOL", true);
            Console.WriteLine("[{0}]", string.Join(", ", result9));

            // write a whole bool array
            List<string> boolList = new List<string>(Randomizer.GenRandStringList(10));
            var result10 = await myPLC.Write("BaseSTRINGArray", TagType.String, boolList.ToArray(), 128, 0, 10);
            Console.WriteLine("[{0}]", string.Join(", ", result10));

            var result11 = await myPLC.Read("BaseSTRINGArray", TagType.String, 128, 0, 10);
            Console.WriteLine("[{0}]", string.Join(", ", result11.Value));

            var result12 = await myPLC.WriteTag<DintPlcMapper, int>("BaseDINT", 545437492);
            Console.WriteLine("[{0}]", string.Join(", ", result12));

            var result13 = await myPLC.Write("BaseDINT", TagType.Dint, 545437493);
            Console.WriteLine("[{0}]", string.Join(", ", result13));*/

            /*Dictionary<string, TagType> taglist = new Dictionary<string, TagType>
            {
                { "BaseBOOL", TagType.Bool },
                { "BaseDINT", TagType.Dint },
                { "BaseSTRING", TagType.String },
                { "BaseSINT", TagType.Sint },
                { "BaseLINT", TagType.Lint },
                { "BaseREAL", TagType.Real }
            };

            List<Response<string>> responseList = new List<Response<string>>();
            responseList = await myPLC.ReadTags(taglist);

            foreach (var item in responseList)
            {
                Console.WriteLine(item.ToString());
            }*/

            /*List<Tag<DintPlcMapper, int>> myTags;
            var numberOfTags = 1000;

            for (int ii = 0; ii < numberOfTags; ii++)
            {
                myTags = Enumerable.Range(0, numberOfTags)
                .Select(i => {
                    var myTag = new Tag<DintPlcMapper, int>()
                    {
                        Name = $"YugeArray[{i}]",
                        Gateway = "192.168.1.196",
                        Path = "1,2",
                        PlcType = PlcType.ControlLogix,
                        Protocol = Protocol.ab_eip,
                        Timeout = TimeSpan.FromMilliseconds(1000),
                    };
                    myTag.Initialize();
                    return myTag;
                })
                .ToList();

                int repetitions = 10;

                // Create list of tasks
                var taskList = new List<Task>();
                for (int i = 0; i < numberOfTags; i++)
                {
                    var t = new Task(() =>
                    {
                        myTags[i].ReadAsync();
                    });
                }

                Console.Write($"Running {repetitions} ReadAsync() calls...\n");
                var asyncStopWatch = new Stopwatch();
                asyncStopWatch.Start();
                for (int jj = 0; jj < repetitions; jj++)
                {            
                    Task.WaitAll(taskList.ToArray());
                   
                }
                */ /*Console.WriteLine(myTags[4].Value);
                Console.WriteLine(myTags[499].Value);*/ /*
                asyncStopWatch.Stop();

                Console.WriteLine(asyncStopWatch.Elapsed.Milliseconds);
                Console.WriteLine($"\ttook {(float)asyncStopWatch.Elapsed.TotalMilliseconds / (float)repetitions}ms on average");
            }*/

            //AsyncTest.AsyncProfile(100, 1);
            //AsyncTest.SyncAsyncComparison();

            // create some tags
            var numberOfTags = 300;
            var listOfTags = new List<string>();
            for (int i = 0; i < numberOfTags; i++)
            {
                Console.WriteLine($"Creating list of tags: YugeArray[{i}]");
            }

            var result = new Response<string>();
            var responses = new List<Response<string>>();
            while (true)
            {
                /*result = await myPLC.Read("BaseDINT", TagType.Dint);
                Console.WriteLine(result);*/
                responses.Clear();
                

                Console.WriteLine(result);
                for (int i = 0; i < numberOfTags; i++)
                {
                    result = await myPLC.Read($"YugeArray[{i}]", TagType.Dint);
                    responses.Add(result);
                    Console.WriteLine(result);
                }
                await Task.Delay(500);
            }
        }
    }
}