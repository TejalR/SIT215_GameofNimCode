# SIT215_GameofNimCode
This repository contains the code for the game AI to play Nim with the user for the Problem Based Learning Task for SIT215.

## Solution Details:
Various solution method:

Minimax – Users a concept known as game trees to create all possible move each player could make and traversing down the tree from node to node to find the optimal path to win the game. The AI would learn in the process.

Nim-Sum – The cumulative XOR value of the number of coins/stones in each piles/heaps at any point of the game is called Nim-Sum at that point.

In our solution prediction made before game starts.

Based on two factors - The player who starts first.
                     - The initial configuration of the piles/heaps.

## How to Run Code:
1. Download the code in the file under the name GameofNim.cs.
2. Create a new folder on your device and place the cs file within it.
3. Use terminal to open a new console within the folder: `` dotnet new console ``
4. Once a new console has been created, open the folder on VS Code or on your respective editor.
5. Then you can run the program on your device by writing "dotnet run" in your terminal.
