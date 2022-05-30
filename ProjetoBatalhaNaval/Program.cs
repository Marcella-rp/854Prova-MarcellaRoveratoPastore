// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

//Utilizado string no menu,para diminuir a quantidade de verificações de erros.
string numeroMenu = "0";

Console.WriteLine("Olá! Vamos jogar batalha naval!");

while (numeroMenu != "1" && numeroMenu != "2")
{
    Console.WriteLine("Digite a escolha do menu:");
    Console.WriteLine("1 - Para jogo individual");
    Console.WriteLine("2 - Para jogo de duas pessoas");
    numeroMenu = Console.ReadLine();
}
if (numeroMenu == "1")
{
    Console.WriteLine("Ops! Em construção...");
}
if (numeroMenu == "2")
{
    Console.WriteLine("Qual o nome do primeiro jogador?");
    string nomeJogador1 = Console.ReadLine();
    Console.WriteLine("Qual o nome do segundo jogador?");
    string nomeJogador2 = Console.ReadLine();

    string[] jogadores = new string[2] { nomeJogador1, nomeJogador2 };
    string[,] batalhaNavalJ1 = new string[10, 10];
    string[,] batalhaNavalJ2 = new string[10, 10];

    Dictionary<string, int> valLin = new Dictionary<string, int>();
    valLin.Add("A", 0);
    valLin.Add("B", 1);
    valLin.Add("C", 2);
    valLin.Add("D", 3);
    valLin.Add("E", 4);
    valLin.Add("F", 5);
    valLin.Add("G", 6);
    valLin.Add("H", 7);
    valLin.Add("I", 8);
    valLin.Add("J", 9);

    Dictionary<string, int> embarcacoes = new Dictionary<string, int>();
    embarcacoes.Add("PA", 5);
    embarcacoes.Add("NT", 4);
    embarcacoes.Add("DS", 3);
    embarcacoes.Add("SB", 2);

    List<string> list = new List<string>();
    List<List<string>> embJ1 = new List<List<string>>() { list };
    List<List<string>> embJ2 = new List<List<string>>() { list };
    string coluna = "a";
    string linha = "b";
    int qtEmbJ1 = 0;
    int qtEmbJ2 = 0;
    int qtPA = 0;
    int qtNT = 0;
    int qtDS = 0;
    int qtSB = 0;

    Console.Clear();
    Console.WriteLine($"{nomeJogador1} posicione suas embarcações");

    while (qtEmbJ1 < 10) //Posicionamento do Jogador1
    {
        List<string> emb = new List<string>();
        bool incluir = true;
        bool inedito = true;
        bool diagonal1 = false;
        bool diagonal2 = false;
        string tpEmb = "X";
        string pos;

        while (!embarcacoes.ContainsKey(tpEmb))
        {
            Console.WriteLine("Qual o tipo da embarcação?");
            tpEmb = Console.ReadLine();
            tpEmb = tpEmb.ToUpper();
        }

        if (tpEmb == "PA")
        {
            if (qtPA < 1)
            {
                qtPA++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Porta Aviões");
                incluir = false;
            }
        }
        else if (tpEmb == "NT")
        {
            if (qtNT < 2)
            {
                qtNT++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Navios-Tanque");
                incluir = false;
            }
        }
        else if (tpEmb == "DS")
        {
            if (qtDS < 3)
            {
                qtDS++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Destroyers");
                incluir = false;
            }
        }
        else if (tpEmb == "SB")
        {
            if (qtSB < 4)
            {
                qtSB++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Submarinos");
                incluir = false;
            }
        }
        int j = 0;
        if (incluir)
        {
            while (j < embarcacoes[tpEmb])
            {
                Console.WriteLine($"Digite as posições {tpEmb}");
                pos = Console.ReadLine();
                var pattern = @"^[A-J,a-j]?\d?$";
                Regex regex = new Regex(pattern);
                if (string.IsNullOrWhiteSpace(pos))
                {
                    Console.WriteLine("Formato inválido.Qual a posição?");
                    pos = Console.ReadLine();
                }
                if (!regex.Match(pos).Success)
                {
                    Console.WriteLine("Formato inválido.Qual a posição?");
                    pos = Console.ReadLine();
                }
                if (!emb.Contains(pos))
                {
                    foreach (List<string> lista in embJ1)
                    {
                        if (!lista.Contains(pos))
                        {
                            inedito = true;
                        }
                        else
                        {
                            Console.WriteLine("A posição já está ocupada por outra embarcação");
                            inedito = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{pos} já foi digitado para essa embarcação");
                    inedito = false;
                }
                if (inedito)
                {
                    emb.Add(pos);
                    j++;
                }
            }
            for (int i = 0; i < (emb.Count() - 1); i++)
            {
                if (emb[i].Substring(1, 1) != emb[i + 1].Substring(1, 1))
                {
                    diagonal1 = true;
                }
                if (emb[i].Substring(0, 1) != emb[i + 1].Substring(0, 1))
                {
                    diagonal2 = true;
                }
            }
            if (diagonal1 && diagonal2)
            {
                Console.WriteLine("Embarcação com posições inválidas");
            }
            else
            {
                embJ1.Add(emb);
                qtEmbJ1++;
            }
        }
    }
    qtPA = 0;
    qtNT = 0;
    qtDS = 0;
    qtSB = 0;
    Console.Clear();
    Console.WriteLine($"{nomeJogador2} posicione suas embarcações");

    while (qtEmbJ2 < 10) //Posicionamento do Jogador2
    {
        List<string> emb = new List<string>();
        bool incluir = true;
        bool inedito = true;
        bool diagonal1 = false;
        bool diagonal2 = false;
        string tpEmb = "X";
        string pos;

        while (!embarcacoes.ContainsKey(tpEmb))
        {
            Console.WriteLine("Qual o tipo da embarcação?");
            tpEmb = Console.ReadLine();
            tpEmb = tpEmb.ToUpper();
        }
        if (tpEmb == "PA")
        {
            if (qtPA < 1)
            {
                qtPA++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Porta Aviões");
                incluir = false;
            }
        }
        else if (tpEmb == "NT")
        {
            if (qtNT < 2)
            {
                qtNT++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Navios-Tanque");
                incluir = false;
            }
        }
        else if (tpEmb == "DS")
        {
            if (qtDS < 3)
            {
                qtDS++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Destroyers");
                incluir = false;
            }
        }
        else if (tpEmb == "SB")
        {
            if (qtSB < 4)
            {
                qtSB++;
            }
            else
            {
                Console.WriteLine("Você já adicionou todos os Submarinos");
                incluir = false;
            }
        }
        int j = 0;
        if (incluir)
        {
            while (j < embarcacoes[tpEmb])
            {
                Console.WriteLine($"Digite as posições {tpEmb}");
                pos = Console.ReadLine();
                var pattern = @"^[A-J,a-j]?\d?$";
                Regex regex = new Regex(pattern);
                if (string.IsNullOrWhiteSpace(pos))
                {
                    Console.WriteLine("Formato inválido.Qual a posição?");
                    pos = Console.ReadLine();
                }
                if (!regex.Match(pos).Success)
                {
                    Console.WriteLine("Formato inválido.Qual a posição?");
                    pos = Console.ReadLine();
                }
                if (!emb.Contains(pos))
                {
                    foreach (List<string> lista in embJ2)
                    {
                        if (!lista.Contains(pos))
                        {
                            inedito = true;
                        }
                        else
                        {
                            Console.WriteLine("A posição já está ocupada por outra embarcação");
                            inedito = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{pos} já foi digitado para essa embarcação");
                    inedito = false;
                }
                if (inedito)
                {
                    emb.Add(pos);
                    j++;
                }
            }
            for (int i = 0; i < (emb.Count() - 1); i++)
            {
                if (emb[i].Substring(1, 1) != emb[i + 1].Substring(1, 1))
                {
                    diagonal1 = true;
                }
                if (emb[i].Substring(0, 1) != emb[i + 1].Substring(0, 1))
                {
                    diagonal2 = true;
                }
            }
            if (diagonal1 && diagonal2)
            {
                Console.WriteLine("Embarcação com posições inválidas");
            }
            else
            {
                embJ2.Add(emb);
                qtEmbJ2++;
            }
        }
    }
    //JOGAR
    int acertosJ1 = 0;
    int acertosJ2 = 0;
    string tiro;
    bool testeAcerto;
    while (acertosJ1 < 30 && acertosJ2 < 30)
    {
        testeAcerto = true;
        while (testeAcerto) //jogada do Jogador1
        {
            Console.Clear();
            Console.WriteLine($"{nomeJogador1} dê o seu tiro");
            for (int l = 0; l < 10; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    Console.Write($"( {batalhaNavalJ2[l, c]} )");
                }
                Console.WriteLine();
            }
            tiro = Console.ReadLine();
            var pattern = @"^[A-J,a-j]?\d?$";
            Regex regex = new Regex(pattern);
            if (string.IsNullOrWhiteSpace(tiro))
            {
                Console.WriteLine("Formato inválido.Qual a posição do tiro?");
                tiro = Console.ReadLine();
            }
            if (!regex.Match(tiro).Success)
            {
                Console.WriteLine("Formato inválido.Qual a posição do tiro?");
                tiro = Console.ReadLine();
            }
            linha = tiro.Substring(0, 1);
            linha = linha.ToUpper();
            int lin = valLin[linha];
            coluna = tiro.Substring(1, 1);
            int col = int.Parse(coluna) - 1;
            testeAcerto = false;
            foreach (List<string> lista in embJ2)
            {
                foreach (string posicao in lista)
                {
                    if (tiro == posicao)
                    {
                        acertosJ1++;
                        testeAcerto = true;
                    }
                }
            }
            if (testeAcerto)
            {
                Console.WriteLine($"{nomeJogador1} acertou o tiro!");
                batalhaNavalJ2[lin, col] = "X";
            }
            else
            {
                Console.WriteLine($"{nomeJogador1} errou o tiro!");
                batalhaNavalJ2[lin, col] = "A";
            }
            Console.ReadLine();
        }
        testeAcerto = true;
        while (testeAcerto) //jogada do Jogador2
        {
            Console.Clear();
            Console.WriteLine($"{nomeJogador2} dê o seu tiro");
            for (int l = 0; l < 10; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    Console.Write($"( {batalhaNavalJ1[l, c]} )");
                }
                Console.WriteLine();
            }
            tiro = Console.ReadLine();
            var pattern = @"^[A-J]?\d?$";
            Regex regex = new Regex(pattern);
            if (string.IsNullOrWhiteSpace(tiro))
            {
                Console.WriteLine("Formato inválido.Qual a posição do tiro?");
                tiro = Console.ReadLine();
            }
            if (!regex.Match(tiro).Success)
            {
                Console.WriteLine("Formato inválido.Qual a posição do tiro?");
                tiro = Console.ReadLine();
            }
            linha = tiro.Substring(0, 1);
            linha = linha.ToUpper();
            int lin = valLin[linha];
            coluna = tiro.Substring(1, 1);
            int col = int.Parse(coluna) - 1;
            testeAcerto = false;
            foreach (List<string> lista in embJ1)
            {
                foreach (string posicao in lista)
                {
                    if (tiro == posicao)
                    {
                        acertosJ1++;
                        testeAcerto = true;
                    }
                }
            }
            if (testeAcerto)
            {
                Console.WriteLine($"{nomeJogador2} acertou o tiro!");
                batalhaNavalJ1[lin, col] = "X";
            }
            else
            {
                Console.WriteLine($"{nomeJogador2} errou o tiro!");
                batalhaNavalJ1[lin, col] = "A";
            }
            Console.ReadLine();
        }
    }
}

