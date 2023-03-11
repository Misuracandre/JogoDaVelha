namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tabuleiro = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            char jogador = 'X';
            int linhaSelecionada, colunaSelecionada;
            bool jogoFinalizado = false;

            while (!jogoFinalizado)
            {
                ImprimirTabuleiro(tabuleiro);

                Console.WriteLine("Jogador " + jogador + ", é a sua vez.Escolha uma linha (1-3): ");
                linhaSelecionada = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Jogador " + jogador + ", é a sua vez.Escolha uma coluna (1-3): ");
                colunaSelecionada = int.Parse(Console.ReadLine()) - 1;
                Console.Clear();

                if (tabuleiro[linhaSelecionada, colunaSelecionada] != 'X' && tabuleiro[linhaSelecionada, colunaSelecionada] != 'O')
                {
                    tabuleiro[linhaSelecionada, colunaSelecionada] = jogador;
                }
                else
                {
                    Console.WriteLine("Posição inválida, tente novamente.");
                    continue;
                }

                if (ChecarVitoria(tabuleiro, jogador))
                {
                    jogoFinalizado = true;
                    Console.WriteLine("jogador " + jogador + " venceu.");
                }
                else if (ChecarEmpate(tabuleiro))
                {
                    jogoFinalizado = true;
                    Console.WriteLine("Deu velha!");
                }
                else
                {
                    jogador = jogador == 'X' ? 'O' : 'X';
                }
            }

            ImprimirTabuleiro(tabuleiro);
            Console.ReadLine();
        }

        static void ImprimirTabuleiro(char[,] tabuleiro)
        {
            Console.WriteLine($" {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");
        }

        static bool ChecarVitoria(char[,] tabuleiro, char jogadorAtual)
        {
            // Verifica se o jogador atual venceu em alguma linha ou coluna
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual)
                {
                    Console.WriteLine("jogador " + jogadorAtual + " venceu.");
                    return true;
                }
                if (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual)
                {

                    return true;
                }
            }

            // Verifica se o jogador atual venceu em alguma diagonal
            if (tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual)
            {
                Console.WriteLine("jogador " + jogadorAtual + " venceu.");
                return true;
            }
            if (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual)
            {

                return true;
            }

            return false;
        }

        static bool ChecarEmpate(char[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] != 'X' && tabuleiro[i, j] != 'O')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
