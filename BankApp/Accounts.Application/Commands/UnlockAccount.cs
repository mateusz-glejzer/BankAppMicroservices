﻿using Accounts.Domain.Entities;

namespace Accounts.Application.Commands;

public record UnlockAccount(Account BankAccount) : ICommand;