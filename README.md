# BlockingQueue
Q: Why yet another .Net 2.0 Blocking Queue implementation?  
A: I was looking, back in December 2013, for a Blocking Queue implementation for .Net 2.0 but none that I found were simple or reused existing .Net functionality.

Q: What??  
A: I wanted an implementation to (1) encapsulate all the syncronization machinary, (2) extend Queue and (3) reuse Queue.Synchronized.

Q: How is it simple to use?  
A: Use it like so:
```c#
  using System.Collections;
  using Gh.Os.Collections;
  ...
    Queue blockingQueue1 = BlockingQueue.create();
  ...
```
now use `blockingQueue1` with all standard `Queue` methods and properties.
