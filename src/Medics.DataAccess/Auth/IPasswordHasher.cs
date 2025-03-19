using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.DataAccess.Auth;

public interface IPasswordHasher
{
    string Encrypt(string password, string salt);
    bool Verify(string hash, string password, string salt);
}
