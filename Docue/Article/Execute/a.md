# Execute

Class System has 3 tier of execute certainty when execute module.

The first tier is operate and execute lang elements.
This tier is the fastest. It is faster than function call and effect load.

The second tier is function call.
This tier is the second fastest. It is faster than effect load.

The third tier is effect load.

Module execute speeds is measured in count of function call base line maximum duration.

Class system programming module Infra memory allocation maide returns
memory address of memory block that can be read or write to without triggering function call.