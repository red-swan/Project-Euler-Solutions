let rec gcd x y =
    if y = 0 then abs x
    else gcd y (x % y)
