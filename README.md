# thefern.libplctag.NET

> Work in progress

This is an async high level API for libplctag.NET wrapper, right now I am only going to focus on CLX as it is my main PLC model. It should work on CompactLogix as well. As a long time pylogix user, I wanted something simple to use, and hence why I am writing this library.

## API

There are two main ways to read/write a tag, both of these methods return a Response object similar to pylogix.

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
