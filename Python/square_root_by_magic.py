def is_perfect_square(n):
    x = n
    while int(x * x) > n:
        x = x / 2 + n / (2 * x)
    return int(x) * int(x) == n
