using DoubleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;
do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Add: ");
            value = Console.ReadLine() ?? string.Empty;
            list.Add(value);
            break;

        case "2":
            value = Console.ReadLine() ?? string.Empty;
            list.showForward(value);
            break;

        case "3":
            value = Console.ReadLine() ?? string.Empty;
            list.showBack(value);
            break;

        case "4":
            value = Console.ReadLine() ?? string.Empty;
            list.orderDecently(value);
            break;

        case "5":
            Console.Write("Show: ");
            value = Console.ReadLine() ?? string.Empty;
            list.showFashions(value);
            break;

        case "6":
            value = Console.ReadLine() ?? string.Empty;
            list.showGraph(value);
            break;

        case "7":
            value = Console.ReadLine() ?? string.Empty;
            list.exists(value);
            break;

        case "8":
            value = Console.ReadLine() ?? string.Empty;
            list.eliminate(value, false);
            break;

        case "9":
            value = Console.ReadLine() ?? string.Empty;
            list.eliminate(value, true);
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show back");
    Console.WriteLine("4. Order list decently");
    Console.WriteLine("5. Show fashions");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Check if exists");
    Console.WriteLine("8. Delete");
    Console.WriteLine("9. Delete all");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}