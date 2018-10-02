import square_root_by_bits
import square_root_by_powers_of_two

for n in range(0, 101):
    print(str(n) + " : " + 
          str(square_root_by_bits.is_perfect_square(n)) + " : " + 
          str(square_root_by_powers_of_two.is_perfect_square(n)))
