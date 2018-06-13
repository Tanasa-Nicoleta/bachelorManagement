using System;

namespace BachelorManagement.ApiLayer.Utils
{
    public static class Token
    {
        public static bool CheckTokenFormat(string token)
        {
            return Guid.TryParse(token, out Guid parsedToken);                
        }
    }
}
