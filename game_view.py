import pygame
import sprites

WIN_WIDTH, WIN_HEIGHT = 900, 500
WIN = pygame.display.set_mode((WIN_WIDTH, WIN_HEIGHT))

COLOR_WHITE = (255, 255, 255)

FPS = 60


def main():
    """
    Main loop method of the game. The running loop inside main is held at 60FPS using the clock object.
    """
    player_rect = pygame.Rect(100, 300, sprites.PLAYER_WIDTH, sprites.PLAYER_HEIGHT)
    clock = pygame.time.Clock()
    run = True

    draw_window(player_rect)

    while run:
        clock.tick(FPS)
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                run = False

        handle_button_press(pygame.key.get_pressed(), player_rect)
    pygame.quit()


def handle_button_press(keys_pressed, rect):
    """
    This method will take care of the event button pressing handling.
    :param keys_pressed: pygame.key.get_pressed()
    :param rect: player rectangle to move
    """
    direction = ""

    if keys_pressed[pygame.K_s]:
        rect.y += 3
        direction = "down"
    if keys_pressed[pygame.K_d]:
        rect.x += 3
        direction = "right"
    if keys_pressed[pygame.K_w]:
        rect.y -= 3
        direction = "up"
    if keys_pressed[pygame.K_a]:
        rect.x -= 3
        direction = "left"

    update_player(rect, direction)


def update_player(rect, direction):
    """
    This method will take care of updating the player's position and sprites.
    :param rect: player rectangle to move
    :param direction: the direction in which to update the sprites
    """
    match direction:
        case "down":
            new_sprite = sprites.PLAYER_DOWN
        case "right":
            new_sprite = sprites.PLAYER_RIGHT
        case "up":
            new_sprite = sprites.PLAYER_UP
        case "left":
            new_sprite = sprites.PLAYER_LEFT
        case _:
            return

    WIN.fill(COLOR_WHITE)
    WIN.blit(new_sprite, (rect.x, rect.y))
    pygame.display.update()


def draw_window(rect):
    """
    Establishes the basis of the window.
    """
    WIN.fill(COLOR_WHITE)
    WIN.blit(sprites.PLAYER_DOWN, (rect.x, rect.y))
    pygame.display.update()
    pygame.display.update()


if __name__ == "__main__":
    main()
