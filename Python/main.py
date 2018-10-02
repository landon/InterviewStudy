import square_root_by_bits
import square_root_by_powers_of_two
import square_root_by_bits_jammed
import square_root_by_powers_of_two_jammed
import square_root_babylon
import square_root_babylon_no_float
import square_root_bakshali

for n in range(0, 101):
    print(str(n) + " : " + 
          str(square_root_by_bits.is_perfect_square(n)) + " : " + 
          str(square_root_by_powers_of_two.is_perfect_square(n)) + " : " +
          str(square_root_by_bits_jammed.is_perfect_square(n)) + " : " +
          str(square_root_by_powers_of_two_jammed.is_perfect_square(n)) + " : " +
          str(square_root_babylon.is_perfect_square(n)) + " : " +
          str(square_root_babylon_no_float.is_perfect_square(n)) + " : " +
          str(square_root_bakshali.is_perfect_square(n)))

