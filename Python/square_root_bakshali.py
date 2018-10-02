def is_perfect_square(n):
    x = n
    while int(x * x) > n:
        a = n / (2 * x) - x / 2
        b = x + a
        x = b - a * a / (2 * b)
    return int(x) * int(x) == n
