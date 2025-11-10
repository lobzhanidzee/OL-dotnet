# OL-dotnet - Hangman Game

A console-based Hangman game built with C# and .NET 8. Challenge yourself to guess words letter by letter before running out of lives!

## Features

- **Interactive Console Gameplay** - Classic hangman experience in your terminal
- **Player Statistics** - Track wins, losses, and games played for each player
- **High Score System** - View top players ranked by wins
- **Word Management** - Loads words from external file for easy customization
- **Error Logging** - Comprehensive error handling with file-based logging
- **Input Validation** - Robust input validation and user feedback

## Getting Started

### Prerequisites

- .NET 8.0 or later
- Visual Studio 2022 (recommended) or any compatible IDE

### Installation

1. Clone the repository:

2. Build the project:

3. Run the application:

### Setup

Ensure you have a `words.txt` file in the project directory containing words for the game (one word per line). Example:

## How to Play

1. **Start the Game** - Run the application and select "Play Hangman"
2. **Enter Your Name** - Provide a player name for score tracking
3. **Make Guesses** - Enter letters one at a time to guess the hidden word
4. **Win or Lose** - You win by guessing all letters before running out of lives (default: 6 incorrect guesses)
5. **View Stats** - Check high scores and player statistics from the main menu

## Game Rules

- You have 6 incorrect guesses before losing
- Only alphabetic characters are accepted
- Letter guesses are case-insensitive
- Previously guessed letters cannot be guessed again
- Win by revealing all letters in the word

## Project Structure

## Core Classes

- **`HangmanGame`** - Main game controller managing game state and player interactions
- **`WordManager`** - Handles word selection, letter tracking, and display formatting
- **`StatsManager`** - Manages persistent player statistics and high scores
- **`Logger`** - Provides error logging to `errors.log` file

## Technical Details

- **Target Framework**: .NET 8.0
- **Language**: C# with nullable reference types enabled
- **File Storage**: Plain text files for words, statistics, and error logs
- **Architecture**: Object-oriented design with separation of concerns

## Configuration

- **Max Incorrect Guesses**: Default is 6, configurable in `HangmanGame` constructor
- **Stats File**: `stats.txt` (automatically created)
- **Error Log**: `errors.log` (automatically created)
- **Word File**: `words.txt` (must be provided)