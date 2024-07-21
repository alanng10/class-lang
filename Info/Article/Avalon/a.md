# Avalon

Avalon is Class Library list for C#.
Avalon has infra classes and effect element classes for C#.
Avalon is used as System modules for Class. Class modules use interfaces declared in Avalon modules refer binaries to use Avalon classes.

Avalon classes member variables are not in abstract.

Avalon has Thread module. It has enough threading elements for C#.
All threads including main thread, has 1 event loop, that can be start and exit.
One event loop can be start once and exit once.
Event loop is start and exit in the thread the event loop belong to.

Thread module Interval class Any is Init in a thread, and that thread is the thread that execute elapse event of the Interval Any.
The thread execute the event in the thread event loop.
The Interval Any execute Elapse Event Any by trigger the Event Any.
Interval Any can be start and stop in the thread it is Init.

Thread module Post class Any can be execute to queue event to event loop of the Thread, 
the Thread is the thread that Post class Any is Init.
Post class Any Execute method is call to queue event. When the event loop execute the event, it will execute a State Any in Post class Any.
The Execute method can be call from any Thread.

Avalon.Storage module Storage class has field AnyNode that is type "bool" to set the Storage Any to accept any storage nodes.