# Compute
Compute has 16 vars.
Var is 64 bits int.

Memory index is 64 bits int.

Byte is 8 bits int.

Compute operate code is 4 bytes.
The first byte is operate kind index.
The next 3 bytes are argue and dest.
Argue and dest code data are in operate code in sequence of the operate syntax.
If argue and dest code data does not take up 3 bytes in operate code, 
bytes with value of zero are padded next in operate code to be 4 bytes in total.

Var that is set in operate is dest var.
Var that is get only in operate is source var.

Compute operates that input var and output var, use var index to specify the var.
The var index value is 0 to 15.
The var index takes up 1 byte in compute operate code data.

Compute has operate kinds that get and set 64 bits int and byte from and to memory.
This is enough element to do any atomic sync.
Atomic sync has 1 defining bit in memory that is set to do sync effect.
Operate kind that sets 1 byte to memory can be used to set the bit.

Compute does not need operate kind to get and set short and mid int from and to memory.
This is enough element to do any memory get and set.

Compute does not need operate kind to push and pop stack.

Compute does not need operate kind to call and return from maide.

This is enough element to do any execute instance of process info.

Compute has operate kind list.
The operate kind list is below:

## Mov
Set dest var with the value of source var.
Syntax: mov dest, source

## Mva
Set dest var first 2 bytes with the value of 16 bits source value.
Syntax: mva dest, source

## Mvb
Set dest var second 2 bytes with the value of 16 bits source value.
Syntax: mvb dest, source

## Mvc
Set dest var third 2 bytes with the value of 16 bits source value.
Syntax: mvc dest, source

## Mvd
Set dest var fourth 2 bytes with the value of 16 bits source value.
Syntax: mvd dest, source

## Mit
Set 64 bits int at memory index of sourceA var with the value of sourceB var.
Syntax: mit sourceA, sourceB

## Mif
Set dest var with the value of 64 bits int at the memory index of source var.
Syntax: mif dest, source

## Mbt
Set byte int at memory index of sourceA var with the byte value of sourceB var.
Syntax: mbt sourceA, sourceB

## Mbf
Set dest var with the value of byte int at the memory index of source var.
Syntax: mbf dest, source

## Moi
Set dest var with the value of current operate memory index.
Syntax: moi dest

## Toi
Go to operate at memory index of source var.
Syntax: toi source

## Cmo
Set dest var with the value of sourceB var if sourceA var is not zero.
Syntax: cmo dest, sourceA, sourceB

## Bsa
Set dest var with the value of 1 if sourceA var and sourceB var values are same.
Otherwise, set dest var with the value of 0.
Syntax: bsa dest, sourceA, sourceB

## Ble
Set dest var with the value of 1 if sourceA var value is less than the value of sourceB var value.
Otherwise, set dest var with the value of 0.
Syntax: ble dest, sourceA, sourceB

## Sbl
Set dest var with the value of 1 if sourceA var value is two complement signed less than the value of sourceB var value.
Otherwise, set dest var with the value of 0.
Syntax: sbl dest, sourceA, sourceB

## Add
Set dest var with the value of two complement add of sourceA var and sourceB var.
Syntax: add dest, sourceA, sourceB

## Sub
Set dest var with the value of two complement sub of sourceA var and sourceB var.
Syntax: sub dest, sourceA, sourceB

## Mul
Set dest var with the value of unsigned mul of sourceA var and sourceB var.
Syntax: mul dest, sourceA, sourceB

## Div
Set dest var with the value of unsigned div of sourceA var and sourceB var if sourceB var is not zero.
Otherwise, set dest var with the value of 0.
Syntax: div dest, sourceA, sourceB

## Smu
Set dest var with the value of two complement signed mul of sourceA var and sourceB var.
Syntax: smu dest, sourceA, sourceB

## Sdi
Set dest var with the value of two complement signed div of sourceA var and sourceB var if sourceB var is not zero.
Otherwise, set dest var with the value of 0.
Syntax: sdi dest, sourceA, sourceB

## And
Set dest var with the value of bitwise and of sourceA var and sourceB var.
Syntax: and dest, sourceA, sourceB

## Orn
Set dest var with the value of bitwise orn of sourceA var and sourceB var.
Syntax: orn dest, sourceA, sourceB

## Not
Set dest var with the value of bitwise not of source var.
Syntax: not dest, source

## Lit
Set dest var with the value of bitwise shift lite of sourceA var value with the count of sourceB var value.
Syntax: lit dest, sourceA, sourceB

## Rit
Set dest var with the value of bitwise unsigned shift rite of sourceA var value with the count of sourceB var value.
Syntax: rit dest, sourceA, sourceB

## Sri
Set dest var with the value of bitwise two complement signed shift rite of sourceA var value with the count of sourceB var value.
Syntax: sri dest, sourceA, sourceB