KeyValuePair<float, string>[] values = new KeyValuePair<float, string>[12];
values[0] = new KeyValuePair<float, string>(0.01f, "centavos");
values[1] = new KeyValuePair<float, string>(0.05f, "centavos");
values[2] = new KeyValuePair<float, string>(0.1f, "centavos");
values[3] = new KeyValuePair<float, string>(0.25f, "centavos");
values[4] = new KeyValuePair<float, string>(0.5f, "centavos");
values[5] = new KeyValuePair<float, string>(1, "reais");
values[6] = new KeyValuePair<float, string>(2, "reais");
values[7] = new KeyValuePair<float, string>(5, "reais");
values[8] = new KeyValuePair<float, string>(10, "reais");
values[9] = new KeyValuePair<float, string>(20, "reais");
values[10] = new KeyValuePair<float, string>(50, "reais");
values[11] = new KeyValuePair<float, string>(100, "reais");

List<KeyValuePair<float, string>> change = new List<KeyValuePair<float, string>>();

int index = values.Length - 1;

float CalculateChange(float diference, int index)
{
    if (diference <= 0)
        return 0;

    if (diference >= values[index].Key)
    {
        diference -= values[index].Key;
        change.Add(values[index]);

        return CalculateChange(diference, index);
    }
    if (diference < values[index].Key)
    {
        return CalculateChange(diference, index - 1);
    }

    return 0;
}


Console.Write("Digite o valor da compra: R$ ");

float.TryParse(Console.ReadLine(), out float purchaseValue);

Console.Write("\nDigite o valor da pagamento: R$ ");

float.TryParse(Console.ReadLine(), out float payment);

CalculateChange((payment - purchaseValue), index);

Console.WriteLine($"\n- Valor final da compra: R${purchaseValue}");
Console.WriteLine($"- Pagamento: R${payment}");
Console.WriteLine("- Troco: ");

var groupedChange = change.GroupBy(c => c.Key);

foreach (var item in groupedChange)
{
    Console.Write($"\t - {item.Count()} ");
    Console.Write($" {(item.ElementAt(0).Value == "reais" ? "notas" : "moedas")}");
    Console.Write($" de {item.ElementAt(0).Key} {item.ElementAt(0).Value}\n");
}