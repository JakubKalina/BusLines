using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Infrastructure.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
