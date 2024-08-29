
int tamanho = 100;
int[] vetor = new int[tamanho];

Random random = new Random();
for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = random.Next(1000) + 1;
}


for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");

}
// bool troca;
// int n = vetor.Length;
// do
// {
//     troca = false;
//     for (int i = 0; i < vetor.Length - 1; i++)
//     {
//         if (vetor[i] > vetor[i + 1])
//         {
//             int aux = vetor[i];
//             vetor[i] = vetor[i + 1];
//             vetor[i + 1] = aux;
//             troca = true;
//         }

//     }
//     n--;
// } while (troca);

Console.WriteLine("Vetor antes da ordenação:");
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
    if ((i + 1) % 30 == 0) // Muda de linha a cada 20 elementos
    {
        Console.WriteLine();
    }
}

// Ordenando o vetor usando Bubble Sort
// BubbleSort(vetor);

// Exibindo vetor após a ordenação

Array.Sort(vetor);
Console.WriteLine("\n\nVetor após a ordenação:");
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
    if ((i + 1) % 30 == 0) // Muda de linha a cada 20 elementos
    {
        Console.WriteLine();
    }
}


// static void BubbleSort(int[] vetor)
// {
//     bool troca;
//     int n = vetor.Length;
//     do
//     {
//         troca = false; // Reinicia a flag de troca
//         for (int i = 0; i < n - 1; i++)
//         {
//             if (vetor[i] > vetor[i + 1])
//             {
//                 int aux = vetor[i];
//                 vetor[i] = vetor[i + 1];
//                 vetor[i + 1] = aux;
//                 troca = true; // Indica que houve uma troca
//             }
//         }
//         n--; // Diminui o intervalo de comparação, pois o maior valor está no final
//     } while (troca);
// }





