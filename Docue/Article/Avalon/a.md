# Avalon

Avalon is Class Library list for C#.
Avalon has infra classes and effect element classes for C#.

Avalon uses C# signed Int 64 bits as general Int class. Int unsigned values use only lower 60 bits. 
Int signed values use lower 60 bits with higher 4 bits sign extend. Int null value is represented with -1 in 64 bits.

Avalon classes member variables are not in abstract.

Avalon Infra module String class Value and Count fields are not in abstract.

Avalon String class is not to be derived.

Avalon has Thread module. It has enough threading elements for C#.
All threads including main thread, has 1 event loop, that can be start and exit.
One event loop can be start once and exit once.
Event loop is start and exit in the thread the event loop belong to.

Avalon has text with each char unit in 32 bits Int. Avalon has String with char in 32 bits Int.