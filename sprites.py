import pygame
import os

PLAYER_WIDTH, PLAYER_HEIGHT = 80, 80

# Player Sprites UNSCALED.
_PLAYER_DOWN_UNSCALED = pygame.image.load(os.path.join('Assets', 'Sprites', 'Player', 'Player-stable-down.png'))

_PLAYER_RIGHT_UNSCALED = pygame.image.load(os.path.join('Assets', 'Sprites', 'Player', 'Player-stable-right.png'))

_PLAYER_UP_UNSCALED = pygame.image.load(os.path.join('Assets', 'Sprites', 'Player', 'Player-stable-up.png'))

_PLAYER_LEFT_UNSCALED = pygame.image.load(os.path.join('Assets', 'Sprites', 'Player', 'Player-stable-left.png'))

# Player Sprites Scaled.
PLAYER_DOWN = pygame.transform.scale(_PLAYER_DOWN_UNSCALED, (PLAYER_WIDTH, PLAYER_HEIGHT))

PLAYER_RIGHT = pygame.transform.scale(_PLAYER_RIGHT_UNSCALED, (PLAYER_WIDTH, PLAYER_HEIGHT))

PLAYER_UP = pygame.transform.scale(_PLAYER_UP_UNSCALED, (PLAYER_WIDTH, PLAYER_HEIGHT))

PLAYER_LEFT = pygame.transform.scale(_PLAYER_LEFT_UNSCALED, (PLAYER_WIDTH, PLAYER_HEIGHT))

