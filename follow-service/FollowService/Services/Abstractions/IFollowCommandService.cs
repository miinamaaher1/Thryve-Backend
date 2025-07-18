﻿namespace Application.Abstractions
{
    public interface IFollowCommandService
    {
        Task<bool> Follow(string userId, string otherId);

        Task Unfollow(string userId, string otherId);
    }
}
