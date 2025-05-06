using System;
using TaskManager.Core.Domain.User;

namespace TaskManager.Application.User.DTO;

public class UserDTO
{
    public Guid Id { get; set; }

    public string? FullDomainName { get; set; }

    public UserType? UserType { get; set; }

    public UserStatus? UserStatus { get; set; }
}