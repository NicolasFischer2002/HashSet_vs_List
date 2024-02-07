using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet_vs_List
{
    public class HashSet_vs_List_
    {
        public static void Start()
        {
            ComparaEficienciaHashList();
        }

        private static void ComparaEficienciaHashList()
        {
            // Inicializo as estruturas que serão alvos de comparação
            HashSet<int> hashset = new HashSet<int>();
            List<int> list = new List<int>();
            
            // Inicializo a estrutura responsável por armazenar os valores aleatórios que serão
            // utilizados para preencher a HashSet e a List
            List<int> listValoresAleatorios = new List<int>();
            
            // Inicializo a estrutura que será responsável por armazenar os índeces utilizados
            // nas verificações de pertencimento - Contains().
            List<int> listaIndicesAleatorios = new List<int>(100000);

            // Preencho a lista com valores aleatórios que serão passados para a HashSet e a List
            // Ambas as estruturas que serão comparadas terão os mesmos dados e por consequência o
            // mesmo tamanho
            PreencheEstrutura(listValoresAleatorios, 500000);

            Stopwatch cronometroHashSetPreencher = new Stopwatch();
            Stopwatch cronometroListPreencher = new Stopwatch();

            // Conometro a velocidade de uma HashSet em adicionar elementos em sua estrutura
            cronometroHashSetPreencher.Start();
            PreencheEstruturaValoresAleatorios(hashset, listValoresAleatorios);
            cronometroHashSetPreencher.Stop();

            TimeSpan tempoDecorridoPreencherHashSet = cronometroHashSetPreencher.Elapsed;
            Console.WriteLine($"Tempo decorrido para preencher hashset: {tempoDecorridoPreencherHashSet.TotalMilliseconds}");

            // Conometro a velocidade de uma List em adicionar elementos em sua estrutura
            cronometroListPreencher.Start();
            PreencheEstruturaValoresAleatorios(list, listValoresAleatorios);
            cronometroListPreencher.Stop();

            TimeSpan tempoDecorridoPreencherList = cronometroListPreencher.Elapsed;
            Console.WriteLine($"Tempo decorrido para preencher list: {tempoDecorridoPreencherList.TotalMilliseconds}");

            // Exibo um diagnóstico de qual estrutura foi mais veloz em adicionar dados em sua estrutura
            Console.WriteLine("\n");
            if (tempoDecorridoPreencherHashSet.TotalMilliseconds < tempoDecorridoPreencherList.TotalMilliseconds)
                Console.WriteLine($"HashSet foi {tempoDecorridoPreencherList.TotalMilliseconds / tempoDecorridoPreencherHashSet.TotalMilliseconds} " +
                    $"vezes mais veloz que List na inserção de elementos");
            else
                Console.WriteLine($"List foi {tempoDecorridoPreencherHashSet.TotalMilliseconds / tempoDecorridoPreencherList.TotalMilliseconds} " +
                    $"vezes mais veloz que HashSet na inserção de elementos");

            // Preencho a lista com índeces aleatórios que serão utilizados nas verificações
            // de pertencimento. Os índices serão os mesmos para ambas as estruturas, HashSet e List
            PreencheEstrutura(listaIndicesAleatorios, 50000);

            Stopwatch cronometroHashSet = new Stopwatch();
            Stopwatch cronometroList = new Stopwatch();

            // Cronometro o tempo decorrido para as operações de pertencimento de HashSet
            cronometroHashSet.Start();
            
            VerificaExisteValorEstrutura(hashset, listaIndicesAleatorios);
            
            cronometroHashSet.Stop();

            // Cronometro o tempo decorrido para as operações de pertencimento de List
            cronometroList.Start();

            VerificaExisteValorEstrutura(list, listaIndicesAleatorios);

            cronometroList.Stop();

            TimeSpan tempoDecorridoHashSetContains = cronometroHashSet.Elapsed;
            TimeSpan tempoDecorridoListContains = cronometroList.Elapsed;

            // Exibo um diagnóstico de qual estrutura foi mais veloz em verificar pertencimento
            Console.WriteLine("\n");
            Console.WriteLine($"Total de itens presentes em cada estrutura: HashSet {hashset.Count}, List {list.Count}");
            Console.WriteLine($"Tempo decorrido para verificações de pertencimento em HashSet: {tempoDecorridoHashSetContains.TotalMilliseconds} milissegundos");
            Console.WriteLine($"Tempo decorrido para verificações de pertencimento em List: {tempoDecorridoListContains.TotalMilliseconds} milissegundos");

            Console.WriteLine("\n");
            if (tempoDecorridoHashSetContains.TotalMilliseconds < tempoDecorridoListContains.TotalMilliseconds)
                Console.WriteLine($"HashSet foi {tempoDecorridoListContains.TotalMilliseconds / tempoDecorridoHashSetContains.TotalMilliseconds} " +
                    $"vezes mais veloz que List para operações de pertencimento");
            else
                Console.WriteLine($"List foi {tempoDecorridoHashSetContains.TotalMilliseconds / tempoDecorridoListContains.TotalMilliseconds} " +
                    $"vezes mais veloz que HashSet para operações de pertencimento");
        }

        private static void PreencheEstruturaValoresAleatorios(ICollection<int> estrutura, List<int> valoresAleatorios)
        {
            for (int i = 0; i < valoresAleatorios.Count; i++)
                if (!estrutura.Contains(valoresAleatorios[i]))
                    estrutura.Add(valoresAleatorios[i]);
        }

        private static void PreencheEstrutura(ICollection<int> estrutura, int quantidade)
        {
            Random random = new Random();
            int numeroInteiroAleatorio;

            for (int i = 0; i < quantidade; i++)
            {
                numeroInteiroAleatorio = random.Next(1, 1000000);
                
                if (!estrutura.Contains(numeroInteiroAleatorio))
                    estrutura.Add(numeroInteiroAleatorio);
            }
        }

        private static void VerificaExisteValorEstrutura<T>(ICollection<T> estrutura, List<T> indecesAleatorios)
        {
            for (int i = 0; i < indecesAleatorios.Count; i++)
                estrutura.Contains(indecesAleatorios[i]);
        }
    }
}
