using System;
using System.Threading;
using System.Threading.Tasks;

class BankAccount
{
    private int balance = 0;
    private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

    public async Task DepositAsync(int amount)
    {
        await semaphore.WaitAsync();
        try
        {
            await Task.Delay(100);
            balance += amount;
            Console.WriteLine($"Поповнення +{amount}");
        }
        finally
        {
            semaphore.Release();
        }
    }

    public async Task WithdrawAsync(int amount)
    {
        await semaphore.WaitAsync();
        try
        {
            await Task.Delay(100);
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Зняття -{amount}");
            }
            else
            {
                Console.WriteLine($"Недостатньо коштів для зняття -{amount}");
            }
        }
        finally
        {
            semaphore.Release();
        }
    }

    public int GetBalance()
    {
        return balance;
    }
}

class Program
{
    static async Task Main()
    {
        BankAccount account = new BankAccount();
        Task t1 = account.DepositAsync(200);
        Task t2 = account.WithdrawAsync(100);
        Task t3 = account.DepositAsync(300);
        Task t4 = account.WithdrawAsync(50);

        await Task.WhenAll(t1, t2, t3, t4); 

        Console.WriteLine($"💰 Фінальний баланс: {account.GetBalance()}");
    }
}