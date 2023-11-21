﻿using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class CommandResult : ICommandResult
{
    public CommandResult() { }

    public CommandResult(bool? success, string? message, object? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}