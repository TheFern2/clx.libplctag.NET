using libplctag;
using libplctag.DataTypes;
using libplctag.NativeImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace clx.libplctag.NET
{
    public class PLC
    {
        private readonly string _ipAddress = "192.168.1.196";
        private readonly string _path = "1,0";

        public int Timeout { get; set; } = 5;
        // public Response<string> _response { get; set; }
        // public Response<string> _failure { get; set; }

        public PLC(string ipAddress, int slot)
        {
            _ipAddress = ipAddress;
            _path = "1," + slot.ToString();
            // _response = new Response<string>();
            // _failure = new Response<string>();
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
        public async Task<Response<string[]>> Read(string tagName, TagType tagType, int arrayLength, int startIndex = 0,
            int count = 0)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    var resultsBoolArray = await ReadTag<BoolPlcMapper, bool[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Bit:
                    var resultsBitArray = await ReadTag<BoolPlcMapper, bool[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Dint:
                    var resultsDintArray = await ReadTag<DintPlcMapper, int[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Int:
                    var resultsIntArray = await ReadTag<IntPlcMapper, short[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Sint:
                    var resultsSintArray = await ReadTag<SintPlcMapper, sbyte[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Lint:
                    var resultsLintArray = await ReadTag<LintPlcMapper, long[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.Real:
                    var resultsRealArray = await ReadTag<RealPlcMapper, float[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
                        }

                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        return new Response<string[]>(tagName, "Failure");
                    }

                case TagType.String:
                    var resultsStringArray = await ReadTag<StringPlcMapper, string[]>(tagName, new int[] {arrayLength})
                        .ConfigureAwait(false);
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
                            return new Response<string[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(),
                                "Success");
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
            var results = await ReadTag<M, T>(tagName).ConfigureAwait(false);
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
                responseList.Add(await Read(tagName, taglist[tagName]).ConfigureAwait(false));
            }

            return responseList;
        }

        public async Task<Response<string>> Write(string tagName, TagType tagType, object value)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    return await _WriteTag<BoolPlcMapper, bool>(tagName, (bool) value).ConfigureAwait(false);
                case TagType.Bit:
                    return await _WriteTag<BoolPlcMapper, bool>(tagName, (bool) value).ConfigureAwait(false);
                case TagType.Dint:
                    return await _WriteTag<DintPlcMapper, int>(tagName, (int) value).ConfigureAwait(false);
                case TagType.Int:
                    return await _WriteTag<IntPlcMapper, short>(tagName, (short) value).ConfigureAwait(false);
                case TagType.Sint:
                    return await _WriteTag<SintPlcMapper, sbyte>(tagName, (sbyte) value).ConfigureAwait(false);
                case TagType.Lint:
                    return await _WriteTag<LintPlcMapper, long>(tagName, (long) value).ConfigureAwait(false);
                case TagType.Real:
                    return await _WriteTag<RealPlcMapper, float>(tagName, (float) value).ConfigureAwait(false);
                case TagType.String:
                    return await _WriteTag<StringPlcMapper, string>(tagName, (string) value).ConfigureAwait(false);
                default:
                    return new Response<string>(tagName, "None", "Wrong Type");
            }
        }

        public async Task<Response<string>> Write(string tagName, TagType tagType, object value, int arrayLength)
        {
            var startIndexMatch = Regex.Match(tagName, @"(?<=\[).+?(?=\])");

            switch (tagType)
            {
                case TagType.Bool:
                    
                    if (startIndexMatch.Success)
                    {
                        var startIndex = Int32.Parse(startIndexMatch.Value);
                        return await WriteBoolArrayRange(tagName.Split("[")[0], (bool[]) value, arrayLength, startIndex);
                    }

                    return await WriteTag<BoolPlcMapper, bool[]>(tagName, (bool[]) value, new int[] {arrayLength})
                        .ConfigureAwait(false);

                case TagType.Bit:
                    
                    if (startIndexMatch.Success)
                    {
                        var startIndex = Int32.Parse(startIndexMatch.Value);
                        return await WriteBoolArrayRange(tagName.Split("[")[0], (bool[]) value, arrayLength, startIndex);
                    }

                    return await WriteTag<BoolPlcMapper, bool[]>(tagName, (bool[]) value, new int[] {arrayLength})
                        .ConfigureAwait(false);

                case TagType.Dint:

                    if (startIndexMatch.Success)
                    {
                        var startIndex = Int32.Parse(startIndexMatch.Value);
                        return await WriteDintArrayRange(tagName.Split("[")[0], (int[]) value, arrayLength, startIndex);
                    }

                    return await WriteTag<DintPlcMapper, int[]>(tagName, (int[]) value, new int[] {arrayLength})
                            .ConfigureAwait(false);

                case TagType.Int:
                    
                    if (startIndexMatch.Success)
                    {
                        var startIndex = Int32.Parse(startIndexMatch.Value);
                        return await WriteIntArrayRange(tagName.Split("[")[0], (short[]) value, arrayLength, startIndex);
                    }
                    
                    return await WriteTag<IntPlcMapper, short[]>(tagName, (short[]) value, new int[] {arrayLength})
                            .ConfigureAwait(false);
                
                case TagType.Sint:

                    // ensure read is successful
                    if (startIndexMatch.Success)
                    {
                        
                    }
                    
                    return await WriteTag<SintPlcMapper, sbyte[]>(tagName, (sbyte[]) value, new int[] {arrayLength})
                            .ConfigureAwait(false);

                case TagType.Lint:
                    
                    if (startIndexMatch.Success)
                    {
                        
                    }
                    
                    return await WriteTag<LintPlcMapper, long[]>(tagName, (long[]) value, new int[] {arrayLength})
                            .ConfigureAwait(false);

                case TagType.Real:
                    
                    if (startIndexMatch.Success)
                    {
                        
                    }

                   return await WriteTag<RealPlcMapper, float[]>(tagName, (float[]) value, new int[] {arrayLength})
                            .ConfigureAwait(false);

                case TagType.String:

                    if (startIndexMatch.Success)
                    {
                        
                    }
                    
                    return await WriteTag<StringPlcMapper, string[]>(tagName, value as string[], new int[] {arrayLength})
                            .ConfigureAwait(false);

                default:
                    return new Response<string>(tagName, "Wrong Type");
            }
        }

        private async Task<Response<string>> _WriteTag<M, T>(string tagName, T value) where M : IPlcMapper<T>, new()
        {
            var results = await WriteTag<M, T>(tagName, value).ConfigureAwait(false);

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
                await tag.InitializeAsync().ConfigureAwait(false);
                await tag.ReadAsync().ConfigureAwait(false);
                var tagValue = tag.Value;
                tag.Dispose();

                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<T>(tagName, "Failure");
            }
        }

        public async Task<Response<T>> ReadTag<M, T>(string tagName, int[] arrayDim = null)
            where M : IPlcMapper<T>, new()
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
                tag.ArrayDimensions = new int[] {arrayDim[0]};
                if (arrayDim.Length > 1 && arrayDim[1] > 0)
                {
                    tag.ArrayDimensions = new int[] {arrayDim[0], arrayDim[1]};

                    if (arrayDim.Length > 2 && arrayDim[2] > 0)
                    {
                        tag.ArrayDimensions = new int[] {arrayDim[0], arrayDim[1], arrayDim[2]};
                    }
                }
            }

            try
            {
                await tag.InitializeAsync().ConfigureAwait(false);
                await tag.ReadAsync().ConfigureAwait(false);
                var tagValue = tag.Value;
                tag.Dispose();

                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (Exception)
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
                await tag.InitializeAsync().ConfigureAwait(false);
                tag.Value = value;
                await tag.WriteAsync().ConfigureAwait(false);
                await tag.ReadAsync().ConfigureAwait(false);
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<T>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<T>(tagName, "Write Failure");
            }
        }

        public async Task<Response<string>> WriteTag<M, T>(string tagName, T value, int[] arrayDim = null)
            where M : IPlcMapper<T>, new()
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
                return new Response<string>(tagName, "InvalidArrayDim");
            }

            if (arrayDim.Length > 0 && arrayDim[0] > 0)
            {
                tag.ArrayDimensions = new int[] {arrayDim[0]};
                if (arrayDim.Length > 1 && arrayDim[1] > 0)
                {
                    tag.ArrayDimensions = new int[] {arrayDim[0], arrayDim[1]};

                    if (arrayDim.Length > 2 && arrayDim[2] > 0)
                    {
                        tag.ArrayDimensions = new int[] {arrayDim[0], arrayDim[1], arrayDim[2]};
                    }
                }
            }

            try
            {
                await tag.InitializeAsync().ConfigureAwait(false);
                tag.Value = value;
                await tag.WriteAsync().ConfigureAwait(false);
                /*await tag.ReadAsync().ConfigureAwait(false);
                var tagValue = tag.Value;*/
                tag.Dispose();
                return new Response<string>(tagName, "Success");
            }
            catch (Exception e)
            {
                return new Response<string>(tagName, e.Message);
            }
        }

        public async Task<Response<string>> WriteDintArrayRange(string tagName, int[] value, int arrayLength,
            int startIndex)
        {
            var tag = new Tag();
            tag.Name = tagName;
            tag.Gateway = _ipAddress;
            tag.Path = _path;
            tag.PlcType = PlcType.ControlLogix;
            tag.Protocol = Protocol.ab_eip;
            tag.Timeout = TimeSpan.FromSeconds(Timeout);
            tag.ElementCount = arrayLength;

            // sanity check
            if (startIndex + value.Length > arrayLength)
            {
                return new Response<string>(tagName, "MismatchLength");
            }

            try
            {
                await tag.InitializeAsync().ConfigureAwait(false);
                var offsetSize = tag.GetSize() / arrayLength;

                for (int i = 0; i < value.Length; i++)
                {
                    tag.SetInt32((startIndex + i) * offsetSize, value[i]);
                }

                await tag.WriteAsync().ConfigureAwait(false);

                return new Response<string>(tagName, "Success");
            }
            catch (Exception e)
            {
                return new Response<string>(tagName, e.Message);
            }
        }

        public async Task<Response<string>> WriteIntArrayRange(string tagName, short[] value, int arrayLength,
            int startIndex)
        {
            var tag = new Tag();
            tag.Name = tagName;
            tag.Gateway = _ipAddress;
            tag.Path = _path;
            tag.PlcType = PlcType.ControlLogix;
            tag.Protocol = Protocol.ab_eip;
            tag.Timeout = TimeSpan.FromSeconds(Timeout);
            tag.ElementCount = arrayLength;

            // sanity check
            if (startIndex + value.Length > arrayLength)
            {
                return new Response<string>(tagName, "MismatchLength");
            }

            try
            {
                await tag.InitializeAsync().ConfigureAwait(false);
                var offsetSize = tag.GetSize() / arrayLength;

                for (int i = 0; i < value.Length; i++)
                {
                    tag.SetInt16((startIndex + i) * offsetSize, value[i]);
                }

                await tag.WriteAsync().ConfigureAwait(false);

                return new Response<string>(tagName, "Success");
            }
            catch (Exception e)
            {
                return new Response<string>(tagName, e.Message);
            }
        }
        
        public async Task<Response<string>> WriteBoolArrayRange(string tagName, bool[] value, int arrayLength,
            int startIndex)
        {
            var tag = new Tag();
            tag.Name = tagName;
            tag.Gateway = _ipAddress;
            tag.Path = _path;
            tag.PlcType = PlcType.ControlLogix;
            tag.Protocol = Protocol.ab_eip;
            tag.Timeout = TimeSpan.FromSeconds(Timeout);
            tag.ElementCount = arrayLength / 32;

            // sanity check
            if (startIndex + value.Length > arrayLength)
            {
                return new Response<string>(tagName, "MismatchLength");
            }

            try
            {
                await tag.InitializeAsync().ConfigureAwait(false);
                //var offsetSize = tag.GetSize() / arrayLength;

                for (int i = 0; i < value.Length; i++)
                {
                    tag.SetBit(startIndex + i, value[i]);
                }

                await tag.WriteAsync().ConfigureAwait(false);

                return new Response<string>(tagName, "Success");
            }
            catch (Exception e)
            {
                return new Response<string>(tagName, e.Message);
            }
        }
    }
}