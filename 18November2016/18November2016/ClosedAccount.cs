using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ClosedAccount: AcountTypes
{
    public override bool Deposit()
    {
        return false;
    }

    public override bool WithDraw()
    {
        return false;
    }

    public override bool BalanceEnquiry()
    {
        return false;
    }
}