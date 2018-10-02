def is_perfect_square(n):
    bit = n
    while (bit & bit-1) > 0:
        bit &= bit - 1
    x = 0
    while bit >= 1:
        x |= bit
        if x * x > n:
            x ^= bit
        bit >>= 1
    return x * x == n