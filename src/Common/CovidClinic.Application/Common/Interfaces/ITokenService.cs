﻿namespace CovidClinic.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtSecurityToken(string id);
    }
}
