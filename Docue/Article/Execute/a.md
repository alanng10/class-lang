# Execute

Class System has 4 tier of execute certainty when execute module.

The first tier is operate and execute lang elements except new, share, get, set and call.
This tier is the fastest. It is faster than function call and effect load.

The second tier is function call. This includes get, set, and call.
This tier is the second fastest. It is faster than memory allocation call and effect load.

The third tier is memory allocation call. This includes new and share, and time effect and console inn and out effect.
This tier is faster than effect load.

The fourth tier is effect load. This includes storage and network.

First tier and second tier have high execute certainty.

Third tier has low execute certainty.

Fourth tier has lowest execute certainty.

Module execute speeds is measured in count of function call base line maximum duration.

Class system programming module Infra memory allocation maide returns
memory address of memory block that can be read or write to without triggering function call.