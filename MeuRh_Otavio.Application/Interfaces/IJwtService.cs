﻿namespace MeuRh_Otavio.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string email);
    }
}
