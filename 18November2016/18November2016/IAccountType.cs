using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public interface IAccountType
{
    bool BalanceEnquiry();
    bool Deposit();
    bool WithDraw();

}