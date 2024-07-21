# System Memory

System has memory that is used to store any data.

Memory has ideally minimum capacity that is 
2 ^ 20 blocks.

Block is 64 kilo bytes of data.

Memory space can be mapped in and mapped out for each block.
Block table data is in 1 block.
Block table data is array of 4 kilo entries.

A entry has 2 Ints.
The first Int is a 64 bit Int that is block memory addresss.
The second Int is a 64 bit Int that is allocation bits of the block of the first Int.

Memory space mapping starts from the root entry.

Memory address that is mapped, has its first 4 12 bits indexed into 4 tiers of block tables.
The last 16 bits is byte index of a block.