def find_my_number(highestSetBitIndexUpperBound, isTooBig):
    result = 0
    bitIndex = highestSetBitIndexUpperBound
    while bitIndex >= 0:
        bit = 1 << bitIndex
        result |= bit
        if isTooBig(result):
            result ^= bit
        bitIndex -= 1
    return result

def floor_of_log2(n):
    result = 0
    while n >= 2:
        result += 1
        n >>= 1
    return result

def floor_of_sqrt(n):
    return find_my_number(floor_of_log2(n), lambda x: x * x > n)

def is_perfect_square(n):
    x = floor_of_sqrt(n)
    return x * x == n
