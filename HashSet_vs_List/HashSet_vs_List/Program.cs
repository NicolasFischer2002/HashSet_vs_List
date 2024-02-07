using HashSet_vs_List;


try
{
    // Console.ForegroundColor = ConsoleColor.Blue;
    HashSet_vs_List_.Start();
}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Erro inesperado: {e.Message}");
}
