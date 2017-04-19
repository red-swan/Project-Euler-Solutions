﻿(*
Triangle, square, pentagonal, hexagonal, heptagonal, and octagonal numbers are
all figurate (polygonal) numbers and are generated by the following formulae:

Triangle	 	P3,n=n(n+1)/2	 	1, 3, 6, 10, 15, ...
Square	 	    P4,n=n2	 	        1, 4, 9, 16, 25, ...
Pentagonal	 	P5,n=n(3n−1)/2	 	1, 5, 12, 22, 35, ...
Hexagonal	 	P6,n=n(2n−1)	 	1, 6, 15, 28, 45, ...
Heptagonal	 	P7,n=n(5n−3)/2	 	1, 7, 18, 34, 55, ...
Octagonal	 	P8,n=n(3n−2)	 	1, 8, 21, 40, 65, ...

The ordered set of three 4-digit numbers: 8128, 2882, 8281, has three 
interesting properties.

The set is cyclic, in that the last two digits of each number is the first two 
digits of the next number (including the last number with the first).
Each polygonal type: triangle (P3,127=8128), square (P4,91=8281), and pentagonal 
(P5,44=2882), is represented by a different number in the set.
This is the only set of 4-digit numbers with this property.

Find the sum of the only ordered set of six cyclic 4-digit numbers for which 
each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal, and 
octagonal, is represented by a different number in the set.
*)

#load "Tools.fsx"
open Tools

let polygonalGenerator s = 
    Seq.initInfinite (fun idx -> ((pown (idx+1) 2) * (s-2) - (idx+1)*(s-4))/2)

let polygonalCandidates s = 
    s
    |> polygonalGenerator
    |> Seq.skipWhile (fun x -> x <= 999)
    |> Seq.takeWhile (fun x -> x <= 9999)
    |> Seq.cache

let sharesDigits xxvv vvyy = 
    (xxvv / 100) = (vvyy % 100)

let isCyclical intSeq = 
    (Seq.append intSeq (Seq.take 1 intSeq))
    |> Seq.pairwise 
    |> Seq.fold (fun acc (num1,num2) -> acc & (sharesDigits num1 num2)) true

let candidates [first;second;third;fourth;fifth;sixth] = 
    seq { for i in first do
          for j in second do
          if sharesDigits i j then
              for k in third do
              if sharesDigits j k then 
                  for l in fourth do
                  if sharesDigits k l then
                      for m in fifth do
                      if sharesDigits l m then
                          for n in sixth do
                          if (sharesDigits m n) && (sharesDigits n i) then
                                yield [i;j;k;l;m;n]
          }
#time
let answer = 
    (permutations 6 [3 .. 8])
    |> Seq.map (fun x -> List.map polygonalCandidates x)
    |> Seq.map candidates
    |> Seq.find (fun x -> x |> Seq.isEmpty |> not)
    |> Seq.item 0 //[8256; 2882; 8128; 1281; 2512; 5625]
    |> Seq.sum
#time // 0.035 sec



////////////////////////////////////////////////////////////////////////////////
// using computation expressions

let isCyclicalPair num1 num2 = 
    (num1 / 100) = (num2 % 100)

type SearchPath() = 
    member this.Bind(m,f) = 
    member this.Return(x) = x

let search 













