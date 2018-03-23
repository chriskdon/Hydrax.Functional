# Hydrax.Functional

![Travis Tests](https://travis-ci.org/chriskdon/Hydrax.Functional.svg?branch=master)

A utility library that helps to support a functional style programming pattern
while still remaining pragmatic and useful in C#.

## Optional

A container that either holds `Some(T)` value or `None`.

### Examples

*TODO*

#### Creating

```c#
var some = Optional.Some("value");
var some = "value".Some();

var someAsync = await SomeTask().SomeAsync();

var optionalNotNull = "value".SomeNotNull(); // -> Some("value")
var optionalNull = nullStr.SomeNotNull();    // -> None

var none = Optional.None<string>();
```

#### Mapping

```c#
var mapSome = some.Map(p => p + 100); // -> Some(200);
var mapNone = none.Map(p => p + 100); // -> None;
```

#### Getting Values
```c#
// Return the value + 10 or default of 100 if None.
var value = optional.Match(some => some + 10, () => 100);

var value = await = optiona.MatchAsync(
  async some => GetFromDb(some), 
  async () => "default");

// Return the value or default if None.
var value = optional.ValueOr(100);
```

#### Performing Actions

```c#
// Run an action on the optional if it is Some or None.
optional.Match(
  value => {
    Console.WriteLine($"Some({value})");
  },
  () => {
    Console.WriteLine($"None");
  });

// Run async actions on the optional if it is Some or None.
optional.MatchAsync(
  async value => { /* Do something async for Some. */ },
  async () => { /* Do something async for None. */ });
```

## Either

A container that either holds a `Left(T)` value or a `Right(T)` value.

### Examples

*TODO*

## Result

A container that represents success or failure, the failure state can contain
a value.

### Examples

*TODO*