# Hydrax.Functional

![Travis Tests](https://travis-ci.org/chriskdon/Hydrax.Functional.svg?branch=master)

A utility library that helps to support a functional style programming pattern
while still remaining pragmatic and useful in C#.

## Warning

The libary is in it's very early stages of development so it is missing many
required functions. It is also very unstable and the API is likeyly to change
a lot.

## Optional

A container that either holds `Some(T)` value or `None`.

### Example Usage

Note that most functions have an async alternative for working with `async`
tasks.

#### Creating

```c#
var some = Optional.Some("value");
var some = "value".Some();

var someAsync = await SomeTask().SomeAsync();

var optionalNotNull = "value".SomeNotNull(); // -> Some("value")
var optionalNull = nullStr.SomeNotNull();    // -> None

var none = Optional.None<string>();
```

#### Properties

```c#
// If the optional has a value then HasValue will be true
if(optional.HasValue) {
  // Do something
}
```

#### Mapping

```c#
var mapSome = some.Map(v => v + 100); // -> Some(200);
var mapNone = none.Map(v => v + 100); // -> None;

var flatMap = optional.FlatMap(v => Optional.Some(v));
```

#### Filtering

```c#
optional.SomeWhen(i => i == 100); // Some(100) -> Some(100)
optional.NoneWhen(i => i == 100); // Some(100) -> None
```

#### Getting Values
```c#
// Return the value + 10 or default of 100 if None.
var value = optional.Match(some => some + 10, () => 100);

// Return the value or default if None.
var value = optional.ValueOr(100);

var valueLazy = optional.ValueOr(() => 100);
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
```

#### Converting

```c#
var success = some.ToResult(); // Some(T) -> Success
var failure = none.ToResult(); // None -> Failure 
```

#### Unsafe

These functions may throw an exception when used.

```c#
using Hydrax.Functional.Unsafe;

var value = optional.ValueOrThrow(); // Throws exception if optional is None;
var value = optional.ValueOrThrow(new Exception("Error"));
var value = optional.ValueOrTrhow(() => new Exception("Error"));
```

## Either

A container that either holds a `Left(T)` value or a `Right(T)` value.

### Example Usage

Note that most functions have an async alternative for working with `async`
tasks.

#### Creating

```c#
var left = Optional.Left<string, int>("value");
var right = Optional.Right<int, string>("value");

var left = "value".Left<string, int>();
var right = "value".Right<int, string>();
```

#### Properties

```c#
if(either.IsLeft) {
  // The either is Left.
}

if(either.IsRight) {
  // The either is Right.
}
```

#### Mapping

```c#
var mapLeft = either.MapLeft(left => left + 100);
var mapRight = either.MapRight(right => right + 100);

var flatMapLeft = either.FlatMapLeft(left => Optional.Some(left));
var flatMapRight = either.FlatMapRight(right => Optional.Some(right));
```

#### Getting Values

```c#
var value = optional.Match(left => some + 10, right => right + 100);

var valueLeft = optional.ValueLeftOr(100);
var valueRight = optional.ValueRightOr(100);

var valueLeftLazy = optional.ValueLeftOr(() => 100);
var valueRightLazy = optional.ValueRightOr(() => 100);

// If the Either has the same Left and Right types they can be unified to a value.
var value = Optional.Left<int, int>(100).UnifyToValue(); // Left -> 100
```

#### Performing Actions

```c#
either.Match(
  left => {
    Console.WriteLine($"Left({left})");
  },
  right => {
    Console.WriteLine($"Right({right})");
  });
```

#### Converting

```c#

// Convert to Optional
var optional = left.ToLeftOptional();   // Left(T) -> Optional(T)
var optional = right.ToLeftOptional();  // Right(T) -> None

var optional = right.ToRightOptional(); // Right(T) -> Optional(T)
var optional = left.ToRightOptional();  // Left(T) -> None

// Convert to Result
var result = left.ToLeftResult();   // Left(T) -> Success
var result = right.ToLeftResult();  // Right(T) -> Failure

var result = right.ToRightResult(); // Right(T) -> Success
var result = left.ToRightResult();  // Left(T) -> Failure
```

#### Unsafe

These functions may throw an exception when used.

```c#
using Hydrax.Functional.Unsafe;

var value = either.LeftValueOrThrow();
var value = either.RightValueOrThrow();
```

## Result

A container that represents success or failure, the failure state can contain
a value.

### Example Usage

Note that most functions have an async alternative for working with `async`
tasks.

#### Creating

```c#
var success = Optional.Success();
var failure = Optional.Failure(); 

var failureWithValue = Optional.Failure("value");
var failureWithValue = "value".Failure();
```

#### Properties

```c#
if(result.IsSuccess) {
  // The result is a Success.
}

if(either.IsFailure) {
  // The result is a Failure.
}
```

#### Mapping

```c#
var mapFailure = result.MapFailure(fail => $"Some Failure: {fail}");

var flatMapFailure = result.FlatMapFailure(fail => Result.Failure(fail));
```

#### Getting Values

```c#
var value = result.Match(() => "success", () => "failure");
var value = result.Match(() => "success", fail => $"Failure: {fail}");
```

#### Performing Actions

```c#
result.Match(
  () => {
    Console.WriteLine($"Success");
  },
  () => {
    Console.WriteLine($"Failure");
  });

result.Match(
  () => {
    Console.WriteLine($"Success");
  },
  failure => {
    Console.WriteLine($"Failure({failure})");
  });
```

#### Unsafe

These functions may throw an exception when used.

```c#
using Hydrax.Functional.Unsafe;

var failValue = either.FailureValueOrThrow();
```