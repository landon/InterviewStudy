def is_perfect_square(n):
    x = n
    while int(x * x) > n:
        x = (x + n / x) / 2
    return int(x) * int(x) == n
