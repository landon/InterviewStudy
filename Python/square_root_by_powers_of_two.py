def find_my_number(powerOfTwoUpperBound, isTooBig):
    result = 0
    bit = powerOfTwoUpperBound
    while bit >= 1:
        result |= bit
        if isTooBig(result):
            result ^= bit
        bit >>= 1
    return result

def isolate_high_bit(n):
    while (n & n-1) > 0:
        n &= n - 1
    return n

def floor_of_sqrt(n):
    return find_my_number(isolate_high_bit(n), lambda x: x * x > n)

def is_perfect_square(n):
    x = floor_of_sqrt(n)
    return x * x == n