﻿using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IRoleSelectRepository
{
    Task<Role?> GetById(int roleId);
}