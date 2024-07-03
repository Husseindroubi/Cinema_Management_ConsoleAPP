using System;
using System.Collections.Generic;

public class CinemaManagementV2
{
    public static void Main(string[] args)
    {
        int[] seatsLeft = new int[] { 3, 1, 0, 5 };

        List<int> chosenMovies = new List<int>();

        string[,] movies = new string[,]
        {
            { "1.", "Inception", "17:30", "3", seatsLeft[0].ToString() },
            { "2.", "Terminator3", "19:00", "4", seatsLeft[1].ToString() },
            { "3.", "Oppenheimer", "19:00", "2", seatsLeft[2].ToString() },
            { "4.", "Barbie", "20:45", "1", seatsLeft[3].ToString() }
        };

        int[] stockLeft = new int[] { 117, 0, 50 };

        double[] snackPrices = new double[] { 1.5, 2.75, 4.0 };

        List<int> chosenSnacks = new List<int>();

        string[][] snackBar = new string[][]
        {
            new string[] { "1.", "Chocolate", snackPrices[0].ToString(), stockLeft[0].ToString() },
            new string[] { "2.", "Nuts mix", snackPrices[1].ToString(), stockLeft[1].ToString() },
            new string[] { "3.", "Sandwich", snackPrices[2].ToString(), stockLeft[2].ToString() }
        };

        int a = 1;
        int b = 1;
        int c = a + b;
        Console.WriteLine(" Welcome to (Our Cinema), you have to pay at least 15€ to show our programs... ");

        double cash;

        do
        {
            Console.WriteLine("How much money do you want to pay? (type 0 to exit) ");
            cash = double.Parse(Console.ReadLine());
        } while (cash < 15.0 && cash != 0.0);

        while (cash != 0.0)
        {
            Console.WriteLine($"Your credit is: {cash}€ , here are our programs:");
            Console.WriteLine("1. Buy movie ticket(s)");
            Console.WriteLine("2. Buy snack(s)");
            Console.WriteLine("3. Watch a movie");
            Console.WriteLine("4. Have some snack");
            Console.WriteLine("5. Play (lucky number) game {costs 5.00€}");
            Console.WriteLine("6. Leave the cinema");

            int choose;
            do
            {
                Console.WriteLine("Please choose the number of the program that you want...");
                choose = int.Parse(Console.ReadLine());
            } while (choose < 1 || choose > 6);

            if (choose == 6)
            {
                Console.WriteLine($"Here is your money: {cash}€, Thank you for your visit.. Goodbye!");
                break;
            }

            switch (choose)
            {
                case 1:
                    Console.WriteLine(" Here is our movie table for today: ");
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine(" Filmnr    Filmname         Time      Hall    SeatsLeft");
                    Console.WriteLine("-------------------------------------------------------");

                    for (int i = 0; i < movies.GetLength(0); ++i)
                    {
                        for (int x = 0; x < movies.GetLength(1); ++x)
                        {
                            if (x == 4 && seatsLeft[i] > 0)
                            {
                                Console.Write("available");
                            }
                            else if (x == 4 && seatsLeft[i] <= 0)
                            {
                                Console.Write("booked");
                            }
                            else
                            {
                                Console.Write($"   {movies[i, x]}   ");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("-------------------------------------------------------");

                    int filmNumber;
                    do
                    {
                        Console.WriteLine("Which movie do you want to watch (to cancel press 0).");
                        filmNumber = int.Parse(Console.ReadLine());
                    } while (filmNumber < 0 || filmNumber > movies.GetLength(0));

                    if (filmNumber == 0)
                    {
                        Console.WriteLine("Thank you for your visit. ");
                        continue;
                    }

                    Console.WriteLine("Nice choice ;)");
                    Console.WriteLine($"Available tickets: [{seatsLeft[filmNumber - 1]}].");
                    if (seatsLeft[filmNumber - 1] <= 0)
                    {
                        Console.WriteLine("No more available Tickets!! ");
                        continue;
                    }

                    int tickets;
                    do
                    {
                        Console.WriteLine("How many tickets do you want? (to cancel press 0).");
                        tickets = int.Parse(Console.ReadLine());
                    } while (tickets < 0 || tickets > seatsLeft[filmNumber - 1]);

                    if (tickets == 0)
                    {
                        Console.WriteLine("Thank you for your visit. ");
                        continue;
                    }

                    if (cash >= tickets * 15)
                    {
                        Console.WriteLine($"You have bought ({tickets}) ticket(s) and here is your {(cash - tickets * 15)}€ cash back!");

                        for (int i = 0; i < tickets; ++i)
                        {
                            chosenMovies.Add(filmNumber);
                        }

                        seatsLeft[filmNumber - 1] -= tickets;
                        movies[filmNumber - 1, 4] = seatsLeft[filmNumber - 1].ToString();
                        Console.WriteLine(string.Join(", ", chosenMovies));
                        cash -= tickets * 15;
                        continue;
                    }

                    Console.WriteLine($"Not enough money!! You can only buy {(int)(cash / 15.0)} tickets!! ");
                    break;
                case 2:
                    Console.WriteLine(" Here is our snack table for today: ");
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine(" Nr.    Snack         Price   Still Left?");
                    Console.WriteLine("-------------------------------------------------------");

                    for (int i = 0; i < snackBar.Length; ++i)
                    {
                        for (int x = 0; x < snackBar[0].Length; ++x)
                        {
                            if (x == 3 && stockLeft[i] > 0)
                            {
                                Console.Write("yes");
                            }
                            else if (x == 3 && stockLeft[i] <= 0)
                            {
                                Console.Write("no");
                            }
                            else
                            {
                                Console.Write($"   {snackBar[i][x]}   ");
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("-------------------------------------------------------");

                    int snackNumber;
                    do
                    {
                        Console.WriteLine("Which snack do you want to have (to cancel press 0).");
                        snackNumber = int.Parse(Console.ReadLine());
                    } while (snackNumber < 0 || snackNumber > snackBar.Length);

                    if (snackNumber == 0)
                    {
                        Console.WriteLine("Thank you for your visit. ");
                        continue;
                    }

                    Console.WriteLine("Yummy choice ;)");
                    Console.WriteLine($"Available Snacks: [{stockLeft[snackNumber - 1]}] pieces.");
                    if (stockLeft[snackNumber - 1] <= 0)
                    {
                        Console.WriteLine("No more stocks!! ");
                        continue;
                    }

                    int snack;
                    do
                    {
                        Console.WriteLine("How many of this snack do you want? (to cancel press 0).");
                        snack = int.Parse(Console.ReadLine());
                    } while (snack < 0 || snack > stockLeft[snackNumber - 1]);

                    if (snack == 0)
                    {
                        Console.WriteLine("Thank you for your visit. ");
                        continue;
                    }

                    if (cash >= snack * snackPrices[snackNumber - 1])
                    {
                        Console.WriteLine($"You have bought ({snack}) snack(s) and here is your {(cash - snackPrices[snackNumber - 1] * snack)}€ cash back!");

                        for (int i = 0; i < snack; ++i)
                        {
                            chosenSnacks.Add(snackNumber);
                        }

                        stockLeft[snackNumber - 1] -= snack;
                        snackBar[snackNumber - 1][3] = stockLeft[snackNumber - 1].ToString();
                        Console.WriteLine(string.Join(", ", chosenSnacks));
                        cash -= snackPrices[snackNumber - 1] * snack;
                        continue;
                    }

                    Console.WriteLine($"Not enough money!! You can only buy {cash / snackPrices[snackNumber - 1]:0.##} snacks!! ");
                    break;
                case 3:
                    if (chosenMovies.Count == 0)
                    {
                        Console.WriteLine("Please buy ticket(s) first!");
                    }
                    else
                    {
                        Console.WriteLine("Which movie do you want to watch?");

                        int selectMovie;
                        do
                        {
                            Console.WriteLine("1.Inception    2.Terminator3    3.Oppenheimer    4.Barbie");
                            selectMovie = int.Parse(Console.ReadLine());
                        } while (selectMovie < 1 || selectMovie > movies.GetLength(0));

                        if (!chosenMovies.Contains(selectMovie))
                        {
                            Console.WriteLine("You have picked the wrong movie ticket ");
                        }
                        else
                        {
                            Console.WriteLine($"You've selected movie number {selectMovie}. Enjoy!!");

                            for (int i = 0; i < chosenMovies.Count; ++i)
                            {
                                chosenMovies.Remove(selectMovie);
                            }

                            Console.WriteLine(string.Join(", ", chosenMovies));
                        }
                    }
                    break;
                case 4:
                    if (chosenSnacks.Count == 0)
                    {
                        Console.WriteLine("Please buy snack(s) first!");
                        continue;
                    }

                    Console.WriteLine("Which snack do you want to have?");

                    int selectSnack;
                    do
                    {
                        Console.WriteLine("1.Chocolate    2.Nuts Mix    3.Sandwich");
                        selectSnack = int.Parse(Console.ReadLine());
                    } while (selectSnack < 1 || selectSnack > snackBar.Length);

                    if (!chosenSnacks.Contains(selectSnack))
                    {
                        Console.WriteLine("You have picked the wrong snack ");
                        continue;
                    }

                    Console.WriteLine($"You've selected snack number {selectSnack}. Enjoy!!");

                    for (int i = 0; i < chosenSnacks.Count; ++i)
                    {
                        chosenSnacks.Remove(selectSnack);
                    }

                    Console.WriteLine(string.Join(", ", chosenSnacks));
                    break;
                case 5:
                    cash -= 5.0;
                    Random r = new Random();
                    int luckyNumber = r.Next(201);
                    Console.WriteLine($"Your lucky number is: {luckyNumber}");

                    for (int x = 0; x <= 10; ++x)
                    {
                        c = a + b;
                        Console.WriteLine($"{a} + {b} = {c}");
                        a = b;
                        b = c;
                    }

                    if (luckyNumber != c && luckyNumber % 10 != 0)
                    {
                        Console.WriteLine("Unfortunately you have lost!!");
                        b = 1;
                        a = 1;
                        continue;
                    }

                    Console.WriteLine("Congrats!! you have won 20€ ");
                    cash += 20.0;
                    b = 1;
                    a = 1;
                    break;
                default:
                    Console.WriteLine("Invalid entry, please try again");
                    break;
            }
        }
    }
}


