﻿using Accounts.Domain.Entities;

namespace Accounts.Application.Commands;

public record CreateAccount(Account Account) : ICommand;