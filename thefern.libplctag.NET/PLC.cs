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
                    var resultsBool = await ReadBoolTag(tagName);
                    if(resultsBool.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsBool.Value.ToString(), "Success");
                    } else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }                    

                case TagType.Bit:
                    var resultsBit = await ReadBoolTag(tagName);
                    if (resultsBit.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsBit.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Dint:
                    var resultsDint = await ReadDintTag(tagName);
                    if (resultsDint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsDint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Int:
                    var resultsInt = await ReadIntTag(tagName);
                    if (resultsInt.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsInt.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Sint:
                    var resultsSint = await ReadSintTag(tagName);
                    if (resultsSint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsSint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }
                    
                case TagType.Lint:
                    var resultsLint = await ReadLintTag(tagName);
                    if (resultsLint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsLint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Real:
                    var resultsReal = await ReadRealTag(tagName);
                    if (resultsReal.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsReal.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.String:
                    var resultsString = await ReadStringTag(tagName);
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
        public async Task<Response<string[]>> Read(string tagName, TagType tagType, int arrayLength)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    var resultsBoolArray = await ReadBoolArray(tagName, arrayLength);
                    if(resultsBoolArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsBoolArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    } else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }
                    
                case TagType.Bit:
                    var resultsBitArray = await ReadBoolArray(tagName, arrayLength);
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
                    var resultsDintArray = await ReadDintArray(tagName, arrayLength);
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
                    var resultsIntArray = await ReadIntArray(tagName, arrayLength);
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
                    var resultsSintArray = await ReadSintArray(tagName, arrayLength);
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
                    var resultsLintArray = await ReadLintArray(tagName, arrayLength);
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
                    var resultsRealArray = await ReadRealArray(tagName, arrayLength);
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
                    return await ReadStringArray(tagName, arrayLength); ;
                default:
                    string[] emptyArrDefault = { };
                    return new Response<string[]>(tagName, emptyArrDefault, "Failure");
            }
        }

        public async Task<Response<string>> Write(string tagName, TagType tagType, object value)
        {
            switch (tagType)
            {
                case TagType.Bool:
                    var resultsBool = await WriteBoolTag(tagName, value as bool?);

                    if (resultsBool.Status == "Success")
                    {             
                        return new Response<string>(tagName, resultsBool.Value.ToString(), "Success");
                    }
                    else
                    {                        
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Bit:
                    var resultsBit = await WriteBoolTag(tagName, value as bool?);

                    if (resultsBit.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsBit.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }
                 
                case TagType.Dint:
                     var resultsDint = await WriteDintTag(tagName, value as int?);
                    if (resultsDint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsDint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Int:
                     var resultsInt = await WriteIntTag(tagName, value as short?);
                    if (resultsInt.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsInt.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Sint:                   
                     var resultsSint = await WriteSintTag(tagName, value as sbyte?);
                    if (resultsSint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsSint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Lint:
                     var resultsLint = await WriteLintTag(tagName, value as long?);
                    if (resultsLint.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsLint.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.Real:
                     var resultsReal = await WriteRealTag(tagName, value as float?);
                    if (resultsReal.Status == "Success")
                    {
                        return new Response<string>(tagName, resultsReal.Value.ToString(), "Success");
                    }
                    else
                    {
                        return new Response<string>(tagName, "None", "Failure");
                    }

                case TagType.String:
                     return await WriteStringTag(tagName, value as string);
                default:
                    return new Response<string>(tagName, "None", "Wrong Type");
            }
        }

        public async Task<Response<string[]>> Write(string tagName, TagType tagType, object value, int arrayLength, int startIndex = 0, int count = 0)
        {
            switch (tagType)
            {
                case TagType.Bool:                 

                    var resultsBoolArray = await WriteBoolArray(tagName, value as bool[], arrayLength, startIndex, count);

                    if (resultsBoolArray.Status == "Success")
                    {
                        string[] arrString = Array.ConvertAll(resultsBoolArray.Value, Convert.ToString);
                        return new Response<string[]>(tagName, arrString, "Success");
                    }
                    else
                    {
                        string[] emptyArray = { };
                        return new Response<string[]>(tagName, emptyArray, "Failure");
                    }

                case TagType.Bit:
                    var resultsBitArray = await WriteBoolArray(tagName, value as bool[], arrayLength, startIndex, count);

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
                    var resultsDintArray = await WriteDintArray(tagName, value as int[], arrayLength, startIndex, count);

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
                    
                /*case TagType.Int:
                    return await WriteIntTag(tagName, value as int?);
                case TagType.Sint:
                    if (arrayLength > 0) return await ReadSintArray(tagName, arrayLength);
                    return await ReadSintTag(tagName);
                case TagType.Lint:
                    if (arrayLength > 0) return await ReadLintArray(tagName, arrayLength);
                    return await ReadLintTag(tagName);
                case TagType.Real:
                    if (arrayLength > 0) return await ReadRealArray(tagName, arrayLength);
                    return await ReadRealTag(tagName);
                case TagType.String:
                    if (arrayLength > 0) return await ReadStringArray(tagName, arrayLength);
                    return await ReadStringTag(tagName);*/
                default:
                    string[] emptyArrDefault = { };
                    return new Response<string[]>(tagName, emptyArrDefault, "Wrong Type");
            }
        }


        public async Task<Response<int>> ReadDintTag(string tagName)
        {
            var tag = new Tag<DintPlcMapper, int>()
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
                return new Response<int>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<int>(tagName, -1, "Failure");
            }
        }

        public async Task<Response<int>> WriteDintTag(string tagName, int? value)
        {
            var tag = new Tag<DintPlcMapper, int>()
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
                tag.Value = (int)value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<int>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<int>(tagName, -1, "Write Failure");
            }
        }

        public async Task<Response<int[]>> ReadDintArray(string tagName, int arrayLength, int startIndex=0, int count=0)
        {
            var tag = new Tag<DintPlcMapper, int[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();

                // Sanity check to make sure we don't try to access items indices bigger than array
                if (startIndex + count > arrayLength)
                {
                    int[] emptyArr = { };
                    return new Response<int[]>(tagName, emptyArr, "Start index + count is greater than array length, out of bounds.");
                }

                if (count > 0)
                {
                    List<int> tagValueList = new List<int>(tagValue);
                    return new Response<int[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                }

                return new Response<int[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                int[] emptyArr = { };
                return new Response<int[]>(tagName, emptyArr, "Failure");
            }
        }

        public async Task<Response<int[]>> WriteDintArray(string tagName, int[] value, int arrayLength, int startIndex=0, int count=0)
        {
            var tag = new Tag<DintPlcMapper, int[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                int[] tagValue = { };

                // Sanity check to make sure we don't try to access items indices bigger than array
                if (startIndex + count > arrayLength)
                {
                    int[] emptyArr = { };
                    return new Response<int[]>(tagName, emptyArr, "Failure, Out of bounds");
                }

                if (count > 0)
                {
                    await tag.ReadAsync();
                    List<int> tagValueList = new List<int>(tag.Value); // plc online value
                    tagValueList.RemoveRange(startIndex, count);
                    tagValueList.InsertRange(startIndex, value);
                    tag.Value = tagValueList.ToArray();
                    await tag.WriteAsync(); // write new range to plc
                    await tag.ReadAsync();
                    tagValue = tag.Value;
                    tag.Dispose();
                    List<int> updatedValueList = new List<int>(tagValue);
                    var updatedValue = updatedValueList.GetRange(startIndex, count);
                    return new Response<int[]>(tagName, updatedValue.ToArray(), "Success");
                }
                else
                {               
                    tag.Value = value;
                    await tag.WriteAsync();
                    await tag.ReadAsync();
                    tagValue = tag.Value;
                    tag.Dispose();
                }

                return new Response<int[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                int[] emptyArr = { };
                return new Response<int[]>(tagName, emptyArr, "Write Failure");
            }
        }

        public async Task<Response<short>> ReadIntTag(string tagName)
        {
            var tag = new Tag<IntPlcMapper, short>()
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
                return new Response<short>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<short>(tagName, -1, "Failure");
            }
        }

        public async Task<Response<short>> WriteIntTag(string tagName, short? value)
        {
            var tag = new Tag<IntPlcMapper, short>()
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
                tag.Value = (short)value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<short>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<short>(tagName, -1, "Write Failure");
            }
        }

        public async Task<Response<short[]>> ReadIntArray(string tagName, int arrayLength)
        {
            var tag = new Tag<IntPlcMapper, short[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<short[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                short[] emptyArr = { };
                return new Response<short[]>(tagName, emptyArr, "Failure");
            }
        }

        public async Task<Response<sbyte>> ReadSintTag(string tagName)
        {
            var tag = new Tag<SintPlcMapper, sbyte>()
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
                return new Response<sbyte>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<sbyte>(tagName, -1, "Failure");
            }
        }

        public async Task<Response<sbyte>> WriteSintTag(string tagName, sbyte? value)
        {
            var tag = new Tag<SintPlcMapper, sbyte>()
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
                tag.Value = (sbyte)value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<sbyte>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<sbyte>(tagName, -1, "Write Failure");
            }
        }

        public async Task<Response<sbyte[]>> ReadSintArray(string tagName, int arrayLength)
        {
            var tag = new Tag<SintPlcMapper, sbyte[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<sbyte[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                sbyte[] emptyArr = { };
                return new Response<sbyte[]>(tagName, emptyArr, "Failure");
            }
        }

        public async Task<Response<long>> ReadLintTag(string tagName)
        {
            var tag = new Tag<LintPlcMapper, long>()
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
                return new Response<long>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<long>(tagName, -1, "Failure");
            }
        }

        public async Task<Response<long>> WriteLintTag(string tagName, long? value)
        {
            var tag = new Tag<LintPlcMapper, long>()
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
                tag.Value = (long)value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<long>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<long>(tagName, -1, "Write Failure");
            }
        }

        public async Task<Response<long[]>> ReadLintArray(string tagName, int arrayLength)
        {
            var tag = new Tag<LintPlcMapper, long[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<long[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                long[] emptyArr = { };
                return new Response<long[]>(tagName, emptyArr, "Failure");
            }
        }

        public async Task<Response<bool>> ReadBoolTag(string tagName)
        {
            var tag = new Tag<BoolPlcMapper, bool>()
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
                return new Response<bool>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<bool>(tagName, false, "Failure");
            }
        }

        public async Task<Response<bool>> ReadBoolTagFAB(string tagName)
        {
            var tag = new Tag<BoolPlcMapper, bool>()
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
                return new Response<bool>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<bool>(tagName, false, "Failure");
            }
        }

        public int WriteBoolTagLL(string tagName, byte writeValue)
        {
            var tagHandle = plctag.plc_tag_create($"protocol=ab_eip&gateway={_ipAddress}&path={_path}&plc=LGX&elem_size=1&elem_count=1&debug=1&name={tagName}" , 1000);
            plctag.plc_tag_read(tagHandle, 1000);
            
            //Console.WriteLine(value);            
            plctag.plc_tag_set_uint8(tagHandle, 0, writeValue);
            plctag.plc_tag_write(tagHandle, 1000);
            var value = plctag.plc_tag_get_uint8(tagHandle, 0);
            return value;
        }

        public async Task<Response<bool>> WriteBoolTag(string tagName, bool? value)
        {
            var tag = new Tag<BoolPlcMapper, bool>()
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
                tag.Value = (bool)value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<bool>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<bool>(tagName, false, "Write Failure");
            }
        }        

        public async Task<Response<bool[]>> ReadBoolArray(string tagName, int arrayLength, int startIndex = 0, int count = 0)
        {
            var tag = new Tag<BoolPlcMapper, bool[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();

                // Sanity check to make sure we don't try to access items indices bigger than array
                if(startIndex + count > arrayLength)
                {
                    bool[] emptyArr = { };
                    return new Response<bool[]>(tagName, emptyArr, "Start index + count is greater than array length, out of bounds.");
                }
                
                if(count > 0)
                {
                    List<bool> tagValueList = new List<bool>(tagValue);
                    return new Response<bool[]>(tagName, tagValueList.GetRange(startIndex, count).ToArray(), "Success");
                }

                return new Response<bool[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                bool[] emptyArr = { };
                return new Response<bool[]>(tagName, emptyArr, "Failure");
            }
        }

        public async Task<Response<bool[]>> WriteBoolArray(string tagName, bool[] value, int arrayLength, int startIndex = 0, int count = 0)
        {
            var tag = new Tag<BoolPlcMapper, bool[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                bool[] tagValue = { };

                // Sanity check to make sure we don't try to access items indices bigger than array
                if (startIndex + count > arrayLength)
                {
                    bool[] emptyArr = { };
                    return new Response<bool[]>(tagName, emptyArr, "Start index + count is greater than array length, out of bounds.");
                }

                if (count > 0)
                {
                    await tag.ReadAsync();
                    List<bool> tagValueList = new List<bool>(tag.Value); // plc online value
                    tagValueList.RemoveRange(startIndex, count);
                    tagValueList.InsertRange(startIndex, value);
                    tag.Value = tagValueList.ToArray();
                    await tag.WriteAsync(); // write new range to plc
                    await tag.ReadAsync();
                    tagValue = tag.Value;
                    tag.Dispose();
                    return new Response<bool[]>(tagName, tagValue, "Success");
                }
                else
                {
                    tag.Value = value;
                    await tag.WriteAsync();
                    await tag.ReadAsync();
                    tagValue = tag.Value;
                    tag.Dispose();
                }

                return new Response<bool[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                bool[] emptyArr = { };
                return new Response<bool[]>(tagName, emptyArr, "Write Failure");
            }
        }        

        public async Task<Response<float>> ReadRealTag(string tagName)
        {
            var tag = new Tag<RealPlcMapper, float>()
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
                return new Response<float>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<float>(tagName, -1, "Failure");
            }
        }

        public async Task<Response<float>> WriteRealTag(string tagName, float? value)
        {
            var tag = new Tag<RealPlcMapper, float>()
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
                tag.Value = (float)value;
                await tag.WriteAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<float>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<float>(tagName, -1, "Write Failure");
            }
        }

        public async Task<Response<float[]>> ReadRealArray(string tagName, int arrayLength)
        {
            var tag = new Tag<RealPlcMapper, float[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<float[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                float[] emptyArr = { };
                return new Response<float[]>(tagName, emptyArr, "Failure");
            }
        }

        public async Task<Response<string>> ReadStringTag(string tagName)
        {
            var tag = new Tag<StringPlcMapper, string>()
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
                return new Response<string>(tagName, tagValue.ToString(), "Success");
            }
            catch (System.Exception)
            {
                return new Response<string>(tagName, "None", "Failure");
            }
        }

        public async Task<Response<string>> WriteStringTag(string tagName, string value)
        {
            var tag = new Tag<StringPlcMapper, string>()
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
                return new Response<string>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                return new Response<string>(tagName, "None", "Write Failure");
            }
        }

        public async Task<Response<string[]>> ReadStringArray(string tagName, int arrayLength)
        {
            var tag = new Tag<StringPlcMapper, string[]>()
            {
                Name = tagName,
                Gateway = _ipAddress,
                Path = _path,
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                Timeout = TimeSpan.FromSeconds(Timeout),
                ArrayDimensions = new int[] { arrayLength }
            };

            try
            {
                await tag.InitializeAsync();
                await tag.ReadAsync();
                var tagValue = tag.Value;
                tag.Dispose();
                return new Response<string[]>(tagName, tagValue, "Success");
            }
            catch (System.Exception)
            {
                string[] emptyArr = { };
                return new Response<string[]>(tagName, emptyArr, "Failure");
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
