// Задача: Написать программу, которая из имеющегося массива строк формирует массив из строк,
// длина которых меньше либо равна 3 символа.
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
// Примеры:
// [ "hello", "2", "world", ":-)" ] -> [ "2", ":-)" ]
// [ "1234", "1567", "-2", "computer science" ] -> [ "-2" ]
// [ "Russia", "Denmark", "Kazan" ] -> [ ]

const int MaxItemLength = 3;
const int MinItems = 1;

do
{
	Console.Clear();
	PrintTitle("Формирование из исходного массива строк нового массива со строками длиной не более 3-х символов", ConsoleColor.Cyan);

	int n = GetUserInputInt("Задайте число элементов массива: ", MinItems);
	string[] originalArray = GetUserInputArrayStr("Ввод строк элементов массива:", n);
	string[] resultArray = GetFilteredArray(originalArray, MaxItemLength);

	Console.WriteLine();

	PrintArrayStr(originalArray, ConsoleColor.DarkGray);
	Console.Write(" -> ");
	PrintArrayStr(resultArray, ConsoleColor.Yellow);

	Console.WriteLine();

} while (AskForRepeat());

// Methods

static string[] GetFilteredArray(string[] array, int maxLength)
{
	return new string[] { };
}

static void PrintArrayStr(string[] array, ConsoleColor foreColor)
{

}

static string[] GetUserInputArrayStr(string prompt, int size)
{
	Console.WriteLine(prompt);

	string[] array = new string[size];
	for (int i = 0; i < size; ++i)
	{
		Console.Write($"Введите {i + 1}-ю строку: ");
		string item = Console.ReadLine() ?? string.Empty;
		array[i] = item;
	}

	return array;
}

static int GetUserInputInt(string inputMessage, int minAllowed = int.MinValue, int maxAllowed = int.MaxValue)
{
	const string errorMessageWrongType = "Некорректный ввод! Требуется целое число. Пожалуйста повторите\n";
	string errorMessageOutOfRange = string.Empty;
	if (minAllowed != int.MinValue && maxAllowed != int.MaxValue)
		errorMessageOutOfRange = $"Число должно быть в интервале от {minAllowed} до {maxAllowed}! Пожалуйста повторите\n";
	else if (minAllowed != int.MinValue)
		errorMessageOutOfRange = $"Число не должно быть меньше {minAllowed}! Пожалуйста повторите\n";
	else
		errorMessageOutOfRange = $"Число не должно быть больше {maxAllowed}! Пожалуйста повторите\n";

	int input;
	bool notANumber = false;
	bool outOfRange = false;
	do
	{
		if (notANumber)
		{
			PrintError(errorMessageWrongType, ConsoleColor.Magenta);
		}
		if (outOfRange)
		{
			PrintError(errorMessageOutOfRange, ConsoleColor.Magenta);
		}
		Console.Write(inputMessage);
		notANumber = !int.TryParse(Console.ReadLine(), out input);
		outOfRange = !notANumber && (input < minAllowed || input > maxAllowed);

	} while (notANumber || outOfRange);

	return input;
}

static void PrintTitle(string title, ConsoleColor foreColor)
{
	int feasibleWidth = Console.BufferWidth;
	string titleDelimiter = new string('\u2550', feasibleWidth);
	PrintColored(titleDelimiter + Environment.NewLine + title + Environment.NewLine + titleDelimiter, foreColor);
	Console.WriteLine();
}

static void PrintError(string errorMessage, ConsoleColor foreColor)
{
	PrintColored("\u2757 Ошибка: " + errorMessage, foreColor);
}

static void PrintColored(string message, ConsoleColor foreColor)
{
	var bkpColor = Console.ForegroundColor;
	Console.ForegroundColor = foreColor;
	Console.Write(message);
	Console.ForegroundColor = bkpColor;
}

static bool AskForRepeat()
{
	Console.WriteLine();
	Console.WriteLine("Нажмите Enter, чтобы повторить или Esc, чтобы завершить...");
	ConsoleKeyInfo key = Console.ReadKey(true);
	return key.Key != ConsoleKey.Escape;
}
