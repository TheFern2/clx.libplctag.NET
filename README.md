# clx.libplctag.NET

> Work in progress

This is an async high level API for libplctag.NET wrapper, it supports CLX only (Controllogix, Compactlogix). As a long time pylogix user, I wanted an easier API, and hence why I am writing this library.

## Install

Install latest from cli:
```
dotnet add package clxx.libplctag.NET
```

Install specific version:
```
dotnet add package clxx.libplctag.NET --version 2.0.0
```

> You can also use nuget package manager

## API

There are two main ways to read/write a tags or arrays, both of these methods return a Response object similar to [pylogix](https://github.com/dmroeder/pylogix).

Response class:

```csharp
public class Response<T>
{
    public string TagName { get; }
    public T Value { get; }
    public string Status { get; }

Response: SomeTag SomeValue Success
```

## PLC instance

There are three ways to create a PLC instance:

```csharp
// PLC is on default slot 0
var myPLC = new PLC("192.168.1.196");
// PLC is on a slot other than 0
var myPLC = new PLC("192.168.1.196", 2);
// PLC is an a custom path
var myPLC = new PLC("192.168.1.196", "1,0");
```

You can also adjust the timeout property in seconds:
```csharp
myPLC.Timeout = 5;
```

## Individual tags

> The examples show boolean, but it is the same workflow for all plc types. (bool, dint, int, sint, lint, real, string)

Read:

```csharp
var result = await myPLC.Read("BaseBOOL", TagType.Bool);
Console.WriteLine(result);

Response: BaseBOOL True Success
```

> In the previous response, Response.Value = True. True is a string.

Write:

```csharp
var result = await myPLC.Write("BaseBOOL", TagType.Bool, false);
Console.WriteLine(result);

Response: BaseBOOL False Success
```

There are also methods which return correct types, but you'll have to provide a proper plc mapper.
In this case, you don't have to provide the TagType.

Read:

```csharp
var result = await myPLC.ReadTag<BoolPlcMapper, bool>("BaseBOOL");
Console.WriteLine(result);

Response: BaseBOOL True Success
```

> In the previous response, Response.Value = True. True is a boolean.

Write:

```csharp
var result = await myPLC.WriteTag<BoolPlcMapper, bool>("BaseBOOL", false);
Console.WriteLine(result);

Response: BaseBOOL False Success
```

## Read Write Entire Arrays

The library also supports reading/writing arrays, and array ranges.

Read:

```csharp
var result = await myPLC.Read("BaseBOOLArray", TagType.Bool, 128);
Console.WriteLine(result);

Response: BaseBOOLArray System.String[] Success
```

Write:

```csharp
bool[] boolArr = new bool[128];
var result = await myPLC.Write("BaseBOOLArray", TagType.Bool, boolArr, 128);
Console.WriteLine(result);

Response: BaseBOOLArray  Success

```

Using mappers:

Read:

```csharp
var result = await myPLC.ReadTag<BoolPlcMapper, bool[]>("BaseBOOLArray", new int[] { 128 });
Console.WriteLine(result);

Response: BaseBOOLArray System.Boolean[] Success

```

Write:

```csharp
bool[] boolArr = new bool[128];
var result = await myPLC.WriteTag<BoolPlcMapper, bool[]>("BaseBOOLArray", alist.ToArray(),new int[] { 128 });
Console.WriteLine(result);

Response: BaseBOOLArray  Success

```

## Read Write Array ranges

As of now the Read ranges is nothing but a syntactic sugar function. A full array read happens, then I extract whatever range was requested. The Response.Value is a string array.

Read range, start index [0], getting 10 items:

```csharp
var result = await myPLC.Read("BaseBOOLArray[0]", TagType.Bool, 128, 10);
Console.WriteLine(result);

Response: BaseBOOLArray[0] System.String[] Success

Console.WriteLine(result.Value.Length);

10
```

Writing ranges to arrays is using an optimized function internally by only writing the bytes necessary for the range needed.

Write range, start index [0], writing 10 items:

```csharp
bool[] boolArr = new bool[10];
var result = await myPLC.Write("BaseBOOLArray[0]", TagType.Bool, boolArr, 128);
Console.WriteLine(result);

Response: BaseBOOLArray  Success
```