def is_perfect_square(n):
    x = n
    while x * x > n:
        x = (x + n // x) // 2
    return x * x == n