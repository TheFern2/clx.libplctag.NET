using libplctag;
using libplctag.DataTypes;
using libplctag.NativeImport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace thefern.libplctag.NET
{
    public class PLC
    {
        private string _ipAddress = "192.168.1.196";
        private string _path = "1,0";
        public int Timeout { get; set; } = 5;

        public PLC(string ipAddress, int slot)
        {
            _ipAddress = ipAddress;
            _path = "1," + slot.ToString();
        }

        /// <summary>
        /// Reads a tag from the PLC. 
        /// </summary>
        /// <param name="tagName">Tag name either a controller or program scoped tag</param>
        /// <param name="tagType">Tag type use TagType enum</param>
        /// <returns>Returns a tag value as string, regardless of tagType</returns>
        public async Task<Response<string>> Read(string tagName, TagType tagType)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    return await _ReadTag<BoolPlcMapper, bool>(tagName);
                case TagType.Bit:
                    return await _ReadTag<BoolPlcMapper, bool>(tagName);
                case TagType.Dint:
                    return await _ReadTag<DintPlcMapper, int>(tagName);
                case TagType.Int:
                    return await _ReadTag<IntPlcMapper, short>(tagName);
                case TagType.Sint:
                    return await _ReadTag<SintPlcMapper, sbyte>(tagName);
                case TagType.Lint:
                    return await _ReadTag<LintPlcMapper, long>(tagName);
                case TagType.Real:
                    return await _ReadTag<RealPlcMapper, float>(tagName);
                case TagType.String:
                    return await _ReadTag<StringPlcMapper, string>(tagName);
                default:
                    return new Response<string>(tagName, "Wrong Type");
            }
        }

        /// <summary>
        /// Reads an array from the PLC. 
        /// </summary>
        /// <param name="tagName">Tag name either a controller or program scoped tag</param>
        /// <param name="tagType">Tag type use TagType enum</param>
        /// <param name="arrayLength">Length of the array</param>
        /// <returns>Returns an array of strings, regardless of the tagType</returns>
        public async Task<Response<string[]>> Read(string tagName, TagType tagType, int arrayLength, int startIndex = 0, int count = 0)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    var resultsBoolArray = await ReadTag<BoolArrayPlcMapper, bool[]>(tagName, new int[] { arrayLength });
                    if (resultsBoolArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsBoolArray.Value, Convert.ToString);
                        // Sanity check to make sure we don't try to access items indices bigger than array
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Bit:
                    var resultsBitArray = await ReadTag<BoolArrayPlcMapper, bool[]>(tagName, new int[] { arrayLength });
                    if (resultsBitArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsBitArray.Value, Convert.ToString);
                        // Sanity check to make sure we don't try to access items indices bigger than array
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Dint:
                    var resultsDintArray = await ReadTag<DintPlcMapper, int[]>(tagName, new int[] { arrayLength });
                    if (resultsDintArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsDintArray.Value, Convert.ToString);
                        // Sanity check to make sure we don't try to access items indices bigger than array
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Int:
                    var resultsIntArray = await ReadTag<IntPlcMapper, short[]>(tagName, new int[] { arrayLength });
                    if (resultsIntArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsIntArray.Value, Convert.ToString);
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Sint:
                    var resultsSintArray = await ReadTag<SintPlcMapper, sbyte[]>(tagName, new int[] { arrayLength });
                    if (resultsSintArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsSintArray.Value, Convert.ToString);
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Lint:
                    var resultsLintArray = await ReadTag<LintPlcMapper, long[]>(tagName, new int[] { arrayLength });
                    if (resultsLintArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsLintArray.Value, Convert.ToString);
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Real:
                    var resultsRealArray = await ReadTag<RealPlcMapper, float[]>(tagName, new int[] { arrayLength });
                    if (resultsRealArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsRealArray.Value, Convert.ToString);
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.String:
                    var resultsStringArray = await ReadTag<StringPlcMapper, string[]>(tagName, new int[] { arrayLength });
                    if (resultsStringArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsStringArray.Value, Convert.ToString);
                        if (startIndex + count > arrayLength)
                        {
                            return new Response<string[]>(tagName, "Failure, Out of bounds");
                        }

                        if (count > 0)
                        {
                            List<string> tagValueList = new List<string>(arrString);
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                        }
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                default:
                    return new Response<string[]>(tagName, "Failure");
            }
        }

        private async Task<Response<string>> _ReadTag<M, T>(string tagName) where M : IPlcMapper<T>, new()
        {
            var results = await ReadTag<M, T>(tagName);
            if (results.Status == "Success")
            {
                return new Response<string>(tagName, results.Value.ToString(), "Success");
            }
            else
            {
                return new Response<string>(tagName, "Failure");
            }
        }

        // Experimenting with reading a tag list
        // Return a list of Response string objects
        public async Task<List<Response<string>>> ReadTags(Dictionary<string, TagType> taglist)
        {
            List<Response<string>> responseList = new List<Response<string>>();
            List<string> dicKeys = new List<string>(taglist.Keys);

            foreach (var tagName in dicKeys)
            {
                responseList.Add(await Read(tagName, taglist[tagName]));
            }

            return responseList;
        }

        public async Task<Response<string>> Write(string tagName, TagType tagType, object value)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    return await _WriteTag<BoolPlcMapper, bool>(tagName, (bool)value);
                case TagType.Bit:
                    return await _WriteTag<BoolPlcMapper, bool>(tagName, (bool)value);
                case TagType.Dint:
                    return await _WriteTag<DintPlcMapper, int>(tagName, (int)value);
                case TagType.Int:
                    return await _WriteTag<IntPlcMapper, short>(tagName, (short)value);
                case TagType.Sint:
                    return await _WriteTag<SintPlcMapper, sbyte>(tagName, (sbyte)value);
                case TagType.Lint:
                    return await _WriteTag<LintPlcMapper, long>(tagName, (long)value);
                case TagType.Real:
                    return await _WriteTag<RealPlcMapper, float>(tagName, (float)value);
                case TagType.String:
                    return await _WriteTag<StringPlcMapper, string>(tagName, (string)value);
                default:
                    return new Response<string>(tagName, "None", "Wrong Type");
            }
        }

        public async Task<Response<string[]>> Write(string tagName, TagType tagType, object value, int arrayLength, int startIndex = 0, int count = 0)
        {
            switch (tagType)
            {
                case TagType.Bool:

                    // read online array first
                    var readBoolArray = await ReadTag<BoolArrayPlcMapper, bool[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readBoolArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<bool> tagValueList = new List<bool>(readBoolArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<bool>)value);
                            var writeArrayRange = await WriteTag<BoolArrayPlcMapper, bool[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsBoolArray = await WriteTag<BoolArrayPlcMapper, bool[]>(tagName, (bool[])value, new int[] { arrayLength });

                    if (resultsBoolArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsBoolArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Bit:
                    // read online array first
                    var readBitArray = await ReadTag<BoolArrayPlcMapper, bool[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readBitArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<bool> tagValueList = new List<bool>(readBitArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<bool>)value);
                            var writeArrayRange = await WriteTag<BoolArrayPlcMapper, bool[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsBitArray = await WriteTag<BoolArrayPlcMapper, bool[]>(tagName, (bool[])value, new int[] { arrayLength });

                    if (resultsBitArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsBitArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.Dint:
                    // read online array first
                    var readDintArray = await ReadTag<DintPlcMapper, int[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readDintArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<int> tagValueList = new List<int>(readDintArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<int>)value);
                            var writeArrayRange = await WriteTag<DintPlcMapper, int[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsDintArray = await WriteTag<DintPlcMapper, int[]>(tagName, (int[])value, new int[] { arrayLength });

                    if (resultsDintArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsDintArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.Int:
                    // read online array first
                    var readIntArray = await ReadTag<IntPlcMapper, short[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readIntArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<short> tagValueList = new List<short>(readIntArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<short>)value);
                            var writeArrayRange = await WriteTag<IntPlcMapper, short[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsIntArray = await WriteTag<IntPlcMapper, short[]>(tagName, (short[])value, new int[] { arrayLength });

                    if (resultsIntArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsIntArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.Sint:
                    // read online array first
                    var readSintArray = await ReadTag<SintPlcMapper, sbyte[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readSintArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<sbyte> tagValueList = new List<sbyte>(readSintArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<sbyte>)value);
                            var writeArrayRange = await WriteTag<SintPlcMapper, sbyte[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsSintArray = await WriteTag<SintPlcMapper, sbyte[]>(tagName, (sbyte[])value, new int[] { arrayLength });

                    if (resultsSintArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsSintArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.Lint:
                    // read online array first
                    var readLintArray = await ReadTag<LintPlcMapper, long[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readLintArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<long> tagValueList = new List<long>(readLintArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<long>)value);
                            var writeArrayRange = await WriteTag<LintPlcMapper, long[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsLintArray = await WriteTag<LintPlcMapper, long[]>(tagName, (long[])value, new int[] { arrayLength });

                    if (resultsLintArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsLintArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.Real:
                    // read online array first
                    var readRealArray = await ReadTag<RealPlcMapper, float[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readRealArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<float> tagValueList = new List<float>(readRealArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<float>)value);
                            var writeArrayRange = await WriteTag<RealPlcMapper, float[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // Original code
                    var resultsRealArray = await WriteTag<RealPlcMapper, float[]>(tagName, (float[])value, new int[] { arrayLength });

                    if (resultsRealArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsRealArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.String:
                    // read online array first
                    var readStringArray = await ReadTag<StringPlcMapper, string[]>(tagName, new int[] { arrayLength });

                    // ensure read is successful
                    if (count > 0)
                    {
                        if (readStringArray.Status == "Success")
                        {
                            if (startIndex + count > arrayLength)
                            {
                                return new Response<string[]>(tagName, "Failure, Out of bounds");
                            }

                            List<string> tagValueList = new List<string>(readStringArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<string>)value);
                            var writeBoolArrayRange = await WriteTag<StringPlcMapper, string[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

                            if (writeBoolArrayRange.Status == "Success")
                            {
                                string[] arrString = Array.ConvertAll(writeBoolArrayRange.Value, Convert.ToString);
                                return new Response<string[]>(tagName, arrString, "Success");
                            }
                            else
                            {
                                return new Response<string[]>(tagName, "Failure");
                            }

                        }
                    }

                    // original code
                    var resultsStringArray = await WriteTag<StringPlcMapper, string[]>(tagName, value as string[], new int[] { arrayLength });

                    if (resultsStringArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsStringArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                default:
                    string[] emptyArrDefault = { };
                    return new Response<string[]>(tagName, emptyArrDefault, "Wrong Type");
            }
        }

        // private async Task<Response<string[]>> _WriteArrayRange<M, T>(string tagName, object value, int arrayLength, int startIndex, int count = 0) where M : IPlcMapper<T>, new()
        // {
        //     var readStringArray = await ReadTag<M, T>(tagName, new int[] { arrayLength });

        //     // ensure read is successful
        //     if (count > 0)
        //     {
        //         if (readStringArray.Status == "Success")
        //         {
        //             if (startIndex + count > arrayLength)
        //             {
        //                 return new Response<string[]>(tagName, "Failure, Out of bounds");
        //             }

        //             List<T> tagValueList = new List<T>(readStringArray.Value); // Still unsure how to properly cast this
        //             tagValueList.RemoveRange(startIndex, count);
        //             tagValueList.InsertRange(startIndex, (IEnumerable<T>)value);
        //             var writeBoolArrayRange = await WriteTag<StringPlcMapper, string[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

        //             if (writeBoolArrayRange.Status == "Success")
        //             {
        //                 string[] arrString = Array.ConvertAll(writeBoolArrayRange.Value, Convert.ToString);
        //                 return new Response<string[]>(tagName, arrString, "Success");
        //             }
        //             else
        //             {
        //                 return new Response<string[]>(tagName, "Failure");
        //             }

        //         }
        //     }
        //     return new Response<string[]>(tagName, "Failure");
        // }

        private async Task<Response<string>> _WriteTag<M, T>(string tagName, T value) where M : IPlcMapper<T>, new()
        {
            var results = await WriteTag<M, T>(tagName, value);

            if (results.Status == "Success")
            {
                return new Response<string>(tagName, results.Value.ToString(), "Success");
            }
            else
            {
                return new Response<string>(tagName, "Failure");
            }
        }

        public async Task<Response<T>> ReadTag<M, T>(string tagName) where M : IPlcMapper<T>, new()
        {

            var tag = new Tag<M, T>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout)
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();

                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<T>(tagName, "Failure");
            }
        }

        public async Task<Response<T>> ReadTag<M, T>(string tagName, int[] arrayDim = null) where M : IPlcMapper<T>, new()
        {

            var tag = new Tag<M, T>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout)
            };

            // Sanity Check, only support 3 dims in arrays for now
            if (arrayDim.Length > 3)
            {
                return new Response<T>(tagName, "Failure, Out of bounds");
            }

            if (arrayDim.Length > 0 && arrayDim[0] > 0)
            {
                tag.ArrayDimensions = new int[] { arrayDim[0] };
                if (arrayDim.Length > 1 && arrayDim[1] > 0)
                {
                    tag.ArrayDimensions = new int[] { arrayDim[0], arrayDim[1] };

                    if (arrayDim.Length > 2 && arrayDim[2] > 0)
                    {
                        tag.ArrayDimensions = new int[] { arrayDim[0], arrayDim[1], arrayDim[2] };
                    }
                }
            }

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();

                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<T>(tagName, "Failure");
            }
        }

        public async Task<Response<T>> WriteTag<M, T>(string tagName, T value) where M : IPlcMapper<T>, new()
        {

            var tag = new Tag<M, T>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout)
            };

            try
            {
                await tag.InitializeAsync();
                tag.Value = value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<T>(tagName, "Write Failure");
            }
        }

        public async Task<Response<T>> WriteTag<M, T>(string tagName, T value, int[] arrayDim = null) where M : IPlcMapper<T>, new()
        {

            var tag = new Tag<M, T>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout)
            };

            // Sanity Check, only support 3 dims in arrays for now
            if (arrayDim.Length > 3)
            {
                return new Response<T>(tagName, "Failure, Out of bounds");
            }

            if (arrayDim.Length > 0 && arrayDim[0] > 0)
            {
                tag.ArrayDimensions = new int[] { arrayDim[0] };
                if (arrayDim.Length > 1 && arrayDim[1] > 0)
                {
                    tag.ArrayDimensions = new int[] { arrayDim[0], arrayDim[1] };

                    if (arrayDim.Length > 2 && arrayDim[2] > 0)
                    {
                        tag.ArrayDimensions = new int[] { arrayDim[0], arrayDim[1], arrayDim[2] };
                    }
                }
            }

            try
            {
                await tag.InitializeAsync();
                tag.Value = value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<T>(tagName, "Write Failure");
            }
        }

    }

    public enum TagType
    {
        Bool,
        Bit,
        Dint,
        Int,
        Sint,
        Lint,
        Real,
        String
    }
}
