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
                    var resultsBool = await ReadTag<BoolPlcMapper, bool>(tagName);
                    if (resultsBool.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsBool.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Bit:
                    var resultsBit = await ReadTag<BoolPlcMapper, bool>(tagName);
                    if (resultsBit.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsBit.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Dint:
                    var resultsDint = await ReadTag<DintPlcMapper, int>(tagName);
                    if (resultsDint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsDint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Int:
                    var resultsInt = await ReadTag<IntPlcMapper, short>(tagName);
                    if (resultsInt.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsInt.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Sint:
                    var resultsSint = await ReadTag<SintPlcMapper, sbyte>(tagName);
                    if (resultsSint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsSint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Lint:
                    var resultsLint = await ReadTag<LintPlcMapper, long>(tagName);
                    if (resultsLint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsLint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Real:
                    var resultsReal = await ReadTag<RealPlcMapper, float>(tagName);
                    if (resultsReal.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsReal.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.String:
                    var resultsString = await ReadTag<StringPlcMapper, string>(tagName);
                    if (resultsString.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsString.Value, "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                default:
                    return new Response<string>(tagName, "None", "Wrong Type");
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

        public async Task<Response<string>> Write(string tagName, TagType tagType, object value)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    var resultsBool = await WriteTag<BoolPlcMapper, bool>(tagName, (bool)value);

                    if (resultsBool.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsBool.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "Failure");
                    }

                // case TagType.Bit:
                //     var resultsBit = await WriteBoolTag(tagName, value as bool?);

                //     if (resultsBit.Status == "Success")
                //     {
                //         return new Response<string>(tagName, resultsBit.Value.ToString(), "Success");
                //     }
                //     else
                //     {
                //         return new Response<string>(tagName, "None", "Failure");
                //     }

                // case TagType.Dint:
                //     var resultsDint = await WriteDintTag(tagName, value as int?);
                //     if (resultsDint.Status == "Success")
                //     {
                //         return new Response<string>(tagName, resultsDint.Value.ToString(), "Success");
                //     }
                //     else
                //     {
                //         return new Response<string>(tagName, "None", "Failure");
                //     }

                // case TagType.Int:
                //     var resultsInt = await WriteIntTag(tagName, value as short?);
                //     if (resultsInt.Status == "Success")
                //     {
                //         return new Response<string>(tagName, resultsInt.Value.ToString(), "Success");
                //     }
                //     else
                //     {
                //         return new Response<string>(tagName, "None", "Failure");
                //     }

                // case TagType.Sint:
                //     var resultsSint = await WriteSintTag(tagName, value as sbyte?);
                //     if (resultsSint.Status == "Success")
                //     {
                //         return new Response<string>(tagName, resultsSint.Value.ToString(), "Success");
                //     }
                //     else
                //     {
                //         return new Response<string>(tagName, "None", "Failure");
                //     }

                // case TagType.Lint:
                //     var resultsLint = await WriteLintTag(tagName, value as long?);
                //     if (resultsLint.Status == "Success")
                //     {
                //         return new Response<string>(tagName, resultsLint.Value.ToString(), "Success");
                //     }
                //     else
                //     {
                //         return new Response<string>(tagName, "None", "Failure");
                //     }

                // case TagType.Real:
                //     var resultsReal = await WriteRealTag(tagName, value as float?);
                //     if (resultsReal.Status == "Success")
                //     {
                //         return new Response<string>(tagName, resultsReal.Value.ToString(), "Success");
                //     }
                //     else
                //     {
                //         return new Response<string>(tagName, "None", "Failure");
                //     }

                case TagType.String:
                    var resultsString = await WriteTag<StringPlcMapper, string>(tagName, (string)value);

                    if (resultsString.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsString.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "Failure");
                    }

                //return await WriteStringTag(tagName, value as string);
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

                            //string[] arrBool = Array.ConvertAll(readBoolArray.Value, Convert.ToBoolean);
                            List<bool> tagValueList = new List<bool>(readBoolArray.Value);
                            tagValueList.RemoveRange(startIndex, count);
                            tagValueList.InsertRange(startIndex, (IEnumerable<bool>)value);
                            var writeBoolArrayRange = await WriteTag<BoolArrayPlcMapper, bool[]>(tagName, tagValueList.ToArray(), new int[] { arrayLength });

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

                // case TagType.Bit:
                //     var resultsBitArray = await WriteBoolArray(tagName, value as bool[], arrayLength, startIndex, count);

                //     if (resultsBitArray.Status == "Success")
                //     {
                //         string[] arrString = Array.ConvertAll(resultsBitArray.Value, Convert.ToString);
                //         return new Response<string[]>(tagName, arrString, "Success");
                //     }
                //     else
                //     {
                //         string[] emptyArray = { };
                //         return new Response<string[]>(tagName, emptyArray, "Failure");
                //     }

                // case TagType.Dint:
                //     var resultsDintArray = await WriteDintArray(tagName, value as int[], arrayLength, startIndex, count);

                //     if (resultsDintArray.Status == "Success")
                //     {
                //         string[] arrString = Array.ConvertAll(resultsDintArray.Value, Convert.ToString);
                //         return new Response<string[]>(tagName, arrString, "Success");
                //     }
                //     else
                //     {
                //         string[] emptyArray = { };
                //         return new Response<string[]>(tagName, emptyArray, "Failure");
                //     }

                // case TagType.Int:
                //     var resultsIntArray = await WriteIntArray(tagName, value as short[], arrayLength, startIndex, count);

                //     if (resultsIntArray.Status == "Success")
                //     {
                //         string[] arrString = Array.ConvertAll(resultsIntArray.Value, Convert.ToString);
                //         return new Response<string[]>(tagName, arrString, "Success");
                //     }
                //     else
                //     {
                //         string[] emptyArray = { };
                //         return new Response<string[]>(tagName, emptyArray, "Failure");
                //     }

                // case TagType.Sint:
                //     var resultsSintArray = await WriteSintArray(tagName, value as sbyte[], arrayLength, startIndex, count);

                //     if (resultsSintArray.Status == "Success")
                //     {
                //         string[] arrString = Array.ConvertAll(resultsSintArray.Value, Convert.ToString);
                //         return new Response<string[]>(tagName, arrString, "Success");
                //     }
                //     else
                //     {
                //         string[] emptyArray = { };
                //         return new Response<string[]>(tagName, emptyArray, "Failure");
                //     }

                // case TagType.Lint:
                //     var resultsLintArray = await WriteLintArray(tagName, value as long[], arrayLength, startIndex, count);

                //     if (resultsLintArray.Status == "Success")
                //     {
                //         string[] arrString = Array.ConvertAll(resultsLintArray.Value, Convert.ToString);
                //         return new Response<string[]>(tagName, arrString, "Success");
                //     }
                //     else
                //     {
                //         string[] emptyArray = { };
                //         return new Response<string[]>(tagName, emptyArray, "Failure");
                //     }

                // case TagType.Real:
                //     var resultsRealArray = await WriteRealArray(tagName, value as float[], arrayLength, startIndex, count);

                //     if (resultsRealArray.Status == "Success")
                //     {
                //         string[] arrString = Array.ConvertAll(resultsRealArray.Value, Convert.ToString);
                //         return new Response<string[]>(tagName, arrString, "Success");
                //     }
                //     else
                //     {
                //         string[] emptyArray = { };
                //         return new Response<string[]>(tagName, emptyArray, "Failure");
                //     }

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

                            //string[] arrBool = Array.ConvertAll(readBoolArray.Value, Convert.ToBoolean);
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
