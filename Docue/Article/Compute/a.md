# Compute
Compute has 32 vars.
Var is 64 bits int.

Compute operates that input var and output var, use var index to specify the var.
The var index value is 0 to 31.
The var index takes up 1 byte in compute operate code data.

Compute has operate set.
The operate set is listed below:

## Mov
Set dest var with the value of source var.
mov dest, source

## Mva
Set dest var first 2 bytes with the value of 16 bits source value.
mva dest, source

## Mvb
Set dest var second 2 bytes with the value of 16 bits source value.
mvb dest, source

## Mvc
Set dest var third 2 bytes with the value of 16 bits source value.
mvc dest, source

## Mvd
Set dest var fourth 2 bytes with the value of 16 bits source value.
mvd dest, source