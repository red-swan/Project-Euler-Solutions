﻿(*
The sequence of triangle numbers is generated by adding the natural numbers. 
So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first 
ten terms would be:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

Let us list the factors of the first seven triangle numbers:

 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?
*)

let divisorsOf number = seq {
    for divisor in 1 .. (float >> sqrt >> int) number do
    if number % divisor = 0 then
        yield divisor
        if number <> 1 then yield number / divisor //special case condition: when number=1 then divisor=(number/divisor), so don't repeat it
    }

let rec loop ourInt divisorThreshold = 
    let triangle = ((ourInt * ourInt + ourInt) / 2)
    let ourDivisors = divisorsOf triangle
    match Seq.length ourDivisors with
    | value when value >= divisorThreshold -> triangle
    | _ -> loop (ourInt + 1) divisorThreshold

let answer = loop 1 500
