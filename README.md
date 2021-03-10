# thefern.libplctag.NET

> Work in progress

This is an async high level API for libplctag.NET wrapper, right now I am only going to focus on CLX as it is my main PLC model. It should work on CompactLogix as well. As a long time pylogix user, I wanted something simple to use, and hence why I am writing this library.

## API

There are two main ways to read/write a tag, both of these methods return a Response object similar to pylogix.

Response class:

```csharp
public class Response<T>
{
    public string TagName { get; }
    public T Value { get; }
    public string Status { get; }
```

The plain Read and Write return a string or string[] for the Value. Working with strings might be useful if you're working with a system that needs everything in strings, for example json files, or Redis DB, or something along those lines.

> NB: Response object sends a Value of None as a string if the Status is a failure.

The individual functions like ReadBoolTag only require the tag name, and it returns a Response object as well but this time the Value will be a boolean.

The individual write functions, take two params, tag name, and value to write. Both ways to read functions provide their own benefits.

> NB: If the status is failure, the Response object still send a Value. For arrays it will be an empty array, for everything else it will be -1. For booleans false. This is due to the Response object needing the T defined. There might be a better way to handle this in the future.

## Examples

Read:

```csharp
var myPLC = new PLC("192.168.1.196", 2);
var result = await myPLC.Read("BaseBOOL", TagType.Bool);
Console.WriteLine(result);

Response: BaseBOOL True Success
```

Write:

```csharp
await myPLC.Write("BaseBOOL", TagType.Bool, false);
```

You can also get the results:

```csharp
var result = await myPLC.Write("BaseBOOL", TagType.Bool, false);
Console.WriteLine(result);

Response: BaseBOOL True Success
```

There are also direct methods which return correct types:

```csharp
var myPLC = new PLC("192.168.1.196", 2);
var result = await myPLC.ReadBoolTag("BaseBOOL");
Console.WriteLine(result);

Response: BaseBOOL True Success
```

```csharp
var myPLC = new PLC("192.168.1.196", 2);
var result = await myPLC.WriteBoolTag("BaseBOOL", false);
Console.WriteLine(result);

Response: BaseBOOL False Success
```
