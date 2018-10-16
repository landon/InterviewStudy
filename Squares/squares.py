import pygame
import sys

W = 1200
H = 700

N = 11100

def draw(surface, a, b, color):
    pygame.draw.rect(surface, color, (W / 2 - a / 2, H / 2 - b / 2, a, b), 1)

def is_perfect_square(n):
    x = n
    while x * x > n:
        x = (x + n // x) // 2
    return x * x == n
 
def main():
    pygame.init()
    pygame.display.set_caption("squares")

    clock = pygame.time.Clock()
    screen = pygame.display.set_mode((W, H))
    
    while True:
        a = N
        b = 1
        while a * a > N:
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    pygame.quit()
                    sys.exit()

            screen.fill((0,0,0))
            draw(screen, a, a, (150,0,0))
            draw(screen, b, b, (0,150,0))
            draw(screen, a, b, (0,0,150))
            pygame.display.update()

            a = (a + N // a) // 2
            b = N // a

            clock.tick(10)
     
if __name__=="__main__":
    main()