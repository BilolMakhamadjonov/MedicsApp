﻿namespace Medics.DataAccess.Auth;

public class JwtOption
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
    public int ExpirationInMinutes { get; init; }
}