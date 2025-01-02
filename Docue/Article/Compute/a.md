# Compute
Compute has 32 vars.
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
The var index value is 0 to 31.
The var index takes up 1 byte in compute operate code data.

Compute has operate set.
The operate set is listed below:

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
Set byte int at memory index of sourceA var with the value of sourceB var.
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