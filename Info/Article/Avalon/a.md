# Avalon

Avalon is Class Library list for C#.
Avalon has infra classes and effect element classes for C#.

Avalon uses C# signed Int 64 bits as general Int class. Int unsigned values use only lower 60 bits. 
Int signed values use lower 60 bits with higher 4 bits sign extend. Int null value is represented with -1 in 64 bits.

Avalon classes member variables are not in abstract.

Avalon Infra module String class Value and Count fields are not in abstract. Data class Value field is not in abstract.

Avalon String class is not to be derived.

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

Avalon has text with each char unit in 32 bits Int. Avalon has String with char in 32 bits Int.