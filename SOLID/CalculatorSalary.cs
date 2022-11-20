using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class CalculatorSalary:IAccount
    {
        // Метод для расчета процентной ставки
        public void CalculateInterest(Account account)
        {
           // расчет процентной ставки зарплатного аккаунта по правилам банка
           account.Interest = account.Balance * 0.5;
        }
    }
}
