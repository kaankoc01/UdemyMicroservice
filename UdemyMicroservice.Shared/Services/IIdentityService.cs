﻿namespace UdemyMicroservice.Shared.Services
{
    public interface IIdentityService
    {
        public Guid GetUserId { get; }
        public string Username { get; }
    }
}
