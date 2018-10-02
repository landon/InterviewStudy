def is_perfect_square(n):
    bitIndex = 0
    nn = n
    while nn >= 2:
        bitIndex += 1
        nn >>= 1
    x = 0
    while bitIndex >= 0:
        bit = 1 << bitIndex
        x |= bit
        if x * x > n:
            x ^= bit
        bitIndex -= 1
    return x * x == n