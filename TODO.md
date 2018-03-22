# TODO
Ideas and things to add to the project.

- [ ] Optional + Async
  - [ ] `Filter`
  - [ ] `ToLeftEither`, `ToRightEither`
  - [ ] `Contains`, `Exists`
  - [ ] `SomeWhen`, `NoneWhen`
  - [ ] `NotNull` - Return None if Option value is null.
  - [ ] `ValueOrDefault`, `ValueOrDefaultAsync`
  - [ ] `ValueOrAsync`
- [ ] Either + Async
  - [ ] `ValueLeftOrDefault`, `ValueRightOrDefault`
- [ ] Result + Async
  - [ ] `ValueFailureOrDefault`
- [ ] Enumerable extensions for working with Optional, Either, and Result
- [ ] TryParse as Optional utility methods.
- [ ] Add `ConfigureAwait`
- [ ] Extension methods to make operations more compatible with LINQ (e.g. SelectMany)
- [ ] Some async functions exist purely to create cleaner looking calls but serve no real purpose currently. Must decide if these should stay or go. 
- [ ] Remove `Async` from functions that are only operating on async functions but not creating new async tasks.
- [ ] Function Composition
- [ ] Matching
    - [ ] Predicate Based
    - [ ] Type Based