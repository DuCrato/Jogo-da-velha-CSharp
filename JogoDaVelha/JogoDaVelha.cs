using System;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        private bool   endGame;
        private char[] position;
        private char   timePlayer;
        private int    cont;

        public JogoDaVelha()
        {
            position   = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            endGame    = false;
            timePlayer = 'X';
            cont       = 0;
        }

        public void startGame()
        {
            while(!endGame)
            {
                renderTable();
                readUserChoice();
                renderTable();
                checkEndGame();
                changePlayer();
            }
        }

        private void changePlayer()
        {
            if (timePlayer == 'X')
                timePlayer =  'O';
            else
                timePlayer =  'X';
        }

        private void checkEndGame()
        {
            if (cont < 5)
                return;

            if (winDiagonal() || winLine() || winColumn())
            {
                endGame = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {timePlayer}");
                return;
            }

            if (cont is 9)
            {
                endGame = true;
                Console.WriteLine("Fim de jogo!!! EMPATE");
            }
        }

        private bool winLine()
        {
            bool winLine1 = position[0] == position[1] && position[0] == position[2];
            bool winLine2 = position[3] == position[4] && position[3] == position[6];
            bool winLine3 = position[6] == position[7] && position[6] == position[8];

            return winLine1 || winLine2 || winLine3;
        }

        private bool winColumn()
        {
            bool winColumn1 = position[0] == position[3] && position[0] == position[6];
            bool winColumn2 = position[1] == position[4] && position[1] == position[7];
            bool winColumn3 = position[2] == position[5] && position[2] == position[8];

            return winColumn1 || winColumn2 || winColumn3;
        }

        private bool winDiagonal()
        {
            bool winDiogonal1 = position[2] == position[4] && position[2] == position[6];
            bool winDiogonal2 = position[0] == position[4] && position[0] == position[8];

            return winDiogonal1 || winDiogonal2;
        }

        private void readUserChoice()
        {
            Console.WriteLine($"Agaora é a vez de {timePlayer}, digite uma posição entre 1 e 9");

            bool converson = int.TryParse(Console.ReadLine(), out int chosenPosition);

            while (!converson || !validateChoice(chosenPosition))
            {
                Console.WriteLine("Por favor digite um número entre 1 e 9 que esteja disponível na tabela!!");
                converson = int.TryParse(Console.ReadLine(), out chosenPosition);
            }

            setChoice(chosenPosition);
        }

        private void setChoice(int positionChoice)
        {
            int index = positionChoice - 1;

            position[index] = timePlayer;
            cont++;
        }

        private bool validateChoice(int positionChoice)
        {
            var index = positionChoice - 1;

            return position[index] != 'O' && position[index] != 'X';
        }

        private void renderTable()
        {
            Console.Clear();
            Console.WriteLine(getTable());
        }

        private string getTable()
        {
            return $"\n\n\t {position[0]} | {position[1]} | {position[2]}\n" +
                   $"\t {position[3]} | {position[4]} | {position[5]}\n"    +
                   $"\t {position[6]} | {position[7]} | {position[8]}\n\n";
        }
    }
}
