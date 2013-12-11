int x = 1;
while (x == 1)
{
    DateTime now = DateTime.Now;
    int hour = now.Hour;
    int bet = hour + 2;
    Console.WriteLine(now + "\n" + hour.ToString() + " " + bet.ToString());

    if (hour >= 22 && hour < bet)
    {
        Console.WriteLine("Yay a process!");
        Thread.Sleep(((60000 * 60) * 3));
    }

    Thread.Sleep((60000 * 5));
}
Console.ReadLine();
