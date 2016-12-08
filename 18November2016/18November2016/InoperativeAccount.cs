using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InOperativeAccount : AcountTypes
{
    public override bool Deposit()
    {
        return true;
    }

    public override bool WithDraw()
    {
        return true;
    }

    public override bool BalanceEnquiry()
    {
        return true;
    }
}
